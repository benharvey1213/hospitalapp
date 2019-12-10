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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selected = Calendar1.SelectedDate;

            var timeQuery =
                from appointment in dbcontext.Appointments
                join doctor in dbcontext.Doctors on appointment.DoctorID equals doctor.DoctorID
                where doctor.UserLoginName == username /*&& appointment.Time.Date == Calendar1.SelectedDate*/
                select new { Time = appointment.Time };


            if (timeQuery.Count() == 0)
            {
                return;
            }

            List<string> avaliableTimes = new List<string>();

            for (int i = 8; i < 17; i++)
            {
                if (i <= 11)
                {
                    avaliableTimes.Add(i + ":00 AM");
                }
                else if (i == 12)
                {
                    avaliableTimes.Add(i + ":00 PM");
                }
                else
                {
                    avaliableTimes.Add((i - 12) + ":00 PM");
                }
            }


            // populate times
            // GridView3.DataSource = timeQuery.ToList();
            GridView3.DataSource = avaliableTimes;
            GridView3.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfirmLabel.Text = "Make an appointment with " + GridView2.SelectedRow.RowIndex.ToString() + " on " +
                Calendar1.SelectedDate.Month + "/" + Calendar1.SelectedDate.Day + " at " +
                GridView3.Rows[GridView3.SelectedRow.RowIndex] + "?";
        }
    }
}