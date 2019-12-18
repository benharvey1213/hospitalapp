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
            if (!Page.IsPostBack)
            {
                updateTestResultsDiv.Visible = false;
            }

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
            DateTime today = DateTime.Now;

            var appointmentQuery =
                from appointment in dbcontext.Appointments
                join doctor in dbcontext.Doctors on appointment.DoctorID equals doctor.DoctorID
                join patient in dbcontext.Patients on appointment.PatientID equals patient.PatientID
                where doctor.UserLoginName == username && appointment.Time >= today
                select new { Date = appointment.Time, Patient = patient.FirstName + " " + patient.LastName, Purpose = appointment.Purpose , AppointmentID = appointment.AppointmentID};

            GridView1.DataSource = appointmentQuery.ToList();
            GridView1.DataBind();

            if (appointmentQuery.Count() == 0)
            {
                lblCurrent.InnerText = "No upcoming appointments found";
            }

            var appointmentQuery2 =
                from appointment in dbcontext.Appointments
                join doctor in dbcontext.Doctors on appointment.DoctorID equals doctor.DoctorID
                join patient in dbcontext.Patients on appointment.PatientID equals patient.PatientID
                where doctor.UserLoginName == username && appointment.Time < today
                orderby appointment.Time descending
                select new { Date = appointment.Time, Patient = patient.FirstName + " " + patient.LastName, Purpose = appointment.Purpose , AppointmentID = appointment.AppointmentID };

            GridView2.DataSource = appointmentQuery2.ToList();
            GridView2.DataBind();

            if (appointmentQuery2.Count() == 0)
            {
                lblpast.InnerText = "No past appointments found";
            }

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowNum = Convert.ToInt32(e.RowIndex);
            int rowID = Convert.ToInt32(GridView1.DataKeys[rowNum].Value);
            
            System.Diagnostics.Debug.WriteLine(rowID);

            // LINQ query to select appointment to remove
            var appointmentQuery =
                from appointment in dbcontext.Appointments
                where appointment.AppointmentID == rowID
                select appointment;

            foreach (var appointment in appointmentQuery)
            {
                dbcontext.Appointments.Remove(appointment);
            }

            dbcontext.SaveChanges();
            PopulateAppointmentsGridView();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowNum = Convert.ToInt32(e.RowIndex);
            int rowID = Convert.ToInt32(GridView2.DataKeys[rowNum].Value);

            System.Diagnostics.Debug.WriteLine(rowID);

            // LINQ query to select appointment to remove
            var appointmentQuery =
                from appointment in dbcontext.Appointments
                where appointment.AppointmentID == rowID
                select appointment;

            foreach (var appointment in appointmentQuery)
            {
                dbcontext.Appointments.Remove(appointment);
            }

            dbcontext.SaveChanges();
            PopulateAppointmentsGridView();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTestResultsDiv.Visible = true;

            int aptID = Convert.ToInt32(GridView2.DataKeys[GridView2.SelectedIndex].Value);

            var summaryQuery =
                from appointment in dbcontext.Appointments
                where appointment.AppointmentID == aptID
                select appointment.VisitSummary;

            if (summaryQuery.First() == null)
            {
                TextBox1.Text = "";
            } else
            {
                TextBox1.Text = summaryQuery.First().Trim();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int aptID = Convert.ToInt32(GridView2.DataKeys[GridView2.SelectedIndex].Value);

            var summaryQuery =
                from appointment in dbcontext.Appointments
                where appointment.AppointmentID == aptID
                select appointment;

            foreach(Appointment apt in summaryQuery)
            {
                apt.VisitSummary = TextBox1.Text;
            }

            dbcontext.SaveChanges();

        }
    }
}