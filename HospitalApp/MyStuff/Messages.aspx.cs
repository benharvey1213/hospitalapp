using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class Messages : System.Web.UI.Page
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
                Response.Cookies["redirectedFrom"].Value = "/MyStuff/PatientMedications.aspx";
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            var messageQuery =
                from message in dbcontext.Messages
                select new { Sender = message.UserLoginNameFrom, Message = message.Message1 };

            GridView1.DataSource = messageQuery.ToList();
            GridView1.DataBind();
        }
    }
}