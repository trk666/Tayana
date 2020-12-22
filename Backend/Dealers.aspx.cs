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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getALL();
            }
        }

        private void getALL()
        {
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlstring = @"SELECT  d.id, a.countryID, a.area, c.id AS countryID, c.country, d.id AS dealerID, d.areaID, d.photo, 
                   d.dealer
FROM      area as a INNER JOIN
                   country as c ON a.countryID = c.id INNER JOIN
                   dealer as d ON a.id = d.areaID
				   order by c.id ";
            
            SqlCommand all = new SqlCommand(sqlstring, connect);

            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(all);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Repeater1.DataSource = table;
            Repeater1.DataBind();
        }

        protected void CountryList_Init(object sender, EventArgs e)
        {
            CountryList.Items.Clear();
            CountryList.Items.Add("請選擇國家");

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlCountry = "SELECT  * FROM      country";
            SqlCommand dropdown = new SqlCommand(sqlCountry, connect);

            connect.Open();
            SqlDataReader country = dropdown.ExecuteReader();
            while (country.Read())
            {
                CountryList.Items.Add(new ListItem(country["country"].ToString(), country["id"].ToString()));
            }
            dropdown.Cancel();
            country.Close();
            connect.Close();
            connect.Dispose();
        }

        protected void CountryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaList.Items.Clear();
            AreaList.Items.Add("請選擇區域");

            if (CountryList.SelectedValue == "請選擇國家")
            {
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                int countryID = Convert.ToInt32(CountryList.SelectedValue);
                string serach = " where countryID=@countryID";

                string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                SqlConnection connect = new SqlConnection(connectstring);
                string sqlArea = "SELECT  * FROM      area" + serach;
                SqlCommand dropdown = new SqlCommand(sqlArea, connect);

                dropdown.Parameters.AddWithValue("@countryID", countryID);

                connect.Open();
                SqlDataReader area = dropdown.ExecuteReader();
                while (area.Read())
                {
                    AreaList.Items.Add(new ListItem(area["area"].ToString(), area["id"].ToString()));
                }
                dropdown.Cancel();
                area.Close();
                connect.Close();
                connect.Dispose();
            }
        }

        protected void AreaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDealer();
        }

        private void getDealer()
        {
            int areaID = Convert.ToInt32(AreaList.SelectedValue);
            string sqlstring = @"SELECT  area.id, area.countryID, area.area, dealer.id AS dealerID, dealer.areaID, dealer.photo, dealer.dealer
FROM      area INNER JOIN
                   dealer ON area.id = dealer.areaID";
            string serach = " where dealer.areaID=@areaID";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            string sqlDealer = sqlstring + serach;
            SqlCommand dropdown = new SqlCommand(sqlDealer, connect);

            dropdown.Parameters.AddWithValue("@areaID", areaID);

            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(dropdown);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Repeater1.DataSource = table;
            Repeater1.DataBind();
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
                    string sqlstring = "DELETE FROM dealer where id =@id";
                    SqlCommand command =new SqlCommand(sqlstring,delete);
                    command.Parameters.AddWithValue("@id", id);

                    delete.Open();
                    command.ExecuteNonQuery();
                    delete.Close();
                    delete.Dispose();
                    getDealer();

                    break;
               }

        }


        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("dealerAdd.aspx");
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("DealerEdit.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            if (CountryList.SelectedValue != "請選擇國家" && AreaList.SelectedValue == "請選擇區域")
            {
                int countryID = Convert.ToInt32(CountryList.SelectedValue);
                string sqlstring =
                    @"SELECT  d.id, a.countryID, a.area, c.id AS countryID, c.country, d.id AS dealerID, d.areaID, d.photo, 
                   d.dealer
FROM      area as a INNER JOIN
                   country as c ON a.countryID = c.id INNER JOIN
                   dealer as d ON a.id = d.areaID";
                string sqlsearch = " where c.id =@countryID";

                SqlCommand command = new SqlCommand(sqlstring + sqlsearch, connect);
                command.Parameters.AddWithValue("@countryID", countryID);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Repeater1.DataSource = table;
                Repeater1.DataBind();
            }
            else if(AreaList.SelectedValue != "請選擇區域")
            {
                int areaID = Convert.ToInt32(AreaList.SelectedValue);
                string sqlstring =
                    @"SELECT  d.id, a.countryID, a.area, c.id AS countryID, c.country, d.id AS dealerID, d.areaID, d.photo, 
                   d.dealer
FROM      area as a INNER JOIN
                   country as c ON a.countryID = c.id INNER JOIN
                   dealer as d ON a.id = d.areaID";
                string sqlsearch = " where d.areaID =@areaID";

                SqlCommand command = new SqlCommand(sqlstring + sqlsearch, connect);
                command.Parameters.AddWithValue("@areaID", areaID);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Repeater1.DataSource = table;
                Repeater1.DataBind();
            }
        }

        protected void DeleteCountry_Click(object sender, EventArgs e)
        {
            int countryID = Convert.ToInt32(CountryList.SelectedValue);
            string serach = " where id=@countryID";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            string sqlDealer = "DELETE FROM country" + serach;
            SqlCommand deleteCountry = new SqlCommand(sqlDealer, connect);

            deleteCountry.Parameters.AddWithValue("@countryID", countryID);

            connect.Open();
            deleteCountry.ExecuteNonQuery();
            connect.Close();
            connect.Dispose();
            Response.Redirect(Request.Url.ToString());
        }

        protected void DeleteArea_Click(object sender, EventArgs e)
        {
            int areaID = Convert.ToInt32(AreaList.SelectedValue);
            string serach = " where id=@areaID";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            string sqlDealer = "DELETE FROM area" + serach;
            SqlCommand deleteArea = new SqlCommand(sqlDealer, connect);

            deleteArea.Parameters.AddWithValue("@areaID", areaID);

            connect.Open();
            deleteArea.ExecuteNonQuery();
            connect.Close();
            connect.Dispose();
            Response.Redirect(Request.Url.ToString());
        }
    }
}