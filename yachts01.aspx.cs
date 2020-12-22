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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                getleft();
                getRight(id);
                getPDF(id);
                getPhoto();
            }
        }


        private void getleft()
        {
            string connecting = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connecting);

            string sqlstring = @"SELECT  yachts.id, yachts.type, yachtsDetails.detailID, yachtsDetails.typeID, yachtsDetails.serial, yachtsDetails.date
            FROM yachts INNER JOIN
            yachtsDetails ON yachts.id = yachtsDetails.typeID";


            SqlCommand command = new SqlCommand(sqlstring, connect);

            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            LeftList.DataSource = table;
            LeftList.DataBind();
        }

        private void getRight(int id)
        {
            string connecting = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connecting);

            string sqlstring = "";
            if (id != 0)
            {
                sqlstring =
                    @"SELECT  yachts.id,  yachts.type, yachtsDetails.detailID, yachtsDetails.typeID, yachtsDetails.serial, 
                yachtsDetails.date, yachtsDetails.overview, yachtsDetails.layout, yachtsDetails.specification, yachtsDetails.newest
                    FROM      yachts INNER JOIN
                    yachtsDetails ON yachts.id = yachtsDetails.typeID

                where detailID = @detailID";
            }
            else
            {
                sqlstring =
                    @"SELECT  TOP (1) yachtsDetails.newest, yachts.id, yachts.type, yachtsDetails.detailID, yachtsDetails.typeID, yachtsDetails.serial, 
                   yachtsDetails.date, yachtsDetails.overview, yachtsDetails.layout, yachtsDetails.specification, yachtsDetails.newest
FROM      yachts INNER JOIN
                   yachtsDetails ON yachts.id = yachtsDetails.typeID
				   order by yachtsDetails.newest desc,yachtsDetails.date desc";
            }

            SqlCommand command = new SqlCommand(sqlstring, connect);
            command.Parameters.AddWithValue("@detailID", id);

            connect.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (id != 0)
            {
                if (reader.Read())
                {
                    Label3.Text = reader["type"].ToString();
                    Label4.Text = reader["serial"].ToString();
                    Label5.Text = reader["type"].ToString();
                    Label6.Text = reader["serial"].ToString();
                    Y01.HRef = "yachts01.aspx?id=" + reader["detailID"];
                    Y02.HRef = "yachts02.aspx?id=" + reader["detailID"];
                    Y03.HRef = "yachts03.aspx?id=" + reader["detailID"];
                    Label7.Text = reader["overview"].ToString();

                    HiddenField1.Value = reader["detailID"].ToString();
                }
            }
            else
            {
                if (reader.Read())
                {
                    Label3.Text = reader["type"].ToString();
                    Label4.Text = reader["serial"].ToString();
                    Label5.Text = reader["type"].ToString();
                    Label6.Text = reader["serial"].ToString();
                    Y01.HRef = "yachts01.aspx";
                    Y02.HRef = "yachts02.aspx";
                    Y03.HRef = "yachts03.aspx";
                    Label7.Text = reader["overview"].ToString();

                    HiddenField1.Value = reader["detailID"].ToString();
                }
            }

            connect.Close();
            connect.Dispose();
        }

        private void getPhoto()
        {
            string connecting = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connecting);

            string sqlstring = @"SELECT  *
FROM      yachtsPhoto
where detailID=@detailID
order by [date] desc";

            SqlCommand getPhoto = new SqlCommand(sqlstring, connect);
            getPhoto.Parameters.AddWithValue("@detailID", HiddenField1.Value);

            SqlDataAdapter adapter = new SqlDataAdapter(getPhoto);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Repeater1.DataSource = table;
            Repeater1.DataBind();

        }

        private void getPDF(int id)
        {
            string connecting = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connecting);

            string sqlstring = "";
            if (id != 0)
            {
                sqlstring =
                    @"SELECT  yachts.id,  yachts.type, yachtsDetails.detailID, yachtsDetails.typeID, yachtsDetails.serial, 
                yachtsDetails.date, yachtsDetails.overview, yachtsDetails.layout, yachtsDetails.specification, yachtsDetails.newest, yachtsDetails.pdf
                    FROM      yachts INNER JOIN
                    yachtsDetails ON yachts.id = yachtsDetails.typeID

                where detailID = @detailID";
            }
            else
            {
                sqlstring =
                    @"SELECT  TOP (1) yachtsDetails.newest, yachts.id, yachts.type, yachtsDetails.detailID, yachtsDetails.typeID, yachtsDetails.serial, 
                   yachtsDetails.date, yachtsDetails.overview, yachtsDetails.layout, yachtsDetails.specification, yachtsDetails.newest, yachtsDetails.pdf
FROM      yachts INNER JOIN
                   yachtsDetails ON yachts.id = yachtsDetails.typeID
				   order by yachtsDetails.newest desc,yachtsDetails.date desc";
            }

            SqlCommand command = new SqlCommand(sqlstring, connect);
            command.Parameters.AddWithValue("@detailID", id);

            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Repeater2.DataSource=table;
            Repeater2.DataBind();

        }

        public string noPDF(object pdf)
        {
            string pdfExist = Convert.ToString(pdf);

            if (!string.IsNullOrEmpty(pdfExist))
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