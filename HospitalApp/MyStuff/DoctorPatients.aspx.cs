using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace HospitalApp.MyStuff
{
    public partial class DoctorPatients : System.Web.UI.Page
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


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // search button

            var patientQuery =
                from patient in dbcontext.Patients
                where (patient.FirstName + " " + patient.LastName).Contains(TextBox1.Text)
                select new { Name = patient.FirstName + " " + patient.LastName };

            GridView1.DataSource = patientQuery.ToList();
            GridView1.DataBind();

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

    }
}