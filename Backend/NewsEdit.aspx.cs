using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    getsql();
                }
                else
                {
                    Response.Redirect("News01.aspx");
                }
            }
        }

        private void getsql()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand getNews = new SqlCommand("SELECT  * FROM news where id=@id", connect);
            getNews.Parameters.AddWithValue("@id", id);

            connect.Open();
            SqlDataReader reader = getNews.ExecuteReader();
            if (reader.Read())
            {
                previewPicture.ImageUrl = @"https://localhost:44358/images/ckf/previewNews/" + reader["previewPicture"];
                title.Text = reader["title"].ToString();
                previewArticle.Text = reader["previewArticle"].ToString();
                article.Text = reader["article"].ToString();
                oldPhoto.Text = reader["previewPicture"].ToString();
                RadioButtonList1.SelectedValue = reader["gettop"].ToString();
            }
            connect.Close();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (previewPictureEdit.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(previewPictureEdit.FileName).ToLower(); //取得副檔名並轉成小寫

                string[] allowExtension = { ".jpg", ".png", ".gif", }; //宣告一個陣列，內容為符合的副檔名

                bool fileOk = false;
                int j = 0;
                for (int i = 0; i < allowExtension.Length; i++) //判斷檔案的副檔名
                {
                    if (fileExtension == allowExtension[i])
                    {
                        fileOk = true;
                        break; //有true就可以出來了
                    }
                }

                if (fileOk)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + fileExtension; //時間+副檔名
                    string Path = Server.MapPath(@"~\images\ckf\previewNews\");
                    string save = Path + filename;
                    previewPictureEdit.SaveAs(save);
                    GenerateThumbnailImage(filename, Path, Path, "s_", 121);


                    GOsql(filename);
                }
            }
            else
            {
                GOsql(oldPhoto.Text);
            }

        }

        protected void NoEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("News01.aspx");
        }

        private void GOsql(string previewPictureFileName)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand newsEdit = new SqlCommand("UPDATE  news SET title =@title, previewArticle =@previewArticle, previewPicture =@previewPicture, article =@article,gettop=@gettop where id =@id", connect);
            newsEdit.Parameters.AddWithValue("@title", title.Text);
            newsEdit.Parameters.AddWithValue("@previewArticle", previewArticle.Text);
            newsEdit.Parameters.AddWithValue("@previewPicture", previewPictureFileName);
            newsEdit.Parameters.AddWithValue("@article", article.Text);
            newsEdit.Parameters.AddWithValue("@gettop", RadioButtonList1.SelectedValue);
            newsEdit.Parameters.AddWithValue("@id", id);

            connect.Open();
            newsEdit.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("News01.aspx");
        }

        static public void GenerateThumbnailImage(string name, string source, string target, string suffix,
            int MaxHight)
        {

            System.Drawing.Image baseImage = System.Drawing.Image.FromFile(source + name);
            Single ratio = 0.0F; //存放縮圖比例
            Single h = baseImage.Height; //圖像原尺寸高度
            Single w = baseImage.Width; //圖像原尺寸寬度
            int ht; //圖像縮圖後高度
            int wt; //圖像縮圖後寬度
            ratio = MaxHight / h; //計算寬度縮圖比例
            if (MaxHight < h)
            {
                ht = MaxHight;
                wt = Convert.ToInt32(ratio * w);

            }
            else
            {
                ht = Convert.ToInt32(baseImage.Height);
                wt = Convert.ToInt32(baseImage.Width);

            }

            string Newname = target + suffix + name;

            System.Drawing.Bitmap img = new System.Drawing.Bitmap(wt, ht);
            System.Drawing.Graphics graphic = Graphics.FromImage(img);
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphic.DrawImage(baseImage, 0, 0, wt, ht);
            img.Save(Newname);

            img.Dispose();
            graphic.Dispose();
            baseImage.Dispose();

        }


    }
}