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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Visible = false;
                Label2.Visible = false;

            }
        }
        protected void TypeList_Init(object sender, EventArgs e)
        {
            TypeList.Items.Clear();
            TypeList.Items.Add("現有船型");

            string sqlstring = "SELECT  *FROM yachts";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand getsql = new SqlCommand(sqlstring, connect);

            string allType = ",";


            connect.Open();
            SqlDataReader reader = getsql.ExecuteReader();
            while (reader.Read())
            {
                TypeList.Items.Add(new ListItem(reader["type"].ToString(), reader["id"].ToString()));
                allType += reader["type"] + ",";
            }
            getsql.Cancel();
            reader.Close();
            connect.Close();
            connect.Dispose();

            HiddenField1.Value = allType;
        }

        protected void TypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialList.Items.Clear();
            SerialList.Items.Add("瀏覽現有型號");

            if (TypeList.SelectedValue == "現有船型")
            {
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                TypeSerial();
            }
        }


        private void TypeSerial()
        {
            int typeID = Convert.ToInt32(TypeList.SelectedValue);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlstring = "SELECT  * FROM yachtsDetails";
            string sqlsearch = " where typeID=@typeID";

            SqlCommand getsql = new SqlCommand(sqlstring + sqlsearch, connect);
            getsql.Parameters.AddWithValue($"@typeID", typeID);

            string typeSerial = ",";

            connect.Open();
            SqlDataReader reader = getsql.ExecuteReader();
            while (reader.Read())
            {
                SerialList.Items.Add(new ListItem(reader["serial"].ToString(), reader["detailID"].ToString()));
                typeSerial += reader["serial"] + ",";
            }
            getsql.Cancel();
            reader.Close();
            connect.Close();
            connect.Dispose();

            HiddenField2.Value = typeSerial;
        }

        protected void SubmitType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TypeEdit.Text))
            {
                Label1.Visible = true;
                Label1.Text = "請輸入新船型";
            }
            else if (HiddenField1.Value.IndexOf("," + TypeEdit.Text + ",", StringComparison.OrdinalIgnoreCase) > -1)
            {
                Label1.Visible = true;
                Label1.Text = "已有重複船型";
            }
            else
            {
                string sqlstring = "INSERT INTO yachts(type)VALUES  (@type)";

                string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                SqlConnection connect = new SqlConnection(connectstring);

                SqlCommand gosql = new SqlCommand(sqlstring, connect);
                gosql.Parameters.AddWithValue("@type", TypeEdit.Text);

                connect.Open();
                gosql.ExecuteNonQuery();
                connect.Close();
                Response.Redirect(Request.Url.ToString());
            }
        }
        protected void SubmitSerial_Click(object sender, EventArgs e)
        {
            if (TypeList.SelectedValue == "現有船型")
            {
                Label2.Visible = true;
                Label2.Text = "未選擇船型";
            }
            else
            {
                TypeSerial();
                if (string.IsNullOrEmpty(SerialEdit.Text))
                {
                    Label2.Visible = true;
                    Label2.Text = "請輸入型號";
                }
                else if (HiddenField2.Value.IndexOf("," + SerialEdit.Text + ",", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    Label2.Visible = true;
                    Label2.Text = "此船型已有相同型號";
                }
                else if (RadioButtonList1.SelectedItem == null)
                {
                    Label2.Text = "請選擇是否為最新型";
                    Label2.Visible = true;
                }
                else
                {
                    if (FileUpload1.HasFile)
                    {
                        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower(); //取得副檔名並轉成小寫

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
                            string filename = FileUpload1.FileName;
                            filename = DateTime.Now.ToString("yyyyMMdd") + "_" + filename;//加上前墜時間
                            string Path = Server.MapPath(@"~\images\yachts\");
                            string save = Path + filename;

                            //存進原圖
                            FileUpload1.SaveAs(save);

                            //從路徑找剛剛存進的圖縮小後再存
                            GenerateThumbnailImage(filename, Path, Path, "s_", 63);

                            gotoSQL(filename);
                           
                        }

                    }
                    else
                    {
                        Label2.Visible = true;
                        Label2.Text = "缺少首頁圖片";
                    }
                }

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
        static public void GenerateThumbnailImage(string name, string source, string target, string suffix, int MaxHight)
        {
            
            System.Drawing.Image baseImage = System.Drawing.Image.FromFile(source + name);
            Single ratio = 0.0F;//存放縮圖比例
            Single h = baseImage.Height; //圖像原尺寸高度
            Single w = baseImage.Width;  //圖像原尺寸寬度
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

        private void gotoSQL(string filename)
        {
            int typeID = Convert.ToInt32(TypeList.SelectedValue);
            string sqlstring = "INSERT INTO yachtsDetails(typeID, serial, newest, photo)VALUES  (@typeID,@serial,@newest,@photo)";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand gosql = new SqlCommand(sqlstring, connect);
            gosql.Parameters.AddWithValue("@typeID", typeID);
            gosql.Parameters.AddWithValue("@serial", SerialEdit.Text);
            gosql.Parameters.AddWithValue("@newest", RadioButtonList1.SelectedValue);
            gosql.Parameters.AddWithValue("@photo", filename);


            connect.Open();
            gosql.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("Yachts.aspx");
        }

    }
}