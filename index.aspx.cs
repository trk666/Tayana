using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPhoto();
                getNews();
            }
        }
        private void getPhoto()
        {
            string sqlstring = @"SELECT  top 5 yd.date,y.type,yd.detailID,yd.serial,yd.newest,yd.photo,yd.date
FROM      yachts as y INNER JOIN
                   yachtsDetails as yd ON y.id = yd.typeID
				   order by newest desc";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand ship = new SqlCommand(sqlstring, connect);
            SqlDataAdapter shipAdapter = new SqlDataAdapter(ship);
            DataTable shipTable = new DataTable();
            shipAdapter.Fill(shipTable);
            RepeaterPhoto.DataSource = shipTable;
            RepeaterPhoto.DataBind();
            RepeaterScale.DataSource = shipTable;
            RepeaterScale.DataBind();
        }

        private void getNews()
        {
            string sqlstring = @"SELECT  TOP (3) id,gettop,  date, title, previewArticle, previewPicture, article
FROM      news
order by gettop desc,[date] desc";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand news = new SqlCommand(sqlstring, connect);
            SqlDataAdapter newsAdapter = new SqlDataAdapter(news);
            DataTable newsTable = new DataTable();
            newsAdapter.Fill(newsTable);
            RepeaterNews.DataSource = newsTable;
            RepeaterNews.DataBind();
        }

        public string New(object newest)
        {
            string newOrNot = Convert.ToString(newest);

            if (newOrNot == "1")
            {
                return "";
            }
            else
            {
                return "display: none;";
            }
        }
    }
}