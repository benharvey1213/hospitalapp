using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = null;
            string name = null;
            try
            {
                username = Request.Cookies["username"].Value;
                name = Request.Cookies["name"].Value;
                
                // LoginButton.Visible = false;
                inp.Visible = false;
            }
            catch
            {
                // DashboardButton.Visible = false;
                // LogoutButton.Visible = false;

                dashp.Visible = false;
                outp.Visible = false;
            }
        }

        // for dashboard
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MyStuff/Dashboard.aspx");
        }

        // login
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyStuff/Login.aspx");
        }

        // logout
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Cookies["name"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Default.aspx");
        }
    }
}