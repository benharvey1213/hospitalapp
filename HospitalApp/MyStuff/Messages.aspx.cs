﻿using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class Messages : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();
        Messager myMessager = new Messager();
        private string thisUsername = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = null;
            string name = null;
            try
            {
                username = Request.Cookies["username"].Value;
                thisUsername = Request.Cookies["username"].Value;
                name = Request.Cookies["name"].Value;
            }
            catch
            {
                Response.Cookies["redirectedFrom"].Value = "/MyStuff/PatientMedications.aspx";
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            PopulateMessageTable();

            // figure out whether this is for doctor or patient
            var docQuery =
                from doctor in dbcontext.Doctors
                where doctor.UserLoginName == username
                select doctor;

            // patient
            if (docQuery.Count() == 0)
            {
                btnSendDoctor.Visible = false;

                var doctorQuery =
                from doctor in dbcontext.Doctors
                select new { Name = doctor.FirstName + " " + doctor.LastName, DoctorUserName = doctor.UserLoginName };

                DropDownList1.DataSource = doctorQuery.ToList();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "DoctorUserName";
                DropDownList1.DataBind();
            }

            // doctor
            else
            {
                messagingDiv.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == null || TextBox2.Text == "")
            {
                ErrorLabel.Text = "Hey, it looks like you forgot to write a message";
                return;
            }

            myMessager.SendMessage(DropDownList1.SelectedValue, thisUsername, TextBox2.Text);

            TextBox2.Text = "";
            ErrorLabel.Text = "";
            PopulateMessageTable();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowNum = Convert.ToInt32(e.RowIndex);
            int rowID = Convert.ToInt32(GridView1.DataKeys[rowNum].Value);

            var deleteMessage =
                from message in dbcontext.Messages
                where message.MessageID == rowID
                select message;

            foreach (var message in deleteMessage)
            {
                message.InToBox = false;
            }

            dbcontext.SaveChanges();
            PopulateMessageTable();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowNum = Convert.ToInt32(e.RowIndex);
            int rowID = Convert.ToInt32(GridView2.DataKeys[rowNum].Value);

            var deleteMessage =
                from message in dbcontext.Messages
                where message.MessageID == rowID
                select message;

            foreach (var message in deleteMessage)
            {
                message.InFromBox = false;
            }

            dbcontext.SaveChanges();
            PopulateMessageTable();
        }

        protected void PopulateMessageTable()
        {
            var messageQuery =
                from message in dbcontext.Messages
                where message.UserLoginNameTo == thisUsername && message.InToBox == true
                select new { Date = message.Date, Sender = message.UserLoginNameFrom, Message = message.Message1 , MessageID = message.MessageID};

            if (messageQuery.Count() == 0)
            {
                TableLabel.Text = "No messages found";
            }
            else
            {
                TableLabel.Text = "Inbox";
            }

            GridView1.DataSource = messageQuery.ToList();
            GridView1.DataBind();

            var sentMessageQuery = 
                from message in dbcontext.Messages
                where message.UserLoginNameFrom == thisUsername && message.InFromBox == true
                select new { Date = message.Date, Recipient = message.UserLoginNameTo, Message = message.Message1, MessageID = message.MessageID };

            if (sentMessageQuery.Count() == 0)
            {
                TableLabel2.Text = "No sent messages found";
            }
            else
            {
                TableLabel2.Text = "Sent";
            }

            GridView2.DataSource = sentMessageQuery.ToList();
            GridView2.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/Dashboard.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/DoctorPatients.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}