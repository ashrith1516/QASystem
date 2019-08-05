using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QASystem.Member
{
    public partial class Answers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["MemberId"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("../Visitor/Index.aspx");
                }
                else
                {
                    lblQuestion.Text = "Question: " + Request.QueryString["Question"].ToString();
                    GetAnswers();
                }
            }
            catch
            {

            }
        }

        public void GetAnswers()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab.Rows.Clear();
            
            tab = obj.GetAnswersByStatus(int.Parse(Request.QueryString["QuestionId"].ToString()),"Active");
            
            int serialNo = 1;

            tableAnswers.Rows.Clear();

            if (tab.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row1 = new TableRow();

                    TableCell row1_cell1 = new TableCell();
                    row1_cell1.Font.Size = 10;
                    row1_cell1.Text = cnt + serialNo + ".";
                    row1.Controls.Add(row1_cell1);

                    DataTable tabTitle = new DataTable();

                    if (tab.Rows[cnt]["AnswerType"].Equals("Text"))
                    {
                        tabTitle = obj.GetTextsByAnswerId(int.Parse(tab.Rows[cnt]["AnswerId"].ToString()));

                        TableCell cell_comment = new TableCell();

                        HyperLink hypMore = new HyperLink();
                        hypMore.Text = tabTitle.Rows[0]["Answer"].ToString() + " [Status: " + tab.Rows[cnt]["Status"].ToString() + "]"; ;

                        hypMore.NavigateUrl = string.Format("AnswerDetails.aspx?answerId={0}", tab.Rows[cnt]["AnswerId"].ToString());
                        cell_comment.Controls.Add(hypMore);
                        row1.Controls.Add(cell_comment);

                    }
                    else if (tab.Rows[cnt]["AnswerType"].Equals("Photo"))
                    {
                        tabTitle = obj.GetPhotosByAnswerId(int.Parse(tab.Rows[cnt]["AnswerId"].ToString()));

                        TableCell cell_comment = new TableCell();

                        HyperLink hypMore = new HyperLink();
                        hypMore.Text = tabTitle.Rows[0]["Title"].ToString() + " [Status: " + tab.Rows[cnt]["Status"].ToString() + "]"; ;

                        hypMore.NavigateUrl = string.Format("AnswerDetails.aspx?answerId={0}", tab.Rows[cnt]["AnswerId"].ToString());
                        cell_comment.Controls.Add(hypMore);
                        row1.Controls.Add(cell_comment);

                    }
                    else if (tab.Rows[cnt]["AnswerType"].Equals("Video"))
                    {
                        tabTitle = obj.GetVediosByAnswerId(int.Parse(tab.Rows[cnt]["AnswerId"].ToString()));

                        TableCell cell_comment = new TableCell();

                        HyperLink hypMore = new HyperLink();
                        hypMore.Text = tabTitle.Rows[0]["Title"].ToString() + " [Status: " + tab.Rows[cnt]["Status"].ToString() + "]"; ;

                        hypMore.NavigateUrl = string.Format("AnswerDetails.aspx?answerId={0}", tab.Rows[cnt]["AnswerId"].ToString());
                        cell_comment.Controls.Add(hypMore);
                        row1.Controls.Add(cell_comment);
                    }

                    TableRow row2 = new TableRow();

                    TableCell row2Cell1 = new TableCell();
                    row2Cell1.Text = " ";
                    row2.Controls.Add(row2Cell1);

                    TableCell row2Cell2 = new TableCell();
                    row2Cell2.Text = "<br/>";
                    row2.Controls.Add(row2Cell2);

                    TableRow row3 = new TableRow();

                    TableCell row3cell1 = new TableCell();
                    row3cell1.Text = " ";
                    row3.Controls.Add(row3cell1);

                    DataTable tab50 = new DataTable();
                    tab50.Rows.Clear();

                    tab50 = obj.GetMemberById(int.Parse(tab.Rows[cnt]["MemberId"].ToString()));
                    TableCell row3cell2 = new TableCell();
                    row3cell2.Text = "Posted By : " + tab50.Rows[0]["FName"].ToString() + " ," + "Posted Date : " + tab.Rows[cnt]["PostedDate"].ToString() + "<br/>";
                    row3.Controls.Add(row3cell2);

                    TableRow row10 = new TableRow();

                    TableCell row10cell1 = new TableCell();
                    row10cell1.ColumnSpan = 10;
                    row10cell1.Width = 900;
                    row10cell1.Text = "<hr/>";
                    row10.Controls.Add(row10cell1);

                    tableAnswers.Controls.Add(row1);
                    tableAnswers.Controls.Add(row2);
                    tableAnswers.Controls.Add(row3);
                    tableAnswers.Controls.Add(row10);
                }
            }
            else
            {
                tableAnswers.Rows.Clear();

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();

                cell.ForeColor = System.Drawing.Color.Red;
                cell.Text = "No Answers Found";
                row.Controls.Add(cell);

                tableAnswers.Controls.Add(row);

            }
        }

        protected void btnAnswer_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("PostAnswer.aspx?questionId={0}", Request.QueryString["QuestionId"].ToString()));
        }

     
    }
}