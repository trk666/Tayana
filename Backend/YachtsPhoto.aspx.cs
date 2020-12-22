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
    public partial class WebForm16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("Yachts.aspx");
                }
                else
                {
                    int photoID = Convert.ToInt32(Request.QueryString["id"]);

                    string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                    SqlConnection conn = new SqlConnection(connectstring);

                    string sqlstring = "SELECT  *FROM yachtsPhoto";
                    string sqlsearch = " where photoID=@photoID";

                    SqlCommand cmd = new SqlCommand(sqlstring + sqlsearch, conn);
                    cmd.Parameters.AddWithValue("@photoID", photoID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        HiddenField1.Value = reader["detailID"].ToString();
                        Image1.ImageUrl = @"~\images\yachts\" + reader["img"];
                    }
                    conn.Close();
                    conn.Dispose();
                }

            }
        }

        protected void GoAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("YachtsAlbum.aspx?id=" + HiddenField1.Value);
        }

        protected void DeletePhoto_Click(object sender, EventArgs e)
        {
            int photoID = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connectstring);

            string sqlstring = "DELETE FROM yachtsPhoto";
            string sqlsearch = " where photoID=@photoID";

            SqlCommand cmd = new SqlCommand(sqlstring + sqlsearch, conn);
            cmd.Parameters.AddWithValue("@photoID", photoID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("YachtsAlbum.aspx?id=" + HiddenField1.Value);
        }
    }
}