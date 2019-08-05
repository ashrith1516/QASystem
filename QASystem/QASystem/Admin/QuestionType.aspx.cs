using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QASystem.Admin
{
    public partial class QuestionType : System.Web.UI.Page
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
                    LoadTypes();
                }
            }
            catch
            {

            }

        }


        //function to get all question types
        private void LoadTypes()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetTypes();

            if (tab.Rows.Count > 0)
            {
                tbTypes.Rows.Clear();

                tbTypes.BorderStyle = BorderStyle.Double;
                tbTypes.GridLines = GridLines.Both;
                tbTypes.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                headerrow.BackColor = System.Drawing.Color.Gray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Question Type</b>";
                headerrow.Controls.Add(cell2);
                               
                TableCell cell4 = new TableCell();
                cell4.Text = "<b>Delete</b>";
                headerrow.Controls.Add(cell4);

                tbTypes.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Width = 10;
                    cellSerialNo.Font.Size = 10;
                    cellSerialNo.Text = serialNo + cnt + ".";
                    row.Controls.Add(cellSerialNo);

                    TableCell cellType = new TableCell();
                    cellType.Width = 150;
                    cellType.Text = tab.Rows[cnt]["QuestionType"].ToString();
                    row.Controls.Add(cellType);

                    TableCell cellDelete = new TableCell();

                    ImageButton btnDelete = new ImageButton();
                    btnDelete.Width = 15;
                    btnDelete.Height = 15;
                    btnDelete.ImageUrl = "~/images/deletebtn.jpg";
                    btnDelete.ToolTip = "Click here to Delete the Type";
                    btnDelete.ID = tab.Rows[cnt]["TypeId"].ToString();
                    btnDelete.OnClientClick = "return confirm('Are you sure do you want to Delete')";
                    btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);

                    cellDelete.Controls.Add(btnDelete);
                    row.Controls.Add(cellDelete);

                    tbTypes.Controls.Add(row);
                }
            }
            else
            {
                tbTypes.Rows.Clear();
                tbTypes.BorderStyle = BorderStyle.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ColumnSpan = 5;
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Text = "No Question Types Found";
                row.Controls.Add(cell);

                tbTypes.Controls.Add(row);

            }

        }

        //click event to delete question type based on id
        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                
                BLL obj = new BLL();
                obj.DeleteKeywordsByType(int.Parse(btn.ID.ToString()));
                obj.DeleteType(int.Parse(btn.ID.ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Question Type Deleted Successfully!!!')</script>");
                LoadTypes();             
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Deletion Error!!!(Server Error!!!)')</script>");
            }
        }

        //function to clear the place textboxes
        private void clearTxts()
        {
           txtType.Text = string.Empty;
        }

        protected void btnType_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();
                
                if (obj.CheckType(txtType.Text))
                {
                    obj.InsertType(txtType.Text);                    
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Question Type Added Successfully')</script>");
                    clearTxts();
                    LoadTypes();

                }
                else
                {                   
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Type Exists!!!')</script>");
                }



            }
            catch
            {

            }
        }
    }
}