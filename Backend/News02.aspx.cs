using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class WebForm12 : System.Web.UI.Page
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
                    Response.Redirect("News01.aspx");
                }

            }
        }

        private void getSql()
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
                title.Text = reader["title"].ToString();
                article.Text = reader["article"].ToString();
            }
            connect.Close();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("NewsEdit.aspx?id=" + $"{id}");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection delete = new SqlConnection(connectstring);

            SqlCommand deleteCommand = new SqlCommand("DELETE FROM news WHERE   (id = @id )", delete);
            deleteCommand.Parameters.AddWithValue("@id", id);
            delete.Open();
            deleteCommand.ExecuteNonQuery();
            delete.Close();

            Response.Redirect("News01.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("News01.aspx");
        }
    }
}