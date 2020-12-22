using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private const int PageSize = 4;
        protected void Page_Load(object sender, EventArgs e)
        {
            //預設預覽圖C:\Users\user\source\repos\tayana\images\ckf\previewNews\pit008.jpg
            if (!Page.IsPostBack)
            {
                if (Session["search"] != null)
                {
                    string keyword = Session["search"].ToString();
                    this.keyword.Text = keyword;
                    show(keyword);
                }
                else
                {
                    show("");
                }
            }
        }

        public string gettop(object eval)
        {
            string gettop = eval.ToString();
            if (gettop == "1")
            {
                return "置頂";
            }
            else
            {
                return "";
            }
        }

        private void show(string keyword)
        {
            int currentPage = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            string search = "";

            if (!string.IsNullOrEmpty(keyword))
            {
                search = " and title like '%'+@keyword+'%' ";//參數sql語法 
                Session["search"] = keyword;
            }

            string commandstring = $@"with newsList as (select row_number() over(order by gettop desc,[date] desc)
as rownumber,* from news where 1 =1 {search} )select *from newsList 
where rownumber>=@start and rownumber <=@end order by gettop desc,[date] desc";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            SqlCommand allnews = new SqlCommand(commandstring, connect);

            allnews.Parameters.AddWithValue("@keyword", keyword);

            allnews.Parameters.Add("@start", SqlDbType.Int);
            allnews.Parameters["@start"].Value = ((currentPage - 1) * PageSize) + 1;
            allnews.Parameters.Add("@end", SqlDbType.Int);
            allnews.Parameters["@end"].Value = currentPage * PageSize;

           

            SqlDataAdapter adapter = new SqlDataAdapter(allnews);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Repeater1.DataSource = table;
            Repeater1.DataBind();

            SqlCommand totalcommand = new SqlCommand($@"select count(*) from news where 1=1 {search}", connect);
            totalcommand.Parameters.AddWithValue("@keyword", keyword);
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection delete = new SqlConnection(connectstring);

            string caseName = e.CommandName;

            switch (caseName)
            {
                case "delete":
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM news WHERE   (id = @id )", delete);
                    deleteCommand.Parameters.AddWithValue("@id", id);
                    delete.Open();
                    deleteCommand.ExecuteNonQuery();
                    delete.Close();
                    Response.Redirect(Request.Url.ToString());
                    break;
                case "edit":
                    Response.Redirect("NewsEdit.aspx?id=" + $"{id}");
                    break;
            }

        }

        protected void addNews_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsAdd.aspx");
        }


        protected void search_Click(object sender, EventArgs e)
        {
            string keyword = this.keyword.Text;
            show(keyword);
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("News01.aspx");
        }
    }
}