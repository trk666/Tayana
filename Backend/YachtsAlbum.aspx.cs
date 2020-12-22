using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Visible = false;
                Label3.Visible = false;
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("Yachts.aspx");
                }
                else
                {
                    getCover();
                    getsql();
                }

            }
        }
        private void getCover()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlstring = "SELECT  * FROM yachtsDetails";
            string sqlsearch = " where detailID=@detailID";

            SqlCommand getsql = new SqlCommand(sqlstring + sqlsearch, connect);
            getsql.Parameters.AddWithValue("@detailID", id);

            connect.Open();
            SqlDataReader reader = getsql.ExecuteReader();
            if (reader.Read())
            {
                Image1.ImageUrl = @"~\images\yachts\" + reader["photo"];
                HiddenField3.Value = reader["photo"].ToString();
            }

            getsql.Cancel();
            reader.Close();
            connect.Close();
            connect.Dispose();
        }

        private void getsql()
        {
            int detailID = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connectstring);

            string sqlstring = "SELECT  *FROM yachtsPhoto";
            string sqlsearch = " where detailID=@detailID";
            string sqlorder = " order by date desc";

            SqlCommand cmd = new SqlCommand(sqlstring + sqlsearch + sqlorder, conn);
            cmd.Parameters.AddWithValue("@detailID", detailID);

            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Repeater1.DataSource = table;
            Repeater1.DataBind();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload.FileName).ToLower(); //取得副檔名並轉成小寫

                string[] allowExtension = {".gif", ".png", ".jpeg", ".jpg", ".bmp"}; //宣告一個陣列，內容為符合的副檔名

                bool fileOk = false;

                for (int i = 0; i < allowExtension.Length; i++) //判斷檔案的副檔名
                {
                    if (fileExtension == allowExtension[i])
                    {
                        fileOk = true;
                        break; //有true就可以出來了
                    }
                }

                if (fileOk == true)
                {
                    string filename = FileUpload.FileName;
                    filename = DateTime.Now.ToString("yyyyMMdd") + "_" + filename; //加上前墜時間
                    string Path = Server.MapPath(@"~\images\yachts\");
                    string save = Path + filename;

                    //存進原圖
                    FileUpload.SaveAs(save);

                    //從路徑找剛剛存進的圖縮小後再存
                    GenerateThumbnailImage(filename, Path, Path, "s_", 63);

                    gosql(filename);

                    getsql();
                }

            }
            else
            {
                Label1.Text = "未選擇檔案";
                Label1.Visible = true;
            }
        }

        /// <summary>
        /// 舉世無敵縮圖程式(指定高度，等比例縮小)
        /// </summary>
        /// <param name="name">原檔檔名</param>
        /// <param name="source">來源路徑</param>
        /// <param name="target">目的路徑</param>
        /// <param name="suffix">縮圖辯識符號</param>
        /// <param name="MaxHight">指定要縮的高度</param>
        /// <remarks></remarks>
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (changePhoto.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(changePhoto.FileName).ToLower(); //取得副檔名並轉成小寫

                string[] allowExtension = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" }; //宣告一個陣列，內容為符合的副檔名

                bool fileOk = false;

                for (int i = 0; i < allowExtension.Length; i++) //判斷檔案的副檔名
                {
                    if (fileExtension == allowExtension[i])
                    {
                        fileOk = true;
                        break; //有true就可以出來了
                    }
                }

                if (fileOk == true)
                {
                    //string filename = changePhoto.FileName;
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff"); //完全用時間
                    string Path = Server.MapPath(@"~\images\yachts\");
                    string save = Path + filename;

                    //存進原圖
                    changePhoto.SaveAs(save);

                    //從路徑找剛剛存進的圖縮小後再存
                    GenerateThumbnailImage(filename, Path, Path, "s_", 63);
                    
                    goCover(filename);
                    getCover();
                }
            }
            else
            {
                Label3.Text = "未上傳新圖，沿用舊圖";
                goCover(HiddenField3.Value);
                getCover();
            }
        }
        public void gosql(string filename)
        {
            int detailID = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connectstring);

            string sqlstring = "INSERT INTO yachtsPhoto(detailID, img)VALUES  (@detailID,@img)";

            SqlCommand cmd = new SqlCommand(sqlstring, conn);
            cmd.Parameters.AddWithValue("@img", filename);
            cmd.Parameters.AddWithValue("@detailID", detailID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            getsql();
        }

        private void goCover(string filename)
        {
            int detailID = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connectstring);

            string sqlstring = @"UPDATE  yachtsDetails
            SET photo = @photo
                where detailID = @detailID";

            SqlCommand cmd = new SqlCommand(sqlstring, conn);
            cmd.Parameters.AddWithValue("@photo", filename);
            cmd.Parameters.AddWithValue("@detailID", detailID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            getsql();
        }


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int photoID = Convert.ToInt32(e.CommandArgument);

            string casename = e.CommandName;

            switch (casename)
            {
                case "photo":
                    Response.Redirect("YachtsPhoto.aspx?id=" + photoID);
                    break;
                case "delete":
                    string connectstring =
                        WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                    SqlConnection conn = new SqlConnection(connectstring);

                    string sqlstring = "DELETE FROM yachtsPhoto";
                    string sqlsearch = " where photoID=@photoID";

                    SqlCommand cmd = new SqlCommand(sqlstring + sqlsearch, conn);
                    cmd.Parameters.AddWithValue("@photoID", photoID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    getsql();
                    break;
            }
        }

    }
}