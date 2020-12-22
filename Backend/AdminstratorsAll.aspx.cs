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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                SqlConnection connect = new SqlConnection(connectstring);

                string command = "SELECT  * FROM administrator where id !=1";
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command,connect);
                DataTable table=new DataTable();
                adapter.Fill(table);
                Repeater1.DataSource = table;
                Repeater1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminstratorAdd.aspx");
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
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM administrator WHERE   (id = @id )", delete);
                    deleteCommand.Parameters.AddWithValue("@id", id);
                    delete.Open();
                    deleteCommand.ExecuteNonQuery();
                    delete.Close();
                    Response.Redirect(Request.Url.ToString());
                    break;
                case "edit":
                    Response.Redirect("AdminstratorEdit.aspx?id=" + $"{id}");
                    break;
            }
        }
    }
}