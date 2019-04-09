
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace plantograma.views
{
    public partial class viewResltados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImprime_Click(object sender, EventArgs e)
        {
            string cadenaFinal = "<TABLE BORDER='1'><TR><TD>NOMBRE :</TD><TD>GILMER</TD></TR>" +
                                "<TR><TD>APELLIDO :</TD><TD>MELGAREJO LIMAS</TD></TR>" +
                                "<TR><TD>EDAD :</TD><TD>24</TD></TR></TABLE>";

            CrearPdf pdf = new CrearPdf();
            pdf.crear(cadenaFinal); 



        }
    }
}