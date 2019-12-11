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
            buttonTime.Visible = false;
            buttonSearch.Visible = false;
            buttonCalendar.Visible = false;
            buttonPurpose.Visible = false;
            purposeDiv.Visible = false;
            calendarDiv.Visible = false;
            timeDiv.Visible = false;
            confirm.Visible = false;
            searchDiv.Visible = false;

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
            searchDiv.Visible = true;

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
            calendarDiv.Visible = true;
            searchDiv.Visible = false;
            buttonSearch.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            buttonSearch.Visible = true;
            buttonCalendar.Visible = true;
            timeDiv.Visible = true;

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
            // confirm appointment
            // need patientid, doctorid, purpose, datetime



        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSearch.Visible = true;
            buttonCalendar.Visible = true;
            buttonTime.Visible = true;

            timeDiv.Visible = false;

            purposeDiv.Visible = true;
        }

        protected void btnNewAppointment_Click(object sender, EventArgs e)
        {
            btnNewAppointment.Visible = false;
            searchDiv.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchDiv.Visible = true;
            buttonSearch.Visible = false;
            calendarDiv.Visible = false;
        }

        protected void btnCalendar_Click(object sender, EventArgs e)
        {
            buttonSearch.Visible = true;
            buttonCalendar.Visible = false;
            // btnSearch.Visible = true;
            // btnCalendar.Visible = false;
            calendarDiv.Visible = true;
        }

        protected void btnTime_Click(object sender, EventArgs e)
        {
            timeDiv.Visible = true;
            buttonTime.Visible = false;
            buttonSearch.Visible = true;
            buttonCalendar.Visible = true;
        }

        protected void btnPurpose_Click1(object sender, EventArgs e)
        {
            buttonPurpose.Visible = false;
            buttonTime.Visible = true;
            buttonSearch.Visible = true;
            buttonCalendar.Visible = true;
            purposeDiv.Visible = true;
        }

        protected void btnPurposeEnter_Click(object sender, EventArgs e)
        {
            

            purposeDiv.Visible = false;
            buttonPurpose.Visible = true;
            buttonTime.Visible = true;
            buttonSearch.Visible = true;
            buttonCalendar.Visible = true;

            confirm.Visible = true;

            ConfirmLabel.Text = "Make an appointment with " + GridView2.Rows[GridView2.SelectedRow.RowIndex].Cells[1].Text + " on " +
                Calendar1.SelectedDate.Month + "/" + Calendar1.SelectedDate.Day + " at " +
                GridView3.Rows[GridView3.SelectedRow.RowIndex].Cells[1].Text + "?";
        }
    }
}