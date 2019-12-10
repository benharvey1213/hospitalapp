using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class DoctorAppointments : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();
        private string username = null;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            NameLabel.Text = name;

            PopulateAppointmentsGridView();


        }

        private void PopulateAppointmentsGridView()
        {
            var appointmentQuery =
                from appointment in dbcontext.Appointments
                join doctor in dbcontext.Doctors on appointment.DoctorID equals doctor.DoctorID
                join patient in dbcontext.Patients on appointment.PatientID equals patient.PatientID
                where doctor.UserLoginName == username
                select new { Date = appointment.Time, Patient = patient.FirstName + " " + patient.LastName, Purpose = appointment.Purpose };

            GridView1.DataSource = appointmentQuery.ToList();
            GridView1.DataBind();

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var patientQuery =
                from patient in dbcontext.Patients
                where patient.UserLoginName.Contains(inputfield.Text)
                orderby patient.LastName
                select new { PatientName = patient.LastName.Trim() + ", " + patient.FirstName , PatientID = patient.PatientID };

            GridView2.DataSource = patientQuery.ToList();
            GridView2.DataBind();

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // GridView1.SelectedRow.BackColor = System.Drawing.Color.White;

            // GridView1.Rows[GridView1.SelectedIndex].BackColor = Color.Red;
        }
    }
}