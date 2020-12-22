using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                SqlConnection connect = new SqlConnection(connectstring);

                string search = "where id = @id";
                SqlCommand command = new SqlCommand($"SELECT  * FROM administrator {search}", connect);
                command.Parameters.AddWithValue("@id", id);

                connect.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HiddenField1.Value = reader["photo"].ToString();
                    Photo.ImageUrl = "https://localhost:44358/Backend/img/user/" + reader["photo"];
                    account.Text = reader["account"].ToString();
                    password.Text = reader["password"].ToString();
                    userName.Text = reader["userName"].ToString();
                    email.Text = reader["mail"].ToString();
                    SqlToCheckboxlist(reader["Authority"].ToString());
                }
            }

        }

        public void SqlToCheckboxlist(string Authority)//變數:sql裡面的那串
        {
            //比對checkboxlist裡面的每個選項，所以全選方塊請拉一個放在外面
            foreach (ListItem authoritylistItem in authoritylist.Items)
            {
                //如果 "sql裡面那串" 之中有 "checkboxlist裡該選項的值"
                if (Authority.IndexOf(authoritylistItem.Value) > -1)
                {
                    authoritylistItem.Selected = true;//該值的勾勾盒就勾起來
                }
            }
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
                GOsql(HiddenField1.Value);
            }

        }
        public void GOsql(string photoName)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            authority.Text = GetCheckboxStringArray(authoritylist);//用函數取出的值放入隱藏格內來寫進sql

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string psw = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"); //(加密密碼)

            string command = "UPDATE  administrator SET account =@account, userName =@userName, password =@password, mail =@mail, photo =@photo, Authority =@Authority where id=@id";
            SqlCommand edit = new SqlCommand(command, connect);

            edit.Parameters.AddWithValue("@account", account.Text);
            edit.Parameters.AddWithValue("@userName", userName.Text);
            edit.Parameters.AddWithValue("@password", psw);
            edit.Parameters.AddWithValue("@mail", email.Text);
            edit.Parameters.AddWithValue("@photo", photoName);
            edit.Parameters.AddWithValue("@Authority", authority.Text);
            edit.Parameters.AddWithValue("@id", id);

            connect.Open();
            edit.ExecuteNonQuery();
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