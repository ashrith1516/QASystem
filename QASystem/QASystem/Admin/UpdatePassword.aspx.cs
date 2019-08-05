using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QASystem.Admin
{
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminId"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Visitor/SignIn.aspx");
                }
                else
                {
                    if (!this.IsPostBack)

                        txtOldPassword.Focus();
                }
            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();
            tab.Rows.Clear();

            tab = obj.GetAdminById(Session["AdminId"].ToString());
            string oldPassword = tab.Rows[0]["Password"].ToString();

            if (txtOldPassword.Text.Equals(oldPassword))
            {
                obj.UpdateAdminPassword(txtPassword.Text, Session["AdminId"].ToString());
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Admin Password changed successfully')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Admin Old password incorrect')</script>");
            }
        }
    }
}