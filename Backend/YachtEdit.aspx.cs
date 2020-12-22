using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                NoSelectAlert.Visible = false;
                if (Request.QueryString["id"]!=null)
                {
                    Button1.Visible = false;
                    Area01.Visible = false;
                    EditAREA.Visible = true;
                    int detailID = Convert.ToInt32(Request.QueryString["id"]);
                    getTypeSerial(detailID);
                    getDetail(detailID);
                }
                else
                {
                    Button1.Visible = false;
                }
            }
        }

        private void getTypeSerial(int detailID)
        {
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlstring = @"SELECT  y.type, yd.serial, yd.detailID
            FROM yachts as y INNER JOIN
            yachtsDetails as yd ON y.id = yd.typeID";
            string sqlsearch = " where detailID=@detailID";

            SqlCommand getsql = new SqlCommand(sqlstring + sqlsearch, connect);
            getsql.Parameters.AddWithValue("@detailID", detailID);

            connect.Open();
            SqlDataReader reader = getsql.ExecuteReader();
            if (reader.Read())
            {
                Literal1.Text = reader["type"].ToString();
                Literal2.Text = reader["serial"].ToString();
            }
            getsql.Cancel();
            reader.Close();
            connect.Close();
            connect.Dispose();
        }

        private void getDetail(int detailID)
        {
            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlstring = "SELECT  * FROM yachtsDetails";
            string sqlsearch = " where detailID=@detailID";

            SqlCommand getsql = new SqlCommand(sqlstring + sqlsearch, connect);
            getsql.Parameters.AddWithValue("@detailID", detailID);

            connect.Open();
            SqlDataReader reader = getsql.ExecuteReader();
            if (reader.Read())
            {
                RadioButtonList1.Text = reader["newest"].ToString();
                Overview.Text = reader["overview"].ToString();
                Layout.Text = reader["layout"].ToString();
                Specification.Text = reader["specification"].ToString();
            }
            getsql.Cancel();
            reader.Close();
            connect.Close();
            connect.Dispose();
        }


        protected void TypeList_Init(object sender, EventArgs e)
        {
            TypeList.Items.Clear();
            TypeList.Items.Add("請選擇現有船型");

            int id = Convert.ToInt32(Request.QueryString["id"]);

            string sqlstring = "SELECT  *FROM yachts";

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand getsql = new SqlCommand(sqlstring, connect);
            getsql.Parameters.AddWithValue($"@id", id);

            string allType = ",";

            connect.Open();
            SqlDataReader reader = getsql.ExecuteReader();
            while (reader.Read())
            {
                TypeList.Items.Add(new ListItem(reader["type"].ToString(), reader["id"].ToString()));
                allType += reader["type"] + ",";
            }
            getsql.Cancel();
            reader.Close();
            connect.Close();
            connect.Dispose();

            HiddenField1.Value = allType;
        }

        protected void TypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialList.Items.Clear();
            SerialList.Items.Add("瀏覽該船型的編號");

            if (TypeList.SelectedValue == "請選擇現有船型")
            {
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                TypeToSerial();
            }
        }

        private void TypeToSerial()
        {
            int typeID = Convert.ToInt32(TypeList.SelectedValue);

            string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            string sqlstring = "SELECT  * FROM yachtsDetails";
            string sqlsearch = " where typeID=@typeID";

            SqlCommand getsql = new SqlCommand(sqlstring + sqlsearch, connect);
            getsql.Parameters.AddWithValue($"@typeID", typeID);

            string typeSerial = ",";

            connect.Open();
            SqlDataReader reader = getsql.ExecuteReader();
            while (reader.Read())
            {
                SerialList.Items.Add(new ListItem(reader["serial"].ToString(), reader["detailID"].ToString()));
                typeSerial += reader["serial"] + ",";
            }
            getsql.Cancel();
            reader.Close();
            connect.Close();
            connect.Dispose();

            HiddenField2.Value = typeSerial;
        }

        protected void SubmitType_Click(object sender, EventArgs e)
        {
            if (TypeList.SelectedValue == "請選擇現有船型")
            {
                Label1.Visible = true;
                Label1.Text = "未選擇船型";
            }
            else
            {
                if (HiddenField1.Value.IndexOf("," + TypeEdit.Text + ",", StringComparison.OrdinalIgnoreCase) > -1)
                {

                    Label1.Visible = true;
                    Label1.Text = "已有重複船型";
                }
                else if (string.IsNullOrEmpty(TypeEdit.Text))
                {
                    Label1.Visible = true;
                    Label1.Text = "請輸入新船型";
                }
                else
                {
                    int typeID = Convert.ToInt32(TypeList.SelectedValue);
                    string sqlstring = "UPDATE  yachts SET type =@type";
                    string sqlsearch = " where id = @id";

                    string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                    SqlConnection connect = new SqlConnection(connectstring);

                    SqlCommand gosql = new SqlCommand(sqlstring + sqlsearch, connect);
                    gosql.Parameters.AddWithValue("@id", typeID);
                    gosql.Parameters.AddWithValue("@type", TypeEdit.Text);

                    connect.Open();
                    gosql.ExecuteNonQuery();
                    connect.Close();
                    Response.Redirect(Request.Url.ToString());
                }
            }
        }

        protected void SubmitSerial_Click(object sender, EventArgs e)
        {
            if (SerialList.SelectedValue == "請選擇現有船型")
            {
                Label2.Visible = true;
                Label2.Text = "未選擇現有船型";
            }
            else
            {
                TypeToSerial();
                if (SerialList.SelectedValue == "選擇該船型的型號")
                {
                    Label2.Visible = true;
                    Label2.Text = "未選擇型號";
                }
                else if (HiddenField2.Value.IndexOf(SerialEdit.Text, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    Label2.Visible = true;
                    Label2.Text = "此船型已有相同型號";
                }
                else if (string.IsNullOrEmpty(SerialEdit.Text))
                {
                    Label2.Visible = true;
                    Label2.Text = "請輸入型號";
                }
                else if (RadioButtonList1.SelectedValue == null)
                {
                    Label2.Visible = true;
                    Label2.Text = "未選擇是否為最新型";
                }
                else
                {
                    int detailID = Convert.ToInt32(SerialList.SelectedValue);
                    string sqlstring = "UPDATE  yachtsDetails SET serial =@serial, newest =@newest";
                    string sqlsearch = " where detailID = @detailID";

                    string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                    SqlConnection connect = new SqlConnection(connectstring);

                    SqlCommand gosql = new SqlCommand(sqlstring + sqlsearch, connect);
                    gosql.Parameters.AddWithValue("@detailID", detailID);
                    gosql.Parameters.AddWithValue("@serial", SerialEdit.Text);
                    gosql.Parameters.AddWithValue("@newest", RadioButtonList1.SelectedValue);


                    connect.Open();
                    gosql.ExecuteNonQuery();
                    connect.Close();
                    Response.Redirect(Request.Url.ToString());
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TypeList.SelectedValue == "請選擇現有船型" || SerialList.SelectedValue == "請先選擇船型" || SerialList.SelectedValue == "瀏覽該船型的編號")
            {
                if (TypeList.SelectedValue == "請選擇現有船型")
                {
                    NoSelectAlert.Text = "未選擇船型";
                    NoSelectAlert.Visible = true;
                }
                else if (SerialList.SelectedValue == "請先選擇船型" || SerialList.SelectedValue == "瀏覽該船型的編號")
                {
                    NoSelectAlert.Text = "未選擇編號";
                    NoSelectAlert.Visible = true;
                }
            }
            else
            {
                Literal1.Text = TypeList.SelectedItem.Text;
                Literal2.Text = SerialList.SelectedItem.Text;
                EditAREA.Visible = true;
                Area01.Visible = false;
            }
        }


        protected void Submit_OnClick(object sender, EventArgs e)
        {
            if (PDFupload.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(PDFupload.FileName).ToLower(); //取得副檔名並轉成小寫

                bool fileOk = false;
                if (fileExtension == ".pdf")
                {
                    fileOk = true;
                    if (fileOk = true)
                    {

                        string filename = PDFupload.FileName;
                        string Path = Server.MapPath(@"~\pdf\");
                        string save = Path + filename;
                        PDFupload.SaveAs(save);

                        updatePDF(PDFupload.FileName);
                        updateSQL();
                    }
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "非PDF格式";
                }
            }
            else
            {
                updateSQL();
            }
        }

        private void updateSQL()
        {
            int detailID = Convert.ToInt32(Request.QueryString["id"]);

            // 除pdf外
            string sqlstring =
                "UPDATE  yachtsDetails SET overview =@overview, layout =@layout, specification =@specification, newest =@newest";
            string sqlsearch = " where detailID = @detailID";

            string connectstring =
                WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);

            SqlCommand gosql = new SqlCommand(sqlstring + sqlsearch, connect);
            gosql.Parameters.AddWithValue("@detailID",detailID );
            gosql.Parameters.AddWithValue("@overview", Overview.Text);
            gosql.Parameters.AddWithValue("@layout", Layout.Text);
            gosql.Parameters.AddWithValue("@specification", Specification.Text);
            gosql.Parameters.AddWithValue("@newest", RadioButtonList1.SelectedValue);

            connect.Open();
            gosql.ExecuteNonQuery();
            connect.Close();

            Response.Redirect("Yachts.aspx");
        }

        private void updatePDF(string pdf)
        {
            int detailID = Convert.ToInt32(Request.QueryString["id"]);

            string connectstring =
                WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
            SqlConnection connect = new SqlConnection(connectstring);
            
            string filestring = @"UPDATE  yachtsDetails
SET           pdf =@pdf";
            string sqlsearch = " where detailID = @detailID";

            SqlCommand gofile = new SqlCommand(filestring+sqlsearch, connect);
            gofile.Parameters.AddWithValue("@detailID", detailID);
            gofile.Parameters.AddWithValue("@pdf", pdf);

            connect.Open();
            gofile.ExecuteNonQuery();
            connect.Close();
            
        }


        protected void Rest_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Yachts.aspx");
        }


        protected void EditPhoto_Click(object sender, EventArgs e)
        {
            int detailID = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("YachtsAlbum.aspx?id=" + $"{detailID}");
        }

        protected void DeleteType_Click(object sender, EventArgs e)
        {
            if (TypeList.SelectedValue == "請選擇現有船型")
            {
                Label1.Text = "未選擇船型";
                Label1.Visible = true;
            }
            else
            {
                int id = Convert.ToInt32(TypeList.SelectedValue);

                string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                SqlConnection connect = new SqlConnection(connectstring);

                string sqlstring = "DELETE FROM yachts";
                string sqlsearch = " where id=@id";

                SqlCommand getsql = new SqlCommand(sqlstring + sqlsearch, connect);
                getsql.Parameters.AddWithValue($"@id", id);

                connect.Open();
                getsql.ExecuteNonQuery();
                connect.Close();
                Response.Redirect(Request.Url.ToString());
            }
        }

        protected void DeleteSerial_Click(object sender, EventArgs e)
        {
            if (SerialList.SelectedValue == "請先選擇船型" || SerialList.SelectedValue == "瀏覽該船型的編號")
            {
                Label2.Text = "未選擇編號";
                Label2.Visible = true;
            }
            else
            {
                int detailID = Convert.ToInt32(SerialList.SelectedValue);

                string connectstring = WebConfigurationManager.ConnectionStrings["tayanaConnectionString"].ToString();
                SqlConnection connect = new SqlConnection(connectstring);

                string sqlstring = "DELETE FROM yachtsDetails";
                string sqlsearch = " where detailID=@detailID";

                SqlCommand getsql = new SqlCommand(sqlstring + sqlsearch, connect);
                getsql.Parameters.AddWithValue($"@detailID", detailID);

                connect.Open();
                getsql.ExecuteNonQuery();
                connect.Close();
                Response.Redirect(Request.Url.ToString());
            }

        }


    }
}