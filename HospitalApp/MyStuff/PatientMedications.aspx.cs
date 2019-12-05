using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class PatientMedications : System.Web.UI.Page
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
                System.Diagnostics.Debug.WriteLine(username);
                System.Diagnostics.Debug.WriteLine(name);
            }
            catch
            {
                Response.Cookies["redirectedFrom"].Value = "/MyStuff/PatientMedications.aspx";
                Response.Redirect("/MyStuff/Login.aspx", false);
            }

            NameLabel.Text = name + ".";

            var medicationQuery =
                from medicationPair in dbcontext.MedicationPairs
                join patient in dbcontext.Patients on medicationPair.PatientID equals patient.PatientID
                join medication in dbcontext.Medications on medicationPair.MedicationID equals medication.MedicationID
                where patient.UserLoginName == username
                select new { Medication = medication.MedicationName };

            GridView1.DataSource = medicationQuery.ToList();
            GridView1.DataBind();
            // GridView1.HeaderRow.Cells[0].Text = "Medication Name";
        }

    }
}