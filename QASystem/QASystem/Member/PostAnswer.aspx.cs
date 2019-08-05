using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections;

namespace QASystem.Member
{
    public partial class PostAnswer : System.Web.UI.Page
    {
        static HttpFileCollection hfcFiles = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    rbtnText.Checked = true;
                    PanelText.Visible = true;
                    LoadNumbers();                   
                }               
            }
            catch
            {

            }
        }

        //function to load numbers
        private void LoadNumbers()
        {
            DropDownListPhotoNumber.Items.Clear();

            for (int i = 1; i <= 10; i++)
            {
                DropDownListPhotoNumber.Items.Add(i.ToString());
            }

            DropDownListPhotoNumber.Items.Insert(0, "Select");
        }

        //function to load textboxes in to gridview
        private void LoadGridview()
        {
            DataTable tabVideo = new DataTable();

            tabVideo.Columns.Add("SerialNo");

            for (int i = 1; i <= 10; i++)
            {
                DataRow row = tabVideo.NewRow();

                row["SerialNo"] = "Video" + i + ":";
                tabVideo.Rows.Add(row);
            }

            GridView1.DataSource = tabVideo;
            GridView1.DataBind();
        }

        #region ---- Text Messages ----

        //click event to share text essage
        protected void btnText_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            obj.InsertAnswer(int.Parse(Request.QueryString["questionId"].ToString()),int.Parse(Session["MemberId"].ToString()), "Text", DateTime.Now, "DeActive");

            int maxId = obj.GetMaxAnswerId();

            obj.InsertText(maxId, txtTextTitle.Text);

            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Answer Posted Successfully!!!')</script>");
            ClearTextboxContents();           
        }

        //function to clear the textbox contents
        private void ClearTextboxContents()
        {
            txtTextTitle.Text = string.Empty;           
            txtPhotoDescription.Text = string.Empty;            
            txtVideoDescription.Text = string.Empty;
           
            LoadGridview();
        }

        #endregion

        #region ---- Photos ----

        protected void btnUploadPhotos_Click(object sender, EventArgs e)
        {
            string fullpath = null;

            BLL obj = new BLL();

            if (DropDownListPhotoNumber.SelectedIndex > 0)
            {
                if (CheckPhotos())
                {
                    obj.InsertAnswer(int.Parse(Request.QueryString["questionId"].ToString()), int.Parse(Session["MemberId"].ToString()), "Photo", DateTime.Now, "DeActive");

                    int maxId = obj.GetMaxAnswerId();
                    hfcFiles = Request.Files;

                   

                    
                    for (int i = 0; i < hfcFiles.Count; i++)
                    {
                        int photoId = 0;

                        try
                        {
                            photoId = obj.GetMaxPhotoId();

                            ++photoId;
                        }
                        catch
                        {
                            photoId = 1;
                        }

                        HttpPostedFile file = hfcFiles[i];
                        string strExtension = Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("~/Member/Photos/" + photoId + strExtension));

                        fullpath = "~/Member/Photos/" + photoId + strExtension;

                        obj.InsertPhoto(maxId, txtPhotoDescription.Text, fullpath);
                    }
                    
                    ClearTextboxContents();
                    LoadNumbers();

                    Table1.Rows.Clear();
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Photos Uploaded Successfully!!!')</script>");

                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Upload Photos')</script>");
                }


            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Please Select Content Type and Number of Photos to Upload!!!')</script>");
            }

        }

        private bool CheckPhotos()
        {
            hfcFiles = Request.Files;

            for (int j = 0; j < hfcFiles.Count; j++)
            {
                HttpPostedFile file = hfcFiles[j];

                if (file.FileName.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        protected void DropDownListPhotoNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int serialNo = 1;

            if (DropDownListPhotoNumber.SelectedIndex > 0)
            {
                Table1.Rows.Clear();

                Table1.BorderStyle = BorderStyle.Double;
                Table1.GridLines = GridLines.Both;
                Table1.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                //#bbd142
                headerrow.BackColor = System.Drawing.Color.Gray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SL No</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Upload Photo</b>";
                headerrow.Controls.Add(cell2);

                Table1.Controls.Add(headerrow);

                for (int i = 0; i < int.Parse(DropDownListPhotoNumber.SelectedValue.ToString()); i++)
                {
                    TableRow row = new TableRow();

                    TableCell row1_cell1 = new TableCell();
                    row1_cell1.Font.Size = 10;
                    int slNo = i + serialNo;
                    row1_cell1.Text = "Photo " + slNo + ".";
                    row.Controls.Add(row1_cell1);

                    FileUpload file_up = new FileUpload();
                    file_up.ID = i.ToString();
                    file_up.Width = 175;

                    RequiredFieldValidator req = new RequiredFieldValidator();
                    req.ID = i.ToString();
                    req.ControlToValidate = file_up.ID;
                    req.ErrorMessage = "*";
                    req.ValidationGroup = "upload";

                    TableCell cellPhoto = new TableCell();
                    cellPhoto.Controls.Add(file_up);
                    row.Controls.Add(cellPhoto);

                    Table1.Controls.Add(row);

                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Select Number!!!')</script>");
            }
        }

        #endregion

        #region ---- Video ----

        private bool CheckVideos()
        {
            int i = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("CheckBox1");
                TextBox txt = (TextBox)row.FindControl("TextBox1");

                if (ch.Checked)
                {
                    if (txt.Text.Equals(""))

                        return false;

                    ++i;
                }

            }

            if (i == 0)

                return false;

            return true;
        }

        protected void btnUploadVideos_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (CheckVideos())
            {
                obj.InsertAnswer(int.Parse(Request.QueryString["questionId"].ToString()), int.Parse(Session["MemberId"].ToString()), "Video", DateTime.Now, "DeActive");

                int maxId = obj.GetMaxAnswerId();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox ch = (CheckBox)row.FindControl("CheckBox1");
                    TextBox txt = (TextBox)row.FindControl("TextBox1");

                    if (ch.Checked)
                    {
                        obj.InserVideo(maxId, txtVideoDescription.Text, txt.Text);
                    }

                }

                LoadNumbers();
                ClearTextboxContents();
               
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Videos Shared Successfully!!!')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Upload Videos')</script>");
            }

        }


        protected void rbtnText_CheckedChanged(object sender, EventArgs e)
        {
            PanelText.Visible = true;
            PanelPhotos.Visible = false;
            PanelVideos.Visible = false;
        }

        protected void rbtnPhotos_CheckedChanged(object sender, EventArgs e)
        {
            PanelText.Visible = false;
            PanelPhotos.Visible = true;
            PanelVideos.Visible = false;
        }

        protected void rbtnVideos_CheckedChanged(object sender, EventArgs e)
        {
            PanelText.Visible = false;
            PanelPhotos.Visible = false;
            PanelVideos.Visible = true;
            LoadGridview();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("CheckBox1");
                TextBox txt = (TextBox)row.FindControl("TextBox1");

                if (ch.Checked)
                {
                    txt.Visible = true;
                }
                else
                {
                    txt.Visible = false;
                }
            }

        }


        #endregion

    }
}