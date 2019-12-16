using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class PatientTests : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
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

            NameLabel.Text = name + ".";

            var testsQuery =
                from testPair in dbcontext.TestPairs
                join patient in dbcontext.Patients on testPair.PatientID equals patient.PatientID
                join test in dbcontext.Tests on testPair.TestID equals test.TestID
                join doctor in dbcontext.Doctors on test.DoctorID equals doctor.DoctorID
                where patient.UserLoginName == username
                select new { Date = test.TestDate, Doctor = doctor.FirstName + " " + doctor.LastName, Results = test.TestResults };

            GridView1.DataSource = testsQuery.ToList();
            GridView1.DataBind();
        }
    }
}