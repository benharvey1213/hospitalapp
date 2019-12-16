using System;
using System.Linq;

namespace HospitalApp.MyStuff
{
    // the Dashboard page only serves as redirection page to the appropriate Doctor.aspx or Patient.aspx dashboard
    public partial class Dashboard : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            // ensures user is logged in
            string username = null;
            try
            {
                username = Request.Cookies["username"].Value;
            }
            catch
            {
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            // LINQ query to see if the logged in user is a Patient
            var patientQuery =
                from patient in dbcontext.Patients
                where patient.UserLoginName == username
                select patient.UserLoginName;

            if (patientQuery.Count() == 1)
            {
                Response.Redirect("/MyStuff/Patient.aspx", false);
            }

            // LINQ query to see if the logged in user is a Doctor
            var doctorQuery =
                from doctor in dbcontext.Doctors
                where doctor.UserLoginName == username
                select doctor.UserLoginName;

            if (doctorQuery.Count() == 1)
            {
                Response.Redirect("/MyStuff/Doctor.aspx");
            }
        }
    }
}