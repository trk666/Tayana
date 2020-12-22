using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tayanaBackend.Backend
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    string userdata = ((FormsIdentity)Page.User.Identity).Ticket.UserData;
                    string[] array = userdata.Split(',');

                    Name.Text = array[0];
                    Photo.ImageUrl = "https://localhost:44358/Backend/img/user/" + array[2];
                }
            }
        }
    }
}