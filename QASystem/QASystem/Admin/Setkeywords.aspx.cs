using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QASystem.Admin
{
    public partial class Setkeywords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminId"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Guest/Index.aspx");
                }
                else
                {
                    if (!this.IsPostBack)
                    {
                        LoadTypes();
                    }

                    GetKeywords();
                }
            }
            catch
            {

            }
        }


        //function to load all types into dropdown list - dropdownlistTypes
        private void LoadTypes()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetTypes();

            if (tab.Rows.Count > 0)
            {
                DropDownListTypes.Items.Clear();
                DropDownListTypes.DataSource = tab;
                DropDownListTypes.DataTextField = "QuestionType";
                DropDownListTypes.DataValueField = "TypeId";

                DropDownListTypes.DataBind();

                DropDownListTypes.Items.Insert(0, "All");

            }
            else
            {
                DropDownListTypes.Items.Insert(0, "- Input Question Types-");

            }

        }

        //function to get all keywords
        private void GetKeywords()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            if (DropDownListTypes.SelectedIndex > 0)
            {
                tab = obj.GetKeywordsByType(int.Parse(DropDownListTypes.SelectedValue.ToString()));
            }
            else
            {
                tab = obj.GetAllKeywords();
            }

            if (tab.Rows.Count > 0)
            {
                tblKeywords.Rows.Clear();

                tblKeywords.BorderStyle = BorderStyle.Double;
                tblKeywords.GridLines = GridLines.Both;
                tblKeywords.BorderColor = System.Drawing.Color.DarkGray;

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

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>Keyword</b>";
                headerrow.Controls.Add(cell3);

                if (DropDownListTypes.SelectedIndex > 0)
                {
                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Delete</b>";
                    headerrow.Controls.Add(cell4);
                }

                tblKeywords.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Width = 10;
                    cellSerialNo.Font.Size = 10;
                    cellSerialNo.Text = serialNo + cnt + ".";
                    row.Controls.Add(cellSerialNo);

                    TableCell cellContent = new TableCell();
                    cellContent.Width = 150;

                    DataTable tabContent = new DataTable();
                    tabContent = obj.GetTypeById(int.Parse(tab.Rows[cnt]["TypeId"].ToString()));

                    cellContent.Text = tabContent.Rows[0]["QuestionType"].ToString();
                    row.Controls.Add(cellContent);

                    TableCell cellKeyword = new TableCell();
                    cellKeyword.Width = 150;
                    cellKeyword.Text = tab.Rows[cnt]["Word"].ToString();
                    row.Controls.Add(cellKeyword);

                    if (DropDownListTypes.SelectedIndex > 0)
                    {
                        TableCell cellDelete = new TableCell();

                        ImageButton btnDelete = new ImageButton();
                        btnDelete.Width = 25;
                        btnDelete.Height = 25;
                        btnDelete.ImageUrl = "~/images/DeleteIcon.jpg";
                        btnDelete.ToolTip = "Click here to Delete the Keyword";
                        btnDelete.ID = "Keyword~" + tab.Rows[cnt]["WordId"].ToString();
                        btnDelete.OnClientClick = "return confirm('Are you sure do you want to Delete')";
                        btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);

                        cellDelete.Controls.Add(btnDelete);
                        row.Controls.Add(cellDelete);
                    }
                    else
                    {

                    }

                    tblKeywords.Controls.Add(row);

                }

            }
            else
            {
                tblKeywords.Rows.Clear();
                tblKeywords.BorderStyle = BorderStyle.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ColumnSpan = 5;
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;

                if (DropDownListTypes.SelectedIndex > 0)
                {
                    cell.Text = "No Keywords Found for the Type - " + DropDownListTypes.SelectedItem.Text;
                }
                else
                {
                    cell.Text = "No Keywords Found";
                }

                row.Controls.Add(cell);
                tblKeywords.Controls.Add(row);

            }

        }

        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();
                obj.DeleteKeyword(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Keyword Deleted Successfully!!!')</script>");
                GetKeywords();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Deletion Error!!!')</script>");
            }
        }

        //function to clear the textboxes
        private void ClearPlaceTextboxes()
        {
            txtKeyword.Text = string.Empty;
            //DropDownListTypes.SelectedIndex = 0;
        }

        protected void DropDownListTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetKeywords();
        }

        protected void btnKeyword_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (DropDownListTypes.SelectedIndex > 0)
                {
                    if (obj.CheckKeyword(int.Parse(DropDownListTypes.SelectedValue.ToString()), txtKeyword.Text))
                    {
                        obj.InsertKeyword(int.Parse(DropDownListTypes.SelectedValue.ToString()), txtKeyword.Text);

                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Keyword Added Successfully')</script>");
                        ClearPlaceTextboxes();
                        DropDownListTypes_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Keyword Exists!!!')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Type!!!')</script>");
                }

            }
            catch
            {

            }
        }
              
    }
}