using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QASystem.Admin
{
    public partial class AdminHome : System.Web.UI.Page
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
                    GetMembers();
                }
            }
            catch
            {

            }
        }


        //function to get registered members
        private void GetMembers()
        {
            int serialNo = 1;
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetMembers();

            if (tab.Rows.Count > 0)
            {
                tableMembers.Rows.Clear();

                tableMembers.BorderStyle = BorderStyle.Double;
                tableMembers.GridLines = GridLines.Both;
                tableMembers.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                //#bbd142
                headerrow.BackColor = System.Drawing.Color.Gray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Photo</b>";
                headerrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>FName</b>";
                headerrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>LName</b>";
                headerrow.Controls.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = "<b>Mobile</b>";
                headerrow.Controls.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = "<b>EmailId</b>";
                headerrow.Controls.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>Date</b>";
                headerrow.Controls.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = "<b>Delete</b>";
                headerrow.Controls.Add(cell8);

                tableMembers.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Text = cnt + serialNo + ".";
                    row.Controls.Add(cellSerialNo);

                    TableCell cellPhoto = new TableCell();
                    Image imgPhoto = new Image();
                    imgPhoto.Width = 50;
                    imgPhoto.Height = 50;
                    imgPhoto.ImageUrl = tab.Rows[cnt]["Photo"].ToString();
                    cellPhoto.Controls.Add(imgPhoto);
                    row.Controls.Add(cellPhoto);

                    TableCell cellFName = new TableCell();
                    cellFName.Width = 200;
                    cellFName.Text = tab.Rows[cnt]["FName"].ToString();
                    row.Controls.Add(cellFName);

                    TableCell cellLName = new TableCell();
                    cellLName.Width = 100;
                    cellLName.Text = tab.Rows[cnt]["LName"].ToString();
                    row.Controls.Add(cellLName);

                    TableCell cellMobile = new TableCell();
                    cellMobile.Width = 150;
                    cellMobile.Text = tab.Rows[cnt]["ContactNo"].ToString();
                    row.Controls.Add(cellMobile);

                    TableCell cellEmailId = new TableCell();
                    cellEmailId.Width = 200;
                    cellEmailId.Text = tab.Rows[cnt]["EmailId"].ToString();
                    row.Controls.Add(cellEmailId);

                    TableCell cellDate = new TableCell();
                    cellDate.Width = 200;
                    cellDate.Text = tab.Rows[cnt]["RegisteredDate"].ToString();
                    row.Controls.Add(cellDate);                 

                    TableCell cellDelete = new TableCell();

                    Button btnDelete = new Button();
                    btnDelete.ID = tab.Rows[cnt]["MemberId"].ToString();
                    btnDelete.Text = "Delete";
                    btnDelete.ToolTip = "Click here to delete Member";
                    btnDelete.OnClientClick = "return confirm('Are you sure do you want to delete?')";
                    btnDelete.Click += new EventHandler(btnDelete_Click);
                    cellDelete.Controls.Add(btnDelete);
                    row.Controls.Add(cellDelete);

                    tableMembers.Controls.Add(row);

                }
            }
            else
            {
                tableMembers.Rows.Clear();
                tableMembers.GridLines = GridLines.None;
                tableMembers.BorderStyle = BorderStyle.None;

                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.ColumnSpan = 10;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Size = 10;
                cell.Text = "<b>No Members Found</b>";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                tableMembers.Controls.Add(row);

            }

        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                Button btn = (Button)sender;
               
                obj.DeleteMember(int.Parse(btn.ID));

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Member deleted Successfully')</script>");
                tableMembers.Rows.Clear();
                GetMembers();
            }
            catch
            {

            }
        }

    }
}