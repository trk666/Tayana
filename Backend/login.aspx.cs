using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;

namespace tayanaBackend.Backend
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Page.User.Identity.IsAuthenticated)
                //{
                //    FormsAuthentication.SignOut();
                //}

            }
        }


        void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立Cookie
            HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authenticationcookie.Expires = DateTime.Now.AddHours(3);//票的時間和cookie的時間都要注意
            //將Cookie寫入回應
            Response.Cookies.Add(authenticationcookie);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string psw = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Value, "MD5");

            SqlCommand login = new SqlCommand($"SELECT  *FROM      administrator WHERE(account = @account) AND (password = @psw)", connect);
            login.Parameters.AddWithValue("@account", account.Value);
            login.Parameters.AddWithValue("@psw", psw);

            connect.Open();
            SqlDataReader reader = login.ExecuteReader();
            if (!reader.Read())
            {
                Label1.Visible = true;
                Label1.Text = "帳號或密碼錯誤";
                connect.Close();
            }
            else
            {
                SetAuthenTicket($"{reader["userName"]},{reader["mail"]},{reader["photo"]},{reader["Authority"]}", account.ToString());
                connect.Close();
                Response.Redirect("Profile.aspx");
            }
        }
    }
}