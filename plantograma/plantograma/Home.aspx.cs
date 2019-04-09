using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace plantograma
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //si hay una archivo.
            PanelResultado.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUploadPlanta.HasFile)

            {


                Imagen.Instance.GuardarImagen(FileUploadPlanta);
                imgSubida.ImageUrl = Imagen.Instance.ruta;
                Label1.Text = "Se guardó la imagen. y su ruta es" + Environment.NewLine + Imagen.Instance.ruta;
            }
        }

        protected void btnConvertir_Click(object sender, EventArgs e)
        {
            EditarImagen();
        }

        protected void changeUmbral(object sender, EventArgs e)
        {
            EditarImagen();
        }

        public void EditarImagen()
        {
            //verifica el pie a analizar o editar
            int ubm = Convert.ToInt32(txtUmbral.Text.ToString());
            if (rblistPie.SelectedValue != "")
            {
                int idPie = Convert.ToInt32(rblistPie.SelectedValue);
                switch (idPie)
                {
                    case 0:
                        //  System.Diagnostics.Debug.WriteLine("pie Derecho");
                        // Imagen.Instance.ConvertirBlancoNegro(Imagen.Instance.getBitMap(), ubm, false);
                        //convierte la imagen a blanco y negro y ademas de eso cambia a un tamaño mas pequeño
                        Imagen.Instance.ConvertirBlancoNegro(Imagen.Instance.cambiarTamano(Imagen.Instance.getBitMap()), ubm, false);
                        ////actualiza
                        imgEditada.ImageUrl = Imagen.Instance.rutaEdit;

                        break;

                    case 1:
                        // System.Diagnostics.Debug.WriteLine(" Pie izquierdo");
                        Imagen.Instance.ConvertirBlancoNegro(Imagen.Instance.cambiarTamano(Imagen.Instance.getBitMap()), ubm, true);
                        ////actualiza
                        imgEditada.ImageUrl = Imagen.Instance.rutaEdit;
                        break;
                    default:
                        System.Diagnostics.Debug.WriteLine("Error no selecionado el Pie Derecho o izquierdo");
                        break;
                }
            }
            else
            {//si no selecciona el pie que es
                string script = @"<script type='text/javascript'>
                            alert('No se especifica si es un pie derecho o izquierdo');
                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                // System.Diagnostics.Debug.WriteLine("Error no selecionado el Pie Derecho o izquierdo");
            }
        }

        protected void btnaalizar_Click(object sender, EventArgs e)
        {
            //verifica el pie a analizar o editar
            int ubm = Convert.ToInt32(txtUmbral.Text.ToString());
            if (rblistPie.SelectedValue != "")
            {
                int idPie = Convert.ToInt32(rblistPie.SelectedValue);

                Plantograma plantograma = new Plantograma();
                Imagen.Instance.bitmap = plantograma.analizarImagen(Imagen.Instance.bitmap);

                //porcentaje
                lbresultadoPorcentaje.Text = Convert.ToString(plantograma.resultado);
                //resultado
                descripcion.Text = "";
                descripcion.Text = Convert.ToString(plantograma.mensajeTipoPie(plantograma.resultado));
                //convertimos a cm por q estan los datos en pixeles
                //mf  Centimetros 
                lbmf.Text = Convert.ToString(Math.Round(Imagen.Instance.optenerCentimetrosRealesHeight(Imagen.Instance.pixelToCentimetros(plantograma.mf, Imagen.Instance.imgDpiY)),3));
                //X
                lbX.Text = Convert.ToString(Math.Round(Imagen.Instance.optenerCentimetrosRealesWidht(Imagen.Instance.pixelToCentimetros(plantograma.X, Imagen.Instance.imgDpiX)),3));
                //Y
                lbY.Text = Convert.ToString(Math.Round(Imagen.Instance.optenerCentimetrosRealesWidht(Imagen.Instance.pixelToCentimetros(plantograma.Y, Imagen.Instance.imgDpiX)), 3));
                //ai
                lbai.Text = Convert.ToString(Math.Round(Imagen.Instance.optenerCentimetrosRealesWidht(Imagen.Instance.pixelToCentimetros(plantograma.ai, Imagen.Instance.imgDpiX)), 3));
                //ta
                lbta.Text = Convert.ToString(Math.Round(Imagen.Instance.optenerCentimetrosRealesWidht(Imagen.Instance.pixelToCentimetros(plantograma.talon, Imagen.Instance.imgDpiX)), 3));
                //
                lblogitudPie.Text = Convert.ToString(Math.Round(Imagen.Instance.optenerCentimetrosRealesWidht(Imagen.Instance.pixelToCentimetros(plantograma.longitudPieX, Imagen.Instance.imgDpiX)), 3))+"X"+ Convert.ToString(Math.Round(Imagen.Instance.optenerCentimetrosRealesHeight(Imagen.Instance.pixelToCentimetros(plantograma.longitudPieY, Imagen.Instance.imgDpiY)),3));
                //mostrar datos en el panel
                PanelResultado.Visible = true;
                switch (idPie)
                {
                    case 0:
                        //  System.Diagnostics.Debug.WriteLine("pie Derecho");
                        //para q sea el mismo tamaño
                       // Imagen.Instance.convertirToOriginalSize();
                        Imagen.Instance.guardarImgeEdit();//guardo la imagen
                        imgEditada.ImageUrl = Imagen.Instance.rutaEdit;//muestro la nueva imagen


                        break;

                    case 1:
                        // System.Diagnostics.Debug.WriteLine(" Pie izquierdo");
                        Imagen.Instance.bitmap = Imagen.Instance.voltearImagenResultado(Imagen.Instance.bitmap);
                        //para q sea el mismo tamaño
                       // Imagen.Instance.convertirToOriginalSize();
                        Imagen.Instance.guardarImgeEdit();//guardo la imagen
                        imgEditada.ImageUrl = Imagen.Instance.rutaEdit;//muestro la nueva imagen
                        break;
                    default:
                        System.Diagnostics.Debug.WriteLine("Error no selecionado el Pie Derecho o izquierdo");
                        break;
                }
            }
            else
            {//si no selecciona el pie que es
                string script = @"<script type='text/javascript'>
                            alert('No se especifica si es un pie derecho o izquierdo');
                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                // System.Diagnostics.Debug.WriteLine("Error no selecionado el Pie Derecho o izquierdo");
            }

        }
    }
}