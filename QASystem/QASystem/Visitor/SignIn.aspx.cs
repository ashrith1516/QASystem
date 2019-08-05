using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QASystem.Visitor
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)

                txtUserId.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();

            tab=obj.CheckMemberLogin(txtUserId.Text,txtPassword.Text);

            if(tab.Rows.Count>0)
            {
                Session["MemberId"] = tab.Rows[0]["MemberId"].ToString();
                Response.Redirect("~/Member/PostQuery.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Invalid EmailId/Password')</script>");
            }
        }
    }
}