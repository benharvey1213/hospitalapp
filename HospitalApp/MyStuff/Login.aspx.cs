using System;
using System.Linq;
using System.Web.Security;

namespace HospitalApp.MyStuff
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private HospitalDBEntities dbContext = new HospitalDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // define the username and password from user input
            // the trim method ensure there are no stray white spaces in the inputs
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            // cases where input is empty
            if (username == "" && password == "")
            {
                ErrorPlaceholder.Text = "Please enter your username and password";
                return;
            }
            if (username == "" && password != "")
            {
                ErrorPlaceholder.Text = "Please enter your username";
                return;
            }
            if (username != "" && password == "")
            {
                ErrorPlaceholder.Text = "Please enter your password";
                return;
            }

            // LINQ Query to find the entered user from username
            var userQuery =
                from Users in dbContext.Users
                where Users.UserLoginName == username && Users.UserLoginPass == password
                select Users;

            // log in failure
            if (userQuery.Count() == 0)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                ErrorPlaceholder.Text = "Sorry, no user found with those credentials";
            }

            // log in success
            else
            {
                // check if the username belongs to a patient
                var patientNameQuery =
                    from Patients in dbContext.Patients
                    where Patients.UserLoginName == username
                    select Patients.FirstName;

                if (patientNameQuery.Count() > 0)
                {
                    Response.Cookies["name"].Value = patientNameQuery.First();
                    Response.Cookies["username"].Value = username;
                    FormsAuthentication.RedirectFromLoginPage(username, true);
                    return;
                }

                // check if the username belongs to a doctor
                var doctorNameQuery =
                    from doctor in dbContext.Doctors
                    where doctor.UserLoginName == username
                    select doctor.LastName;

                if (doctorNameQuery.Count() > 0)
                {
                    Response.Cookies["name"].Value = "Dr. " + doctorNameQuery.First();
                    Response.Cookies["username"].Value = username;
                    FormsAuthentication.RedirectFromLoginPage(username, true);
                    return;
                }
            }
        }
    }
}