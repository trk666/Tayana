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
    public partial class WebForm6 : System.Web.UI.Page
    {
        private const int PageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
            }
        }
        private void show()
        {
            int currentPage = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            string commandstring = $@"with newsList as (select row_number() over(order by date desc) as rownumber,* from news)select *from newsList where rownumber>=@start and rownumber <=@end";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            SqlCommand allnews = new SqlCommand(commandstring, connect);

            allnews.Parameters.Add("@start", SqlDbType.Int);
            allnews.Parameters["@start"].Value = ((currentPage - 1) * PageSize) + 1;
            allnews.Parameters.Add("@end", SqlDbType.Int);
            allnews.Parameters["@end"].Value = currentPage * PageSize;


            SqlDataAdapter adapter = new SqlDataAdapter(allnews);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Repeater1.DataSource = table;
            Repeater1.DataBind();

            SqlCommand totalcommand = new SqlCommand($@"select count(*) from news", connect);
            SqlDataAdapter totalAdapter = new SqlDataAdapter(totalcommand);
            DataTable totalTable = new DataTable();
            totalAdapter.Fill((totalTable));
            int total = Convert.ToInt32(totalTable.Rows[0][0]);

            Pagination.totalitems = total;
            Pagination.limit = PageSize;
            Pagination.targetpage = "News01.aspx";
            //技巧:利用這種方式才可以呼叫usercontrol裡的public method
            Pagination.showPageControls();
        }

    }
}