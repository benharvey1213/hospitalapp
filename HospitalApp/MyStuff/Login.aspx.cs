using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Windows.Forms;

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


            var userQuery =
                from Users in dbContext.Users
                where Users.UserLoginName == username && Users.UserLoginPass == password
                select Users;


            if (userQuery.Count() == 0)
            {
                // log in failure
                TextBox1.Text = "";
                TextBox2.Text = "";
                ErrorPlaceholder.Text = "Sorry, no user found with those credentials";
                Debug.WriteLine("no users");
            } 
            else
            {
                // log in success

                var nameQuery =
                    from Patients in dbContext.Patients
                    where Patients.UserLoginName == username
                    select Patients.FirstName;

                Response.Cookies["name"].Value = nameQuery.First();
                Response.Cookies["username"].Value = username;

                Debug.WriteLine(Request.Cookies["redirectedFrom"].Value);
                try
                {
                    Response.Redirect(Response.Cookies["redirectedFrom"].Value.ToString(), false);
                }
                catch
                {
                    FormsAuthentication.RedirectFromLoginPage(username, true);
                }
            }


            if (userQuery == null)
            {
                // no user
            }
            else
            {
                // sucessful login

            }
        }
    }
}