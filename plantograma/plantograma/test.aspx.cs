using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace plantograma
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgIzquierdo.ImageUrl = "~/img/derecho2.jpg";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          //  lbcordenadas.Text = "X:"+txtX.Text+ " - Y"+txtY.Text;

        }
    }
}