using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class PatientAppointments : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = null;
            string name = null;
            try
            {
                username = Request.Cookies["username"].Value;
                name = Request.Cookies["name"].Value;
            }
            catch
            {
                Response.Cookies["redirectedFrom"].Value = "/MyStuff/PatientMedications.aspx";
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            NameLabel.Text = name + ".";

            // this is the medication query, change this to appointments, idk why I did this
            var appointmentQuery =
                from appointment in dbcontext.Appointments
                join patient in dbcontext.Patients on appointment.PatientID equals patient.PatientID
                join doctor in dbcontext.Doctors on appointment.DoctorID equals doctor.DoctorID
                where patient.UserLoginName == username
                select new { Time = appointment.Time , Doctor = doctor.FirstName + " " + doctor.LastName , Purpose = appointment.Purpose };


            GridView1.DataSource = appointmentQuery.ToList();
            GridView1.DataBind();
            // GridView1.HeaderRow.Cells[0].Text = "Medication Name";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Date";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}