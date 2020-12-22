using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    getSql();
                }
                else
                {
                    Response.Redirect("news01.aspx");
                }
            }

        }

        private void getSql()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand getNews = new SqlCommand("SELECT  id, date, title, previewArticle, previewPicture,REPLACE( replace(article,'<p>',''),'</p>','') as article FROM news where id=@id", connect);
            getNews.Parameters.AddWithValue("@id", id);

            connect.Open();
            SqlDataReader reader = getNews.ExecuteReader();
            if (reader.Read())
            {
                title.Text = reader["title"].ToString();
                article.Text = reader["article"].ToString();
            }
            connect.Close();
        }
    }
}