using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = null;
            string name = null;
            try
            {
                username = Request.Cookies["username"].Value;
            }
            catch
            {
                Response.Cookies["redirectedFrom"].Value = "/MyStuff/Dashboard.aspx";
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            var patientQuery =
                from patient in dbcontext.Patients
                where patient.UserLoginName == username
                select patient.UserLoginName;

            if (patientQuery.Count() == 1)
            {
                Response.Redirect("/MyStuff/Patient.aspx", false);
            }

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