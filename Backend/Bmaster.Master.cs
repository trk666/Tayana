using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Page.User.Identity.IsAuthenticated)//沒票就踢回登陸頁
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    string userdata = ((FormsIdentity)Page.User.Identity).Ticket.UserData;
                    string[] array = userdata.Split(',');
                    CurrentUser.Text = array[0];//目前使用者姓名
                    
                    //CurrentPage

                    //摳驗證function(sql欄位驗證碼,比對網址用的字串,左側列表id)
                    Identity("01", "Yachts", yachts,"船隻管理");
                    Identity("02", "News", news,"新聞管理");
                    Identity("03", "Dealer", dealers,"經銷商管理");
                    Identity("04", "Adminstrator", alladmin,"後台人員");

                }
            }
        }


        public void Identity(string authority, string nowUrl, HtmlAnchor navigator,string breadcamp)
        {
            //宣告參數接驗證票的userdata
            string userdata = ((FormsIdentity)Page.User.Identity).Ticket.UserData;

            //取得目前頁面網址
            string url = System.IO.Path.GetFileName(Request.PhysicalPath);

            if (userdata.IndexOf(authority) > -1)//userdata裡有對應的驗證碼
            {
                navigator.Visible = true;//顯示左側列表
            }
            if (url.IndexOf(nowUrl) > -1)//檢查網址
            {
                CurrentPage.Text = breadcamp;
                if (userdata.IndexOf(authority) < 0)//userdata裡無對應的驗證碼
                {
                    Response.Redirect("Login.aspx");//導回登入頁面
                }
            }
        }



        protected void LogOut_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

    }

}
