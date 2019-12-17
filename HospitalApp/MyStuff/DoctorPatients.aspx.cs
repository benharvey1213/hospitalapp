﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class DoctorPatients : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();
        Messager myMessager = new Messager();
        string username = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // triggered on inital load of page, not postbacks
            // this is so that everything is not reset when calendar dates are changed or buttons are clicked
            if (!Page.IsPostBack)
            {
                header.InnerText = "View Patients";
                Calendar1.SelectedDate = DateTime.Now.Date;
                buttonsDiv.Visible = false;
                appointmentDiv.Visible = false;
                confirmation.Visible = false;
                messager.Visible = false;
                patientInfoDiv.Visible = false;
            }

            // ensure that a user is logged in
            try
            {
                username = Request.Cookies["username"].Value;

                var doctorQuery =
                    from doctor in dbcontext.Doctors
                    where doctor.UserLoginName == username
                    select doctor;

                if (doctorQuery.Count() == 0)
                {
                    Response.Redirect("/MyStuff/Dashboard.aspx", false);
                }

            }
            catch
            {
                Response.Redirect("/MyStuff/Login.aspx", false);
            }
        }

        // search button for patients
        protected void Button1_Click(object sender, EventArgs e)
        {
            // this will try to parse the input as an integer to search for PatientID
            int textBoxInt = -1;
            try
            {
                textBoxInt = Convert.ToInt32(TextBox1.Text);

                var patientQuery =
                    from patient in dbcontext.Patients
                    where patient.PatientID == textBoxInt
                    select new { Name = patient.FirstName + " " + patient.LastName, Username = patient.UserLoginName };

                GridView1.DataSource = patientQuery.ToList();
                GridView1.DataBind();
            }

            // the text couldn't be parsed as an int, so the program will treat it as normal text
            catch
            {
                // if there there is no input, display all the patients
                if (TextBox1.Text.Trim() == "")
                {
                    var patientQuery =
                        from patient in dbcontext.Patients
                        select new { Name = patient.FirstName + " " + patient.LastName, Username = patient.UserLoginName };

                    GridView1.DataSource = patientQuery.ToList();
                    GridView1.DataBind();
                }

                // LINQ query to find a patient whose username or full name contains the search input
                else
                {
                    var patientQuery =
                        from patient in dbcontext.Patients
                        where (patient.FirstName + " " + patient.LastName).Contains(TextBox1.Text)
                            || patient.UserLoginName.Contains(TextBox1.Text)
                        select new { Name = patient.FirstName + " " + patient.LastName, Username = patient.UserLoginName };

                    GridView1.DataSource = patientQuery.ToList();
                    GridView1.DataBind();
                }
            }
        }

        // grid view of patient results
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonsDiv.Visible = true;
            confirmation.Visible = false;

            if (patientInfoDiv.Visible)
            {
                PopulatePatientInfo();
            }

            if (messager.Visible)
            {
                PopulateMessager();
            }
        }

        // send message
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (messager.Visible)
            {
                messager.Visible = false;
                return;
            }

            PopulateMessager();
        }

        private void PopulateMessager()
        {
            string rowUser = null;
            try
            {
                rowUser = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();
            }
            catch
            {
                return;
            }

            messager.Visible = true;
            lblTo.Text = "To: " + PatientUsernameToFullName(rowUser);
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
                return;
            }

            // set up visibility to simulate new screen
            header.InnerText = "Schedule Appointment";
            searchDiv.Visible = false;
            confirmation.Visible = false;
            appointmentDiv.Visible = true;
            buttonsDiv.Visible = false;

            // LINQ query to show the patient
            var patientQuery =
                from Patient in dbcontext.Patients
                where Patient.UserLoginName == rowUser
                select new { Name = Patient.FirstName + " " + Patient.LastName , ID = Patient.PatientID};

            lblPatient.Text = "Patient: " + patientQuery.First().Name;

            Calendar1.SelectedDate = DateTime.Now.Date;
            PopulateTimeDropDown();
        }

        // back button
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
            // LINQ query to pull all the appointments on the selected Calendar day for the Doctor
            var timesQuery =
                from Appointment in dbcontext.Appointments
                join Doctor in dbcontext.Doctors on Appointment.DoctorID equals Doctor.DoctorID
                where Appointment.Time.Year == Calendar1.SelectedDate.Year
                    && Appointment.Time.Month == Calendar1.SelectedDate.Month
                    && Appointment.Time.Day == Calendar1.SelectedDate.Day
                    && Doctor.UserLoginName == username
                select Appointment.Time;

            // this stores a list of the times on this day that are taken
            List<DateTime> thisDayAppointmentTimes = timesQuery.ToList();

            // this will store all the times available for the day selected
            List<string> times = new List<string>();

            // business hours (8 AM - 5 PM)
            int startHour = 8;
            int endHour = 17;

            // the program will increment between these times to fill the available time slots
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startHour, 0, 0);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, endHour, 0, 0);

            // the number of minutes for a time slot
            int interval = 30;

            // increment 
            while (start.Hour < end.Hour)
            {
                if (timesQuery.Count() != 0)
                {
                    bool appointmentMatch = false;

                    foreach (DateTime time in thisDayAppointmentTimes)
                    {
                        // checks if there is an appointment during this time
                        if (time.Hour == start.Hour && time.Minute == start.Minute)
                        {
                            appointmentMatch = true;
                        }
                    }

                    if (!appointmentMatch)
                    {
                        // if there isn't an appointment in this time slot, add it to the list
                        // of available times for the DropDownList
                        times.Add(start.ToString("h:mm tt"));
                    }
                }
                // bypasses any checks if there are no appointments this day
                else
                {
                    times.Add(start.ToString("h:mm tt"));
                }

                // increments the time to the next time slot
                start = start.AddMinutes(interval);
            }

            // once the available times are populated, bind them to the DropDownList
            DropDownList1.DataSource = times;
            DropDownList1.DataBind();
        }

        // confirm appointment
        protected void Button5_Click(object sender, EventArgs e)
        {
            // patient id
            int patID = PatientUsernameToID(GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString());

            // doctor id
            int docID = DoctorUsernameToID(username);

            // appointment time
            DateTime time = Convert.ToDateTime(DropDownList1.SelectedValue);

            DateTime aptTime = new DateTime(Calendar1.SelectedDate.Year,
                Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day,
                time.Hour, time.Minute, time.Second);

            Calendar1.SelectedDate = DateTime.Now.Date;
            DropDownList1.DataSource = null;

            // purpose
            string purpose = inputfield0.Text;
            inputfield0.Text = "";  // reset input field

            // insert into the database
            Appointment apt = new Appointment
            {
                PatientID = patID,
                DoctorID = docID,
                Time = aptTime,
                Purpose = purpose
            };
            dbcontext.Appointments.Add(apt);
            dbcontext.SaveChanges();

            // update visibility
            buttonsDiv.Visible = true;
            appointmentDiv.Visible = false;
            confirmation.Visible = true;
            buttonsDiv.Visible = true;
            searchDiv.Visible = true;

            // show visual confirmation for the user
            lblConfirmation.Text = "Appointment scheduled for " + PatientIDToFullName(patID) +
                " at " + apt.Time.ToString("h:mm tt") + " on " + apt.Time.ToString("MMMM dd, yyyy") + ".";

            // send confirmation message
            if (CheckBox1.Checked)
            {
                string doctorName = "Dr. " + DoctorUsernameToFullName(username);

                string confirmationMessage = doctorName + " has scheduled an appointment for you for " +
                    apt.Time.ToString("h:mm tt") + " on " + apt.Time.ToString("MMMM dd, yyyy") + ".";

                myMessager.SendMessage(GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString(),
                username, confirmationMessage);
            }
        }

        // send message
        protected void Button6_Click(object sender, EventArgs e)
        {
            myMessager.SendMessage(GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString(),
                username, Textbox3.Text);
            Textbox3.Text = "";

            messager.Visible = false;
        }

        #region Database Translation Methods
        protected string PatientIDToFullName(int id)
        {
            var patientQuery =
                from Patient in dbcontext.Patients
                where Patient.PatientID == id
                select new { Name = Patient.FirstName + " " + Patient.LastName };

            return patientQuery.First().Name;
        }

        protected int PatientUsernameToID(string username)
        {
            var patientQuery =
                from Patient in dbcontext.Patients
                where Patient.UserLoginName == username
                select new { ID = Patient.PatientID };

            return patientQuery.First().ID;
        }

        protected string PatientUsernameToFullName(string username)
        {
            var patientQuery =
                from Patient in dbcontext.Patients
                where Patient.UserLoginName == username
                select new { Name = (Patient.FirstName + " " + Patient.LastName) };

            return patientQuery.First().Name;
        }

        protected int DoctorUsernameToID(string username)
        {
            var doctorQuery =
                from Doctor in dbcontext.Doctors
                where Doctor.UserLoginName == username
                select new { ID = Doctor.DoctorID };

            return doctorQuery.First().ID;
        }

        protected string DoctorUsernameToFullName(string username)
        {
            var doctorQuery =
                from Doctor in dbcontext.Doctors
                where Doctor.UserLoginName == username
                select new { Name = Doctor.FirstName + " " + Doctor.LastName };

            return doctorQuery.First().Name;
        }
        #endregion

        // shows all patients assigned to this Doctor
        protected void Button8_Click(object sender, EventArgs e)
        {
            var doctorIDQuery =
                from doctor in dbcontext.Doctors
                where doctor.UserLoginName == username
                select doctor.DoctorID;

            int docId = doctorIDQuery.First();

            var patientQuery =
                    from patient in dbcontext.Patients
                    where patient.DoctorID == docId
                    select new { Name = patient.FirstName + " " + patient.LastName, Username = patient.UserLoginName };

            GridView1.DataSource = patientQuery.ToList();
            GridView1.DataBind();
        }

        // view patient info
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (patientInfoDiv.Visible)
            {
                patientInfoDiv.Visible = false;
                return;
            }

            patientInfoDiv.Visible = true;

            PopulatePatientInfo();
        }

        // fills multiple fields and gridviews with information about a patient
        private void PopulatePatientInfo()
        {
            string patientUsername = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();

            // patient name
            string rowUser = null;
            try
            {
                rowUser = patientUsername;
            }
            catch
            {
                return;
            }

            lblPatientName.Text = PatientUsernameToFullName(rowUser);

            // patient email
            var patientEmailQuery =
                from patient in dbcontext.Patients
                where patient.UserLoginName == patientUsername
                select patient.Email;

            string patientEmail = patientEmailQuery.First();

            lblEmail.Text = patientEmail;

            // address
            var patientAddressQuery =
                from patient in dbcontext.Patients
                where patient.UserLoginName == patientUsername
                select patient.Address;

            lblAddress.Text = patientAddressQuery.First();

            // phone
            var patientPhoneQuery =
                from patient in dbcontext.Patients
                where patient.UserLoginName == patientUsername
                select patient.Phone;

            lblPhone.Text = patientPhoneQuery.First();

            // appointment history
            var historyQuery =
                from appointment in dbcontext.Appointments
                join patient in dbcontext.Patients on appointment.PatientID equals patient.PatientID
                where patient.UserLoginName == patientUsername
                orderby appointment.Time descending
                select new { Date = appointment.Time, Purpose = appointment.Purpose , Summary = appointment.VisitSummary };

            GridView3.DataSource = historyQuery.ToList();
            GridView3.DataBind();

            if (historyQuery.Count() == 0)
            {
                lblHistory.Text = "No past appointments found";
            }
            else
            {
                lblHistory.Text = "Appointment History";
            }

            // medications
            var medicationQuery =
                from medicationPair in dbcontext.MedicationPairs
                join patient in dbcontext.Patients on medicationPair.PatientID equals patient.PatientID
                join medication in dbcontext.Medications on medicationPair.MedicationID equals medication.MedicationID
                where patient.UserLoginName == patientUsername
                select new { MedicationName = medication.MedicationName };


            GridView4.DataSource = medicationQuery.ToList();
            GridView4.DataBind();

            if (medicationQuery.Count() == 0)
            {
                lblMedication.Text = "No medications found";
            }
            else
            {
                lblMedication.Text = "Current Medications";
            }

            var medicationsQuery =
                from medication in dbcontext.Medications
                select new { MedicationName = medication.MedicationName , MedicationID = medication.MedicationID };

            DropDownList2.DataTextField = "MedicationName";
            DropDownList2.DataValueField = "MedicationID";
            DropDownList2.DataSource = medicationsQuery.ToList();
            DropDownList2.DataBind();

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            MedicationPair medPair = new MedicationPair();
            medPair.PatientID = PatientUsernameToID(GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString());
            medPair.MedicationID = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            dbcontext.MedicationPairs.Add(medPair);
            dbcontext.SaveChanges();
            PopulatePatientInfo();
        }
    }
}