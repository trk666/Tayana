using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubmitAlert.Visible = false;
                HiddenCountry.Value = ",";
                HiddenArea.Value = ",";
                string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                SqlConnection connect = new SqlConnection(connectstring);

                string sqlCountry = "SELECT  * FROM      country";
                SqlCommand dropdown = new SqlCommand(sqlCountry, connect);

                connect.Open();
                SqlDataReader country = dropdown.ExecuteReader();
                while (country.Read())
                {
                    HiddenCountry.Value += country["country"] + ",";
                }

                dropdown.Cancel();
                country.Close();
                connect.Close();
                connect.Dispose();
            }
        }

        protected void CountryList_Init(object sender, EventArgs e)
        {
            CountryList.Items.Clear();
            CountryList.Items.Add("現有國家列表");

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
            AreaList.Items.Add("該國家現有區域列表");

            if (CountryList.SelectedValue == "現有國家列表")
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
                    HiddenArea.Value += area["area"].ToString() + ",";
                }

                dropdown.Cancel();
                area.Close();
                connect.Close();
                connect.Dispose();
            }
        }

        protected void AddCountry_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NewCountry.Text))
            {
                if (HiddenCountry.Value.IndexOf("," + NewCountry.Text + ",", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    CountryAlert.Visible = true;
                }
                else
                {
                    string connectstring =WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                    SqlConnection connect = new SqlConnection(connectstring);

                    string sqlCountry = "INSERT INTO country(country)VALUES  (@country)";
                    SqlCommand addcountry = new SqlCommand(sqlCountry, connect);
                    addcountry.Parameters.AddWithValue("@country", NewCountry.Text);

                    connect.Open();
                    addcountry.ExecuteNonQuery();
                    connect.Close();
                    Response.Redirect("DealerAdd.aspx");
                }
            }
            else
            {
                CountryEmpty.Text = "未輸入國家名稱";
                CountryEmpty.Visible = true;
            }
        }

        protected void AddArea_Click(object sender, EventArgs e)
        {
            if (CountryList.SelectedValue != "現有國家列表")
            {
                if (!string.IsNullOrEmpty(NewArea.Text))
                {
                    if (HiddenArea.Value.IndexOf("," + NewArea.Text + ",", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        AreaAlert.Visible = true;
                    }
                    else
                    {
                        int countryID = Convert.ToInt32(CountryList.SelectedValue);
                        string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"]
                            .ToString();
                        SqlConnection connect = new SqlConnection(connectstring);

                        string sqlCountry = "INSERT INTO area(countryID, area)VALUES  (@countryID,@area)";
                        SqlCommand addarea = new SqlCommand(sqlCountry, connect);
                        addarea.Parameters.AddWithValue("@countryID", countryID);
                        addarea.Parameters.AddWithValue("@area", NewArea.Text);

                        connect.Open();
                        addarea.ExecuteNonQuery();
                        connect.Close();
                        Response.Redirect("DealerAdd.aspx");
                    }
                }
                else
                {
                    AreaEmpty.Text = "請輸入地區名稱";
                    AreaEmpty.Visible = true;
                }
            }
            else
            {
                NoChooseCountry.Text = "請先指定國家";
                NoChooseCountry.Visible = true;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NoChoose.Visible = false;
            if (CountryList.SelectedValue == "現有國家列表" || AreaList.SelectedValue == "該國家現有區域列表")
            {
                NoChoose.Visible = true;
            }
            else
            {
                getArea();
                ShowADD.Visible = true;
                ListArea.Visible = false;
            }
        }

        private void getArea()
        {
            int areaID = Convert.ToInt32(AreaList.SelectedValue);
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlstring = @"SELECT  area.area, country.country, area.id
            FROM area INNER JOIN
            country ON area.countryID = country.id";
            string sqlsearch = " where area.id = @areaID";
            
            SqlCommand command = new SqlCommand(sqlstring+sqlsearch,connect);
            command.Parameters.AddWithValue("@areaID", areaID);
            
            connect.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Literal1.Text = reader["country"].ToString();
                Literal2.Text = " - "+reader["area"];
            }
            connect.Close();
            connect.Dispose();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (AreaList.SelectedValue != null)
            {
                if (DealerPhoto.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(DealerPhoto.FileName).ToLower(); //取得副檔名並轉成小寫

                    string[] allowExtension = { ".jpg", ".png", ".gif", }; //宣告一個陣列，內容為符合的副檔名

                    bool fileOk = false;
                    int j = 0;
                    for (int i = 0; i < allowExtension.Length; i++) //判斷檔案的副檔名
                    {
                        if (fileExtension == allowExtension[i])
                        {
                            fileOk = true;
                            break; //有true就可以出來了
                        }
                    }

                    if (fileOk)
                    {
                        string filename = DealerPhoto.FileName;
                        string Path = Server.MapPath(@"~\images\dealers\");
                        string save = Path + filename;
                        DealerPhoto.SaveAs(save);

                        GOsql(filename);
                    }
                }
                else
                {
                    GOsql("avatardefault_92824.png");
                }
            }
            else
            {
                SubmitAlert.Visible = true;
            }
        }

        private void GOsql(string DealerPhotoName)
        {
            int areaID = Convert.ToInt32(AreaList.SelectedValue);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string add = "INSERT INTO dealer(areaID, photo, dealer)VALUES  (@areaID,@photo,@dealer)";
            SqlCommand addDealer = new SqlCommand(add, connect);
            addDealer.Parameters.AddWithValue("@areaID", areaID);
            addDealer.Parameters.AddWithValue("@photo", DealerPhotoName);
            addDealer.Parameters.AddWithValue("dealer", DealerInfo.Text);

            connect.Open();
            addDealer.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("Dealers.aspx");
        }

        protected void golist_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dealers.aspx");
        }

        protected void goedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dealers.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}