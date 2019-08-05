using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QASystem.Member
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)

                LoadMember();    
        }

        //function to load member profile details
        public void LoadMember()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            try
            {
                tab.Rows.Clear();
                tab = obj.GetMemberById(int.Parse(Session["MemberId"].ToString()));

                txtFName.Text = tab.Rows[0]["FName"].ToString();
                txtLName.Text = tab.Rows[0]["LName"].ToString();
                txtAddress.Text = tab.Rows[0]["Address"].ToString();
                txtCOntactNo.Text = tab.Rows[0]["ContactNo"].ToString();
                txtOccupation.Text = tab.Rows[0]["Occupation"].ToString();
                lblDate.Text = "Registered Date: " + tab.Rows[0]["RegisteredDate"].ToString();

                DisableControls();
            }
            catch
            {

            }
        }

        //functiont to disable controls
        private void DisableControls()
        {
            txtAddress.Enabled = false;
            txtCOntactNo.Enabled = false;
            txtFName.Enabled = false;
            txtLName.Enabled = false;
            txtOccupation.Enabled = false;
        }

        //functiont to enable controls
        private void EnableControls()
        {
            txtAddress.Enabled = true;
            txtCOntactNo.Enabled = true;
            txtFName.Enabled = true;
            txtLName.Enabled = true;
            txtOccupation.Enabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            try
            {
                if (btnSubmit.Text.Equals("Edit"))
                {
                    EnableControls();
                    btnSubmit.Text = "Update";

                }
                else if (btnSubmit.Text.Equals("Update"))
                {
                    obj.UpdateMember(txtFName.Text, txtLName.Text, txtAddress.Text, txtCOntactNo.Text, txtOccupation.Text, int.Parse(Session["MemberId"].ToString()));

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Profile Updated Successfully')</script>");
                    btnSubmit.Text = "Edit";

                    LoadMember();
                }
            }
            catch
            {

            }
        }
    }
}