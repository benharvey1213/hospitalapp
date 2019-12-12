using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApp.MyStuff
{
    public partial class DoctorPatients : System.Web.UI.Page
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_Message(object sender, GridViewCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("message");
        }

        protected void GridView1_MakeAppointment(object sender, GridViewCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("appt");
        }
    }
}