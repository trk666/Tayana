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
    public partial class dealerEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            NoChoose.Visible = false;
            if (CountryList.SelectedValue == "現有國家列表" || AreaList.SelectedValue == "該國家現有區域列表")
            {
                NoChoose.Visible = true;
            }
            else
            {
                
            }
        }

        protected void EditCountry_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(CountryList.SelectedValue);
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlCountry = "UPDATE  country SET country =@country where id=@id";
            SqlCommand editcountry = new SqlCommand(sqlCountry, connect);
            editcountry.Parameters.AddWithValue("@country", CountryEdit.Text);
            editcountry.Parameters.AddWithValue("@id", id);

            connect.Open();
            editcountry.ExecuteNonQuery();
            connect.Close();
            Response.Redirect(Request.Url.ToString());
        }

        protected void EditArea_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(AreaList.SelectedValue);
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlArea = "UPDATE  area SET  area =@area where id=@id";
            SqlCommand editarea = new SqlCommand(sqlArea, connect);
            editarea.Parameters.AddWithValue("@area", AreaEdit.Text);
            editarea.Parameters.AddWithValue("@id", id);

            connect.Open();
            editarea.ExecuteNonQuery();
            connect.Close();
            Response.Redirect(Request.Url.ToString());
        }

        protected void AreaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int areaID = Convert.ToInt32(AreaList.SelectedValue);
            show(areaID);
        }

        protected void
            DataList1_EditCommand(object source, DataListCommandEventArgs e) //用datalist屬性閃電點出來的 對應CommandName
        {
            DataList1.EditItemIndex = e.Item.ItemIndex; //使指定的部分變成編輯頁面

            int areaID = Convert.ToInt32(AreaList.SelectedValue); //重新跑一次sql刷新頁面
            show(areaID);
        }

        protected void
            DataList1_CancelCommand(object source, DataListCommandEventArgs e) //用datalist屬性閃電點出來的 對應CommandName
        {
            DataList1.EditItemIndex = -1; //回到總覽畫面 -1是陣列比0還前

            int areaID = Convert.ToInt32(AreaList.SelectedValue); //重新跑一次sql刷新頁面
            show(areaID);
        }

        protected void
            DataList1_UpdateCommand(object source, DataListCommandEventArgs e) //用datalist屬性閃電點出來的 對應CommandName
        {
            string id = DataList1.DataKeys[0].ToString(); //要用datalist的屬性dataKeyField選取欄位 因為是集合所以要用[0]指定
            TextBox DealerInfo = (TextBox)e.Item.FindControl("DealerInfo"); //宣告一個TextBox然後用FindControl找到對應的塞給他
            FileUpload DealerPhotoEdit = (FileUpload)e.Item.FindControl("DealerPhotoEdit"); //宣告一個FileUpload然後用FindControl找到對應的塞給他
            
            HiddenField HiddenField1 = (HiddenField)e.Item.FindControl("HiddenField1");

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string search = " where id=@id";
            string sqlpic = "SELECT  * FROM dealer" + search;
            SqlCommand getpic = new SqlCommand(sqlpic, connect);
            getpic.Parameters.AddWithValue("@id", id);

            connect.Open();
            SqlDataReader reader = getpic.ExecuteReader();
            if (reader.Read())
            {
                HiddenField1.Value = reader["photo"].ToString();
            }
            connect.Close();

            if (DealerPhotoEdit.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(DealerPhotoEdit.FileName).ToLower(); //取得副檔名並轉成小寫

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
                    string filename = DealerPhotoEdit.FileName;
                    string Path = Server.MapPath(@"~\images\dealers\");
                    string save = Path + filename;
                    DealerPhotoEdit.SaveAs(save);

                    //update
                    updateSql(id, filename, DealerInfo);
                }
            }
            else
            {
                updateSql(id, HiddenField1.Value, DealerInfo);
            }

        }

        private void updateSql(string id, string filename, TextBox DealerInfo)
        {
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string serach = " where id=@id";
            string sqlDealer = "UPDATE  dealer SET photo =@photo, dealer =@dealer" + serach;
            SqlCommand dealerUpdate = new SqlCommand(sqlDealer, connect);
            dealerUpdate.Parameters.AddWithValue("@id", id);
            dealerUpdate.Parameters.AddWithValue("@dealer", DealerInfo.Text);
            dealerUpdate.Parameters.AddWithValue("@photo", filename);

            connect.Open();
            dealerUpdate.ExecuteNonQuery();
            connect.Close();

            DataList1.EditItemIndex = -1;
            int areaID = Convert.ToInt32(AreaList.SelectedValue);
            show(areaID);
        }
        private void show(int areaID)
        {
            string serach = " where areaID=@areaID";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            string sqlDealer = @"SELECT  area.id, area.countryID, area.area, dealer.id AS dealerID, dealer.areaID, dealer.photo, dealer.dealer
            FROM area INNER JOIN
            dealer ON area.id = dealer.areaID" + serach;
            SqlCommand dropdown = new SqlCommand(sqlDealer, connect);

            dropdown.Parameters.AddWithValue("@areaID", areaID);

            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(dropdown);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataList1.DataSource = table;
            DataList1.DataBind();
        }

        protected void golist_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dealers.aspx");
        }

        protected void goadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DealerAdd.aspx");
        }
    }
}