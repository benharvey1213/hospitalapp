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
            string name = Response.Cookies["name"].Value;
            string username = Response.Cookies["username"].Value;

            NameLabel.Text = name + ".";

            var testsQuery =
                from testPair in dbcontext.TestPairs
                join patient in dbcontext.Patients on testPair.PatientID equals patient.PatientID
                join test in dbcontext.Tests on testPair.TestID equals test.TestID
                join doctor in dbcontext.Doctors on test.DoctorID equals doctor.DoctorID
                where patient.UserLoginName == username
                select new { Date = test.TestDate , Doctor =  doctor.DoctorID, Results = test.TestResults};

            GridView1.DataSource = testsQuery.ToList();
            GridView1.DataBind();
        }
    }
}