using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class PatientMedicationsTests : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            // ensures a user is logged in
            string username = null;
            string name = null;
            try
            {
                username = Request.Cookies["username"].Value;
                name = Request.Cookies["name"].Value;
            }
            catch
            {
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            // populate the medication and test gridviews

            var medicationQuery =
                from medicationPair in dbcontext.MedicationPairs
                join patient in dbcontext.Patients on medicationPair.PatientID equals patient.PatientID
                join medication in dbcontext.Medications on medicationPair.MedicationID equals medication.MedicationID
                where patient.UserLoginName == username
                select medication.MedicationName;

            GridView1.DataSource = medicationQuery.ToList();
            GridView1.DataBind();

            if (medicationQuery.Count() != 0)
            {
                noMeds.Visible = false;
            }

            //var testsQuery =
            //    from testPair in dbcontext.TestPairs
            //    join patient in dbcontext.Patients on testPair.PatientID equals patient.PatientID
            //    join test in dbcontext.Tests on testPair.TestID equals test.TestID
            //    join doctor in dbcontext.Doctors on test.DoctorID equals doctor.DoctorID
            //    where patient.UserLoginName == username
            //    select new { Date = test.TestDate, Doctor = doctor.FirstName + " " + doctor.LastName, Results = test.TestResults };

            var testsQuery =
                from appointment in dbcontext.Appointments
                join patient in dbcontext.Patients on appointment.PatientID equals patient.PatientID
                where patient.UserLoginName == username /*&& appointment.VisitSummary != null*/
                select new { Date = appointment.Time , Purpose = appointment.Purpose , Results = appointment.VisitSummary };

            GridView2.DataSource = testsQuery.ToList();
            GridView2.DataBind();

            if (testsQuery.Count() != 0)
            {
                noTests.Visible = false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // properly set header text
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Date";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/Dashboard.aspx");
        }
    }
}