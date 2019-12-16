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
        Messager myMessager = new Messager();
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

            if (!Page.IsPostBack)
            {
                appointmentDiv.Visible = false;
                confirmationDiv.Visible = false;
                Calendar1.SelectedDate = DateTime.Now.Date;
            }


            PopulateAppointments();
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/Dashboard.aspx");
        }

        // schedule a new appointment
        protected void Button5_Click(object sender, EventArgs e)
        {
            confirmationDiv.Visible = false;
            aptDiv.Visible = false;
            btnScheduleDiv.Visible = false;
            appointmentDiv.Visible = true;

            // populate departments
            var departmentQuery =
                from doctor in dbcontext.Doctors
                select doctor.Department;

            List<string> departmentList = departmentQuery.ToList();
            List<string> filteredDepartmentList = new List<string>();
            filteredDepartmentList.Add("Any Department");

            // filter down to distinct values
            foreach(string dep in departmentList)
            {
                if (!filteredDepartmentList.Contains(dep))
                {
                    filteredDepartmentList.Add(dep);
                }
            }


            ddlDepartment.DataSource = filteredDepartmentList;
            ddlDepartment.DataBind();

            var doctorQuery =
                    from doctor in dbcontext.Doctors
                    select new { Doctor = doctor.FirstName + " " + doctor.LastName, DoctorID = doctor.DoctorID};

            ddlDoctor.DataTextField = "Doctor";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataSource = doctorQuery.ToList();
            ddlDoctor.DataBind();

            PopulateTimeDropDown();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartment.SelectedItem.Text == "Any Department")
            {
                var doctorQuery =
                    from doctor in dbcontext.Doctors
                    select new { Doctor = doctor.FirstName + " " + doctor.LastName, DoctorID = doctor.DoctorID };

                ddlDoctor.DataTextField = "Doctor";
                ddlDoctor.DataValueField = "DoctorID";
                ddlDoctor.DataSource = doctorQuery.ToList();
                ddlDoctor.DataBind();
            }
            else
            {
                var doctorQuery =
                    from doctor in dbcontext.Doctors
                    where doctor.Department == ddlDepartment.SelectedItem.Text
                    select new { Doctor = doctor.FirstName + " " + doctor.LastName, DoctorID = doctor.DoctorID };

                ddlDoctor.DataTextField = "Doctor";
                ddlDoctor.DataValueField = "DoctorID";
                ddlDoctor.DataSource = doctorQuery.ToList();
                ddlDoctor.DataBind();
            }

            PopulateTimeDropDown();
        }


        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("yeet");
            PopulateTimeDropDown();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            PopulateTimeDropDown();
        }

        private void PopulateTimeDropDown()
        {
            // stores the ID of the selected doctor
            int selectedDoctorID = Convert.ToInt32(ddlDoctor.SelectedItem.Value);

            // LINQ query to pull all the appointments on the selected Calendar day for the Doctor
            var timesQuery =
                from Appointment in dbcontext.Appointments
                join Doctor in dbcontext.Doctors on Appointment.DoctorID equals Doctor.DoctorID
                where Appointment.Time.Year == Calendar1.SelectedDate.Year
                    && Appointment.Time.Month == Calendar1.SelectedDate.Month
                    && Appointment.Time.Day == Calendar1.SelectedDate.Day
                    && Doctor.DoctorID == selectedDoctorID
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
            ddlTimes.DataSource = times;
            ddlTimes.DataBind();
        }

        // schedule appointment
        protected void btnSchedule_Click(object sender, EventArgs e)
        {
            // patient id
            var patientQuery =
                from patient in dbcontext.Patients
                where patient.UserLoginName == username
                select patient.PatientID;

            int patID = patientQuery.First();

            // doctor id
            int docID = Convert.ToInt32(ddlDoctor.SelectedItem.Value);

            // appointment time
            DateTime time = Convert.ToDateTime(ddlTimes.SelectedItem.Text);

            DateTime aptTime = new DateTime(Calendar1.SelectedDate.Year,
                Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day,
                time.Hour, time.Minute, time.Second);

            Calendar1.SelectedDate = DateTime.Now.Date;
            ddlTimes.DataSource = null;

            // purpose
            string purpose = textBoxPurpose.Text;
            textBoxPurpose.Text = "";  // reset input field

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

            var patientNameQuery =
                from patient in dbcontext.Patients
                where patient.UserLoginName == username
                select new { Name = patient.FirstName + " " + patient.LastName };

            var doctorUserNameQuery =
                from doctor in dbcontext.Doctors
                where doctor.DoctorID == docID
                select doctor.UserLoginName;

            var doctorNameQuery =
                from doctor in dbcontext.Doctors
                where doctor.DoctorID == docID
                select doctor.FirstName + " " + doctor.LastName;

            string doctorName = doctorNameQuery.First();
            string patientName = patientNameQuery.First().Name;
            string doctorUserName = doctorUserNameQuery.First();

            // send confirmation message to doctor
            string confirmationMessage = patientName + " has scheduled an appointment with you for " +
                apt.Time.ToString("h:mm tt") + " on " + apt.Time.ToString("MMMM dd, yyyy") + ".";

            myMessager.SendMessage(doctorUserName, username, confirmationMessage);

            aptDiv.Visible = true;
            btnScheduleDiv.Visible = true;
            appointmentDiv.Visible = false;

            lblConfirmation.Text = "You've scheduled an appointment with Dr. " + doctorName + " for " +
                apt.Time.ToString("h:mm tt") + " on " + apt.Time.ToString("MMMM dd, yyyy") + ".";

            confirmationDiv.Visible = true;

            // refresh appointments table
            PopulateAppointments();
        }

        private void PopulateAppointments()
        {
            var appointmentQuery =
                from appointment in dbcontext.Appointments
                join patient in dbcontext.Patients on appointment.PatientID equals patient.PatientID
                join doctor in dbcontext.Doctors on appointment.DoctorID equals doctor.DoctorID
                where patient.UserLoginName == username
                select new { Time = appointment.Time, Doctor = doctor.FirstName + " " + doctor.LastName, Purpose = appointment.Purpose };


            GridView1.DataSource = appointmentQuery.ToList();
            GridView1.DataBind();
        }
    }
}