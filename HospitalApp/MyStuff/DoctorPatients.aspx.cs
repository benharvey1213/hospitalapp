using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace HospitalApp.MyStuff
{
    public partial class DoctorPatients : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();
        string username = null;
        string name = null;
        int selectedPatientID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            // triggered on inital load of page, not postbacks
            if (!Page.IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
                buttonsDiv.Visible = false;
                appointmentDiv.Visible = false;
                confirmation.Visible = false;
            }

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
        }

        // search button for patients
        protected void Button1_Click(object sender, EventArgs e)
        {
            var patientQuery =
                from patient in dbcontext.Patients
                where (patient.FirstName + " " + patient.LastName).Contains(TextBox1.Text)
                select new { Name = patient.FirstName + " " + patient.LastName , Username = patient.UserLoginName };

            GridView1.DataSource = patientQuery.ToList();
            GridView1.DataBind();
        }

        // grid view of patient results
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonsDiv.Visible = true;

            //string rowUser = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();

            //Button1.Text = rowUser;

            //Response.Cookies["aptUsername"].Value = rowUser;
            //Response.Redirect("/MyStuff/")
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string rowUser = null;
            try
            {
                rowUser = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();
            }
            catch
            {
                lblErrorDiv.Visible = true;
                lblError.Text = "Must select a patient first";
                return;
            }
        }

        // make appointment
        protected void Button3_Click(object sender, EventArgs e)
        {
            string rowUser = null;
            try
            {
                rowUser = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();
            }
            catch
            {
                lblErrorDiv.Visible = true;
                lblError.Text = "Must select a patient first";
                return;
            }

            confirmation.Visible = false;
            appointmentDiv.Visible = true;

            var patientQuery =
                from Patient in dbcontext.Patients
                where Patient.UserLoginName == rowUser
                select new { Name = Patient.FirstName + " " + Patient.LastName , ID = Patient.PatientID};

            lblPatient.Text = "Patient: " + patientQuery.First().Name;
            selectedPatientID = patientQuery.First().ID;

            Calendar1.SelectedDate = DateTime.Now.Date;
            PopulateTimeDropDown();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/Dashboard.aspx");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            PopulateTimeDropDown();
        }

        private void PopulateTimeDropDown()
        {
            System.Diagnostics.Debug.WriteLine(Calendar1.SelectedDate.ToString());


            var timesQuery =
                from Appointment in dbcontext.Appointments
                join Doctor in dbcontext.Doctors on Appointment.DoctorID equals Doctor.DoctorID
                where Appointment.Time.Year == Calendar1.SelectedDate.Year
                    && Appointment.Time.Month == Calendar1.SelectedDate.Month
                    && Appointment.Time.Day == Calendar1.SelectedDate.Day
                    && Doctor.UserLoginName == username
                select Appointment.Time;

            System.Diagnostics.Debug.WriteLine(timesQuery.Count() + " unavailiable time");

            List<string> times = new List<string>();

            List<DateTime> thisDayAppointmentTimes = timesQuery.ToList();

            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);

            int interval = 30;

            while (start.Hour < end.Hour)
            {
                if (timesQuery.Count() != 0)
                {
                    foreach (DateTime time in thisDayAppointmentTimes)
                    {
                        if (!(time.Hour == start.Hour && time.Minute == start.Minute))
                        {
                            times.Add(start.ToString("h:mm tt"));
                        }
                    }
                }
                else
                {
                    times.Add(start.ToString("h:mm tt"));
                }
                start = start.AddMinutes(interval);
            }

            DropDownList1.DataSource = times;
            DropDownList1.DataBind();
        }

        // confirm appointment
        protected void Button5_Click(object sender, EventArgs e)
        {
            // patient id
            int patID = selectedPatientID;

            // doctor id
            var doctorQuery =
                from Doctor in dbcontext.Doctors
                where Doctor.UserLoginName == username
                select Doctor.DoctorID;

            int docID = doctorQuery.First();

            // appointment time
            DateTime time = Convert.ToDateTime(DropDownList1.SelectedValue);

            DateTime aptTime = new DateTime(Calendar1.SelectedDate.Year,
                Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day,
                time.Hour, time.Minute, time.Second);

            Calendar1.SelectedDate = DateTime.Now.Date;
            DropDownList1.DataSource = null;

            // purpose
            string purpose = inputfield0.Text;
            inputfield0.Text = "";

            // insert into the database
            Appointment apt = new Appointment
            {
                PatientID = patID,
                DoctorID = docID,
                Time = aptTime,
                Purpose = purpose
            };


            buttonsDiv.Visible = true;
            appointmentDiv.Visible = false;

            lblConfirmation.Text = "Appointment scheduled for " + PatientIDToFullName(patID) +
                " at " + apt.Time.ToString("h:mm tt") + " on " + apt.Time.ToString("MM/yy") + ".";

            confirmation.Visible = true;

            dbcontext.Appointments.Add(apt);
            dbcontext.SaveChanges();
        }

        protected string PatientIDToFullName(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);

            var patientQuery =
                from Patient in dbcontext.Patients
                where Patient.PatientID == id
                select new { Name = Patient.FirstName + " " + Patient.LastName };

            return patientQuery.First().Name;
        }
    }
}