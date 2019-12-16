using System;

namespace HospitalApp.MyStuff
{
    public partial class Doctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ensures a user is logged in
            string name = null;
            try
            {
                name = Request.Cookies["name"].Value;
            }
            catch
            {
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            // sets a label's text that welcomes the Doctor to the website
            GreetingLabel.Text = "Welcome, " + name + ".";
        }

        // Appointments
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/DoctorAppointments.aspx");
        }

        // Patients
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/DoctorPatients.aspx");
        }

        // Messages
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/Messages.aspx");
        }

    }
}