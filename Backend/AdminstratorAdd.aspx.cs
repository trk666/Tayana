using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;
using System.Data;

namespace tayanaBackend.Backend
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();//取得副檔名並轉成小寫

                string[] allowExtension = { ".jpg", ".png", ".gif", };//宣告一個陣列，內容為符合的副檔名

                bool fileOk = false;
                int j = 0;
                for (int i = 0; i < allowExtension.Length; i++)//判斷檔案的副檔名
                {
                    if (fileExtension == allowExtension[i])
                    {
                        fileOk = true;
                        break;//有true就可以出來了
                    }
                }
                if (fileOk)//判斷成功的話才會進這個
                {
                    string filename = FileUpload1.FileName;//取出upload裡的檔名
                    string Path = Server.MapPath("~/Backend/img/user/");//指定想放圖片的資料夾路徑
                    string save = Path + filename;//宣告完整路徑
                    FileUpload1.SaveAs(save);//圖檔傳至指定資料夾

                    GOsql(filename);
                }
                else
                {
                    PictureFormatError.Visible = true;
                }
            }
            else
            {
                GOsql("avatardefault_92824.png");
            }
        }

        public void GOsql(string photoName)
        {
            authority.Text = GetCheckboxStringArray(authoritylist);//用函數取出的值放入隱藏格內來寫進sql

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string psw = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"); //(加密密碼)

            SqlCommand command = new SqlCommand($"INSERT INTO administrator(account, userName, password, mail, photo, Authority)" +
                                                $"VALUES  (@account,@userName,@password,@mail,@photo,@Authority)", connect);

            command.Parameters.AddWithValue("@account", account.Text);
            command.Parameters.AddWithValue("@userName", userName.Text);
            command.Parameters.AddWithValue("@password", psw);
            command.Parameters.AddWithValue("@mail", email.Text);
            command.Parameters.AddWithValue("@photo", photoName);
            command.Parameters.AddWithValue("@Authority", authority.Text);


            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("AdminstratorsAll.aspx");
        }

        public string GetCheckboxStringArray(CheckBoxList list)//取得權限的值
        {
            string authority = "";
            foreach (ListItem item in list.Items)
            {
                if (item.Selected == true)
                {
                    if (authority.Length > 0)
                    {
                        authority += ",";
                    }
                    authority += item.Value;
                }
            }
            return authority;
        }
    }
}