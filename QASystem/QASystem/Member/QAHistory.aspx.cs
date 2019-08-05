﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QASystem.Member
{
    public partial class QAHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["MemberId"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Visitor/SignIn.aspx");
                }
                else
                {
                    GetQuestions();
                }
            }
            catch
            {

            }
        }
                     
        //function to retrive questions
        public void GetQuestions()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab.Rows.Clear();
            tab = obj.GetQAByMemberId(int.Parse(Session["MemberId"].ToString()));
            
            int serialNo = 1;

            if (tab.Rows.Count > 0)
            {
                tableQA.Rows.Clear();

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row1 = new TableRow();

                    DataTable tabQuestion = new DataTable();
                    tabQuestion = obj.GetQuestionById(int.Parse(tab.Rows[cnt]["QuestionId"].ToString()));

                    TableCell row1_cell1 = new TableCell();
                    row1_cell1.Font.Size = 10;
                    row1_cell1.Text = cnt + serialNo + ".";
                    row1.Controls.Add(row1_cell1);

                    TableCell cell_topic = new TableCell();
                    //cell_topic.Width = 750;
                    HyperLink li = new HyperLink();
                    li.ID = tab.Rows[cnt]["QuestionId"].ToString();
                    li.Text = tabQuestion.Rows[0]["Question"].ToString();
                    li.NavigateUrl = string.Format("Answers.aspx?Question={0}&QuestionId={1}", tabQuestion.Rows[0]["Question"].ToString(), tab.Rows[cnt]["QuestionId"].ToString());
                    cell_topic.Controls.Add(li);
                    row1.Controls.Add(cell_topic);

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

                    tab50 = obj.GetMemberById(int.Parse(tabQuestion.Rows[0]["MemberId"].ToString()));
                    TableCell row3cell2 = new TableCell();
                    row3cell2.Text = "Posted By : " + tab50.Rows[0]["FName"].ToString() + " ," + "Posted Date : " + tabQuestion.Rows[0]["PostedDate"].ToString() + "<br/>";
                    row3.Controls.Add(row3cell2);

                    TableRow row10 = new TableRow();

                    TableCell row10_cell1 = new TableCell();
                    row10_cell1.ColumnSpan = 10;
                    row10_cell1.Width = 900;
                    row10_cell1.Text = "<hr/>";
                    row10.Controls.Add(row10_cell1);

                    tableQA.Controls.Add(row1);
                    tableQA.Controls.Add(row2);
                    tableQA.Controls.Add(row3);
                    tableQA.Controls.Add(row10);

                }

            }
            else
            {
                tableQA.Rows.Clear();

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ForeColor = System.Drawing.Color.Red;



                cell.Text = "No Questions Found";


                row.Controls.Add(cell);
                tableQA.Controls.Add(row);

            }
        }

        
    }
}