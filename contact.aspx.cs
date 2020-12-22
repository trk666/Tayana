using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getcountry();
                getship();
            }
        }

        private void getcountry()
        {
            string sqlstring = "select * from country";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand country = new SqlCommand(sqlstring, connect);
            connect.Open();
            SqlDataReader reader = country.ExecuteReader();
            while (reader.Read())
            {
                CountryList.Items.Add(new ListItem(reader["country"].ToString(), reader["id"].ToString()));
            }
            connect.Close();
            connect.Dispose();
        }
        private void getship()
        {
            string sqlstring = @"SELECT  y.type, yd.serial, yd.detailID,case (yd.newest) when 1 then '(New Building)' else '' end as NEW
FROM      yachts as y INNER JOIN
                   yachtsDetails as yd ON y.id = yd.typeID";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand country = new SqlCommand(sqlstring, connect);
            connect.Open();
            SqlDataReader reader = country.ExecuteReader();
            while (reader.Read())
            {
                YachtsList.Items.Add(new ListItem(reader["type"].ToString() + " " + reader["serial"].ToString() + " " + reader["NEW"].ToString(), reader["detailID"].ToString()));
            }
            connect.Close();
            connect.Dispose();
        }


        public bool SendEmail(string sender)
        {
            //給予信件樣板
            string body = File.ReadAllText(Server.MapPath("/MailFrom.html"));
            //用填選的值取代樣板
            body = body.Replace("@Name", txtName.Value).Replace("@Email", txtEmail.Value).Replace("@Phone", txtPhone.Value)
                .Replace("@Country", CountryList.SelectedItem.Text).Replace("@Yachts", YachtsList.SelectedItem.Text).Replace("@Comments", txtComments.Value.Replace("\r","<br>"));

            try
            {
                //寄件人
                MailAddress from = new MailAddress("skysixTest@gmail.com", "SENDER: ");
                //收件人,可多人 
                MailAddress to = new MailAddress("skysixTest@gmail.com");
                MailMessage message = new MailMessage(from, to);

                message.Subject = $"An email from {sender}";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = body/* MessageBody*/;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true; //if it's html

                //msg.Attachments.Add(new Attachment(@"D:\test2.docx"));  //attachment
                //msg.Priority = MailPriority.High; 



                //設定smtp sever及port
                SmtpClient myMail = new SmtpClient("smtp.gmail.com", 587);
                myMail.Credentials = new System.Net.NetworkCredential("skysixTest@gmail.com", "rockmanx"); //填入帳密
                myMail.EnableSsl = true; //ssl打開，寄信時加密(gmail預設開啟驗證)

                myMail.Send(message);
                myMail.Dispose(); //傳送結束訊息給smtp
                message.Dispose(); //釋放Mailmessage所使用的所有資源

                return true; //成功


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SendEmail(txtName.Value);
        }

    }
}
 