using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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

            var doctorQuery =
                from doctor in dbcontext.Doctors
                select new { Name = doctor.FirstName + " " + doctor.LastName, DoctorUserName = doctor.UserLoginName };

            //var doctorList = doctorQuery.ToList();

            DropDownList1.DataSource = doctorQuery.ToList();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "DoctorUserName";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == null || TextBox2.Text == "")
            {
                ErrorLabel.Text = "Hey, looks like you forgot to write a message";
                return;
            }
            
            myMessager.SendMessage(DropDownList1.SelectedValue, thisUsername, TextBox2.Text);

            TextBox2.Text = "";
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
                dbcontext.Messages.Remove(message);
            }

            dbcontext.SaveChanges();
            PopulateMessageTable();
        }

        protected void PopulateMessageTable()
        {
            var messageQuery =
                from message in dbcontext.Messages
                where message.UserLoginNameTo == thisUsername
                select new { Date = message.Date, Sender = message.UserLoginNameFrom, Message = message.Message1 , MessageID = message.MessageID};

            if (messageQuery.Count() == 0)
            {
                TableLabel.Text = "No messages found";
            }
            else
            {
                TableLabel.Text = "Messages:";
            }

            GridView1.DataSource = messageQuery.ToList();
            GridView1.DataBind();
        }
    }
}