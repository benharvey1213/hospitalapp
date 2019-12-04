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
            string username = Request.Cookies["username"].Value;
            string name = Request.Cookies["name"].Value;

            NameLabel.Text = name;

            // this is the medication query, change this to appointments, idk why I did this
            var medicationQuery =
                from medicationPair in dbcontext.MedicationPairs
                join patient in dbcontext.Patients on medicationPair.PatientID equals patient.PatientID
                join medication in dbcontext.Medications on medicationPair.MedicationID equals medication.MedicationID
                where patient.UserLoginName == username
                select medication.MedicationName;


            GridView1.DataSource = medicationQuery.ToList();
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "Medication Name";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Date";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}