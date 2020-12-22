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
    public partial class WebForm3 : System.Web.UI.Page
    {
        private const int PageSize = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getLeft();
                string path = Request.Url.PathAndQuery;
                if (path == "/dealers.aspx")
                {
                    //如果沒有id=1就會報錯
                    int id = 1;
                    getTop(id);
                    getContent(id);
                }
                else
                {
                    if (Request.QueryString["id"] == null)
                    {
                        int id = Convert.ToInt32(Session["countryID"]);
                        getTop(id);
                        getContent(id);
                    }
                    else
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        getTop(id);
                        getContent(id);
                    }

                }
            }
        }

        private void getLeft()
        {
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlstring = "SELECT  * FROM country";

            SqlCommand getsql = new SqlCommand(sqlstring, connect);

            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(getsql);
            DataTable table = new DataTable();
            adapter.Fill(table);
            LeftList.DataSource = table;
            LeftList.DataBind();
        }

        private void getTop(int id)
        {
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            //string sqlstring = "SELECT  country.country, area.countryID, area.area, dealer.areaID, dealer.photo, dealer.dealer, country.id, area.id AS Expr1,dealer.id AS Expr2 " +
            //    "FROM area INNER JOIN country ON area.countryID = country.id INNER JOIN dealer ON area.id = dealer.areaID";
            string sqlstring = "SELECT  * FROM country";

            string sqlsearch = " where id = @id";

            SqlCommand getsql = new SqlCommand(sqlstring + sqlsearch, connect);
            getsql.Parameters.AddWithValue("@id", id);

            //塞目前國家
            string cc = "";

            connect.Open();
            SqlDataReader reader = getsql.ExecuteReader();
            if (reader.Read())
            {
                cc = reader["country"].ToString();
            }
            connect.Close();
            CurrentCountry01.Text = cc;
            CurrentCountry02.Text = cc;

            Session["countryID"] = id;

            ////塞經銷商
            //connect.Open();
            //SqlDataAdapter adapter = new SqlDataAdapter(getsql);
            //DataTable table = new DataTable();
            //adapter.Fill(table);
            //Dealers.DataSource = table;
            //Dealers.DataBind();
        }

        private void getContent(int id)
        {
            int currentPage = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);


            string sqlsearch = " where countryID = @countryID";
            string sqlstring = $@"with newsList as
                (SELECT  row_number() over(order by country.id asc) as rownumber, area.countryID, country.country, area.area, dealer.areaID, dealer.photo, dealer.dealer, dealer.id as dealerID
            FROM      area INNER JOIN
            country ON area.countryID = country.id INNER JOIN
            dealer ON area.id = dealer.areaID{sqlsearch})
            select* from newsList";
            string sqlpage =" where rownumber >= @start and rownumber <= @end";

            SqlCommand getsql = new SqlCommand(sqlstring + sqlpage, connect);
            getsql.Parameters.AddWithValue("@countryID", id);

            getsql.Parameters.Add("@start", SqlDbType.Int);
            getsql.Parameters["@start"].Value = ((currentPage - 1) * PageSize) + 1;
            getsql.Parameters.Add("@end", SqlDbType.Int);
            getsql.Parameters["@end"].Value = currentPage * PageSize;

            SqlDataAdapter adapter = new SqlDataAdapter(getsql);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Dealers.DataSource = table;
            Dealers.DataBind();

            //產分頁
            string page = @"area INNER JOIN
            country ON area.countryID = country.id INNER JOIN
            dealer ON area.id = dealer.areaID";
            string pagecount = " where country.id=@id ";

            SqlCommand totalcommand = new SqlCommand($@"select count(*) from {page} "+pagecount, connect);
            totalcommand.Parameters.AddWithValue("@id",id);
            SqlDataAdapter totalAdapter = new SqlDataAdapter(totalcommand);
            DataTable totalTable = new DataTable();
            totalAdapter.Fill((totalTable));
            int total = Convert.ToInt32(totalTable.Rows[0][0]);

            Pagination.totalitems = total;
            Pagination.limit = PageSize;
            Pagination.targetpage = "dealers.aspx";
            Pagination.showPageControls();
        }
    }
}