using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class DoctorAppointments : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();
        private string username = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // ensures a user is logged in
            try
            {
                username = Request.Cookies["username"].Value;
            }
            catch
            {
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            PopulateAppointmentsGridView();
        }

        // fills the gridview with all of the doctor's appointments
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

        // redirects to the Doctor Patients page when New Appointment is clicked
        protected void btnNewAppointment_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/DoctorPatients.aspx");
        }

        // redirects to the Dashboard when Back is clicked
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/Dashboard.aspx");
        }
    }
}