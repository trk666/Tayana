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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getsql();
            }
        }

        private void getsql()
        {
            string connecting = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connecting);

            string sqlstring = @"SELECT  yachts.type, yachtsDetails.*, CASE newest WHEN 1 THEN 'New!!' ELSE '' END AS status
FROM      yachts INNER JOIN
                   yachtsDetails ON yachts.id = yachtsDetails.typeID
				   order by newest desc , [date] desc";

            SqlCommand command = new SqlCommand(sqlstring, connect);

            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Repeater1.DataSource = table;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int detailID = Convert.ToInt32(e.CommandArgument);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection delete = new SqlConnection(connectstring);

            string caseName = e.CommandName;

            switch (caseName)
            {
                case "delete":
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM yachtsDetails WHERE   (detailID = @detailID )", delete);
                    deleteCommand.Parameters.AddWithValue("@detailID", detailID);
                    delete.Open();
                    deleteCommand.ExecuteNonQuery();
                    delete.Close();
                    Response.Redirect(Request.Url.ToString());
                    break;
                case "photo":
                    Response.Redirect("YachtsAlbum.aspx?id=" + $"{detailID}");
                    break;
                case "edit":
                    Response.Redirect("YachtEdit.aspx?id=" + $"{detailID}");
                    break;
           }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("YachtEdit.aspx");
        }

        protected void Add_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("YachtsAdd.aspx");
        }
    }
}