using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace plantograma
{
    public partial class Autentificacion : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["logeado"] != null)//si existe estara logeado
            {
                //   Response.Redirect("HomeAdmin.aspx");
                Response.Redirect(GetRouteUrl("HomeAdminRoute", null));
            }
        }
    }
}