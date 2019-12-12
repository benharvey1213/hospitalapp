using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = "Welcome, " + Request.Cookies["name"].Value + "!";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // appointments
            Response.Redirect("/MyStuff/PatientAppointments.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // medications
            Response.Redirect("/MyStuff/PatientMedicationsTests.aspx");
        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    // test results
        //    Response.Redirect("/MyStuff/PatientTests.aspx");
        //}

        protected void Button4_Click(object sender, EventArgs e)
        {
            // messages
            Response.Redirect("/MyStuff/Messages.aspx");
        }
    }
}