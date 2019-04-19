using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace plantograma.views
{
    public partial class PlantogramaVer : System.Web.UI.Page
    {
        PlantogramaEntidds plantogramaEntidds = new PlantogramaEntidds();
        Pacientes usuario = new Pacientes();
        Grupo grupo = new Grupo();
        Sexo sexo = new Sexo();
        Profecional profecional = new Profecional();
        FormatoA formatoA4 = new FormatoA(21f, 29.7f);//tamaño de la hoja
        public int metodoDerecho = 0;
        public int metodoIzquierda = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                string id = Request.QueryString["idPlantograma"];
                int id_grupo = Convert.ToInt32(Request.QueryString["id_grupo"]);

                //grupo
                LNGrupo lng = new LNGrupo();
                grupo.idGrupo = id_grupo;
                grupo = lng.IdGrupo(grupo);
                //plantograma
                plantogramaEntidds.idPlantograma = Convert.ToInt32(id);
                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                plantogramaEntidds = ln.PlantoID(plantogramaEntidds);

                //usuario
                usuario = plantogramaEntidds.pacientes;
                LNUsuario lnu = new LNUsuario();
                //  usuario = lnu.UsuarioID(usuario);

                labelFecha.Text = plantogramaEntidds.fechaCreacion.ToString();
                labelnombre.Text = usuario.nombres + " " + usuario.Apellidos;
                //imagen
                imagenUsuario.ImageUrl = "../" + usuario.foto;
                //originales
                imageIzquierdo.ImageUrl = "~/img/" + plantogramaEntidds.imgIzq;
                imageDerecho.ImageUrl = "~/img/" + plantogramaEntidds.imgDer;
                //analizados
                imageIzquierdoAnalizado.ImageUrl = "~/img/" + plantogramaEntidds.imgIzqAnlss;
                imageDerechoAnalizado.ImageUrl = "~/img/" + plantogramaEntidds.imgDerAnlss;
                System.Diagnostics.Debug.WriteLine("idPlantograma =" + plantogramaEntidds.idPlantograma);
                mostrarDatosDerechoResultado();
                mostrarDatosIzquierdoResultado();
            }
            catch (Exception)
            {

                Response.Redirect(GetRouteUrl("LoginRoute", null));
            }
        }

        protected void regresar(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("PlantogramaRoute", new { id_Paciente = plantogramaEntidds.pacientes.id_Paciente, id_grupo = grupo.idGrupo }), false);

        }
        //comvierte a blanco y neggro
        protected void btnAnalizarIzquierdo_Click(object sender, EventArgs e)
        {
            int ubm = Convert.ToInt32(txtUmbralIzquierdo.Text.ToString());
            try
            {//truen para pie izquierdo 
                //false derecho
                Imagen.Instance.nombreArchivoEditado = plantogramaEntidds.imgIzqAnlss;//nombre de imagen editado anterior mente para que se elimine
                Imagen.Instance.nombreArchivo = plantogramaEntidds.imgIzq;//nombre del archivo a editar
                Imagen.Instance.ConvertirBlancoNegro(Imagen.Instance.cambiarTamano(Imagen.Instance.getBitMap()), ubm, true);//convertir a blanco y negrp
                ////actualiza
                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                plantogramaEntidds.imgIzqAnlss = Imagen.Instance.nombreArchivoEditado;//nuevo nombre de imagen analizado
                ln.UpdatePlan(plantogramaEntidds);//actualizo
                plantogramaEntidds = ln.PlantoID(plantogramaEntidds);//optenr el plantogrma modificdo
                imageIzquierdoAnalizado.ImageUrl = "~/img/" + plantogramaEntidds.imgIzqAnlss;//ponermos la url
                System.Diagnostics.Debug.WriteLine(" success ");
                LinkButtonAnalizarIzquierdo.Visible = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" error al analizar imagen " + ex.Message);
                throw;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "tabSelectIzquierdo();", true);
            //  ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Hola');", true);
        }
        //blanco y negro
        protected void btnAnalizarDerecho_Click(object sender, EventArgs e)
        {
            int ubm = Convert.ToInt32(txtUmbralDerecho.Text.ToString());
            try
            {//truen para pie izquierdo 
                //false derecho
                Imagen.Instance.nombreArchivoEditado = plantogramaEntidds.imgDerAnlss;// nombre de imagen editado anterior mente para que se elimine
                Imagen.Instance.nombreArchivo = plantogramaEntidds.imgDer;//nombre del archivo a editar
                Imagen.Instance.ConvertirBlancoNegro(Imagen.Instance.cambiarTamano(Imagen.Instance.getBitMap()), ubm, false);//convertir a blanco y negrp
                ////actualiza
                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                plantogramaEntidds.imgDerAnlss = Imagen.Instance.nombreArchivoEditado;//nuevo nombre de imagen analizado
                ln.UpdatePlan(plantogramaEntidds);//actualizo
                plantogramaEntidds = ln.PlantoID(plantogramaEntidds);//optenr el plantogrma modificdo
                imageDerechoAnalizado.ImageUrl = "~/img/" + plantogramaEntidds.imgDerAnlss;//mostramos la imagen

                LinkButtonAnalizarDerecho.Visible = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" error al analizar imagen " + ex.Message);
                throw;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "tabSelectDerecho();", true);
        }

        protected void LinkButtonAnalizarIzquierdo_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Plantograma plantograma = new Entidades.Plantograma();
                Imagen.Instance.nombreArchivoEditado = plantogramaEntidds.imgIzqAnlss;//nombre de imagen editado anterior mente para que se elimine
                                                                                      //Imagen.Instance.nombreArchivo = plantogramaEntidds.imgIzq;//nombre del archivo a editar

                plantogramaEntidds.metodo = Convert.ToInt32(DropDownListTipoAnalisis.SelectedValue);

                if (plantogramaEntidds.metodo == 0)
                {//hernandez corvo
                    Imagen.Instance.bitmap = plantograma.analizarImagen(Imagen.Instance.cambiarTamano(Imagen.Instance.getBitMap(plantogramaEntidds.imgIzqAnlss)));
                }
                else
                {//metodo 2
                 //nombre del archivo a editar
                    guardarImagenIzquierdaAnalisisBase64(txtDataIzquierda.Text);
                    Imagen.Instance.bitmap = plantograma.analizarImagenMedoto2(Imagen.Instance.cambiarTamano(Imagen.Instance.getBitMap(plantogramaEntidds.imgIzqAnlss)));
                }
                plantogramaEntidds.x = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.X, formatoA4), 3));
                plantogramaEntidds.y = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.Y, formatoA4), 3));
                plantogramaEntidds.mF = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosHeight(plantograma.mf, formatoA4), 3));

                plantogramaEntidds.tA = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.talon, formatoA4), 3));
                plantogramaEntidds.LongPieX = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.longitudPieX, formatoA4), 3));
                plantogramaEntidds.LongPieY = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosHeight(plantograma.longitudPieY, formatoA4), 3));

                plantogramaEntidds.resultado = plantograma.resultado;
                if (plantogramaEntidds.metodo == 0)
                {
                    plantogramaEntidds.aI = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.ai, formatoA4), 3));
                    plantogramaEntidds.diagnostica = Convert.ToString(plantograma.mensajeTipoPie(plantograma.resultado));
                }
                else
                {
                    plantogramaEntidds.aI = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosIA(plantograma.IA, formatoA4), 3));
                    plantogramaEntidds.diagnostica = Convert.ToString(plantograma.mensajeTipoPieMetodo2(plantogramaEntidds.aI));
                }
                Imagen.Instance.bitmap = Imagen.Instance.voltearImagenResultado(Imagen.Instance.bitmap);//como es pie izquierdo voltea la imagen

                Imagen.Instance.nombreArchivo = plantogramaEntidds.imgIzqAnlss;
                Imagen.Instance.nombreArchivoEditado = plantogramaEntidds.imgIzqAnlss;
                Imagen.Instance.guardarImgeEdit();//guardo la imagen
                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                plantogramaEntidds.imgIzqAnlss = Imagen.Instance.nombreArchivoEditado;//nuevo nombre de imagen analizado
                ln.UpdatePlan(plantogramaEntidds);//actualizo

                plantogramaEntidds = ln.PlantoID(plantogramaEntidds);//optenr el plantogrma modificdo
                imageIzquierdoAnalizado.ImageUrl = "~/img/" + plantogramaEntidds.imgIzqAnlss;//mostramos la imagen

                LinkButtonAnalizarIzquierdo.Visible = false;
                mostrarDatosDerechoResultado();
                mostrarDatosIzquierdoResultado();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" error al analizar imagen " + ex.Message);
                throw;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "tabSelectIzquierdo();", true);
        }

        protected void LinkButtonAnalizarDerecho_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Plantograma plantograma = new Entidades.Plantograma();
                plantogramaEntidds.metodoD = Convert.ToInt32(DropDownListTipoAnalisis.SelectedValue);

                if (plantogramaEntidds.metodoD == 0)
                {//hernandez corvo
                    Imagen.Instance.bitmap = plantograma.analizarImagen(Imagen.Instance.cambiarTamano(Imagen.Instance.getBitMap(plantogramaEntidds.imgDerAnlss)));
                }
                else
                {//metodo 2
                    guardarImagenDerechaAnalisisBase64(txtDataDerecho.Text);
                    Imagen.Instance.bitmap = plantograma.analizarImagenMedoto2(Imagen.Instance.cambiarTamano(Imagen.Instance.getBitMap(plantogramaEntidds.imgDerAnlss)));
                }

                /*
                plantogramaEntidds.xD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(Imagen.Instance.pixelToCentimetros(plantograma.X, Imagen.Instance.imgDpiX)), 3));
                plantogramaEntidds.yD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(Imagen.Instance.pixelToCentimetros(plantograma.Y, Imagen.Instance.imgDpiX)), 3));
                plantogramaEntidds.mFD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosHeight(Imagen.Instance.pixelToCentimetros(plantograma.mf, Imagen.Instance.imgDpiY)), 3));
                plantogramaEntidds.aID = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(Imagen.Instance.pixelToCentimetros(plantograma.ai, Imagen.Instance.imgDpiX)), 3));
                plantogramaEntidds.tAD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(Imagen.Instance.pixelToCentimetros(plantograma.talon, Imagen.Instance.imgDpiX)), 3));
                plantogramaEntidds.LongPieXD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(Imagen.Instance.pixelToCentimetros(plantograma.longitudPieX, Imagen.Instance.imgDpiX)), 3));
                plantogramaEntidds.LongPieYD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosHeight(Imagen.Instance.pixelToCentimetros(plantograma.longitudPieY, Imagen.Instance.imgDpiY)), 3));
                plantogramaEntidds.diagnosticaD = Convert.ToString(plantograma.mensajeTipoPie(plantograma.resultado));
                plantogramaEntidds.resultadoD = plantograma.resultado;*/


                plantogramaEntidds.xD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.X, formatoA4), 3));
                plantogramaEntidds.yD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.Y, formatoA4), 3));
                plantogramaEntidds.mFD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosHeight(plantograma.mf, formatoA4), 3));

                plantogramaEntidds.tAD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.talon, formatoA4), 3));
                plantogramaEntidds.LongPieXD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.longitudPieX, formatoA4), 3));
                plantogramaEntidds.LongPieYD = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosHeight(plantograma.longitudPieY, formatoA4), 3));

                plantogramaEntidds.resultadoD = plantograma.resultado;
                if (plantogramaEntidds.metodoD == 0)
                {
                    plantogramaEntidds.aID = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosWidth(plantograma.ai, formatoA4), 3));
                    plantogramaEntidds.diagnosticaD = Convert.ToString(plantograma.mensajeTipoPie(plantograma.resultado));
                }
                else
                {
                    plantogramaEntidds.aID = Convert.ToSingle(Math.Round(Imagen.Instance.optenerCentimetrosIA(plantograma.IA, formatoA4), 3));
                    plantogramaEntidds.diagnosticaD = Convert.ToString(plantograma.mensajeTipoPieMetodo2(plantogramaEntidds.aID));
                }

                Imagen.Instance.nombreArchivo = plantogramaEntidds.imgDerAnlss;
                Imagen.Instance.nombreArchivoEditado = plantogramaEntidds.imgDerAnlss;
                Imagen.Instance.guardarImgeEdit();//guardo la imagen

                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                plantogramaEntidds.imgDerAnlss = Imagen.Instance.nombreArchivoEditado;//nuevo nombre de imagen analizado
                ln.UpdatePlan(plantogramaEntidds);//actualizo
                plantogramaEntidds = ln.PlantoID(plantogramaEntidds);//optenr el plantogrma modificdo
                imageDerechoAnalizado.ImageUrl = "~/img/" + plantogramaEntidds.imgDerAnlss;//mostramos la imagen

                LinkButtonAnalizarDerecho.Visible = false;
                mostrarDatosDerechoResultado();
                mostrarDatosIzquierdoResultado();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" error al analizar imagen " + ex.Message);
                throw;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "tabSelectDerecho();", true);
        }

        private void mostrarDatosIzquierdoResultado()
        {



            lbresultadoPorcentajeIzquierdo.Text = Convert.ToString(plantogramaEntidds.resultado);

            //resultado

            descripcionIzquierdo.Text = Convert.ToString(plantogramaEntidds.diagnostica);
            //convertimos a cm por q estan los datos en pixeles
            //mf  Centimetros 
            lbmfIzquierdo.Text = Convert.ToString(plantogramaEntidds.mF);

            //X
            lbXIzquierdo.Text = Convert.ToString(plantogramaEntidds.x);

            //Y
            lbYIzquierdo.Text = Convert.ToString(plantogramaEntidds.y);

            //ai
            lbaiIzquierdo.Text = Convert.ToString(plantogramaEntidds.aI);

            //ta
            lbtaIzquierdo.Text = Convert.ToString(plantogramaEntidds.tA);

            lblogitudPieIzquierdo.Text = Convert.ToString(plantogramaEntidds.LongPieX + " X" + plantogramaEntidds.LongPieY);
            metodoIzquierda = plantogramaEntidds.metodo;
            //metdo 2 
            lbIAIzquierdoM2.Text = Convert.ToString(plantogramaEntidds.aI);
            lblogitudPieIzquierdoM2.Text = lblogitudPieIzquierdo.Text;
            descripcionIzquierdoM2.Text = Convert.ToString(plantogramaEntidds.diagnostica);
        }

        private void mostrarDatosDerechoResultado()
        {



            lbresultadoPorcentajeDerecho.Text = Convert.ToString(plantogramaEntidds.resultadoD);

            //resultado

            descripcionDerecho.Text = Convert.ToString(plantogramaEntidds.diagnosticaD);
            //convertimos a cm por q estan los datos en pixeles
            //mf  Centimetros 
            lbmfDerecho.Text = Convert.ToString(plantogramaEntidds.mFD);

            //X
            lbXDerecho.Text = Convert.ToString(plantogramaEntidds.xD);

            //Y
            lbYDerecho.Text = Convert.ToString(plantogramaEntidds.yD);

            //ai
            lbaiDerecho.Text = Convert.ToString(plantogramaEntidds.aID);

            //ta
            lbtaDerecho.Text = Convert.ToString(plantogramaEntidds.tAD);

            //
            lblogitudPieDerecho.Text = Convert.ToString(plantogramaEntidds.LongPieXD + " X" + plantogramaEntidds.LongPieYD);
            metodoDerecho = plantogramaEntidds.metodoD;
            //metodo2
            lbIADerechoM2.Text = Convert.ToString(plantogramaEntidds.aID);
            lblogitudPieDerechoM2.Text = lblogitudPieDerecho.Text;
            descripcionDerechoM2.Text = Convert.ToString(plantogramaEntidds.diagnosticaD);
        }

        protected void btnEditIzquierdo_Click(object sender, EventArgs e)
        {

            if (FileUploadPlantaIzquierdo.HasFile)
            {
                Imagen.Instance.GuardarImagen(FileUploadPlantaIzquierdo);
                plantogramaEntidds.imgIzq = Imagen.Instance.nombreArchivo;
                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                ln.UpdatePlan(plantogramaEntidds);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Actualización!','Se Realizo Correctamente','success','OK');", true);
                //System.Diagnostics.Debug.WriteLine("correcto");


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertNoRedirect('Error!','Seleccione una Imagen','error','OK');", true);
                //System.Diagnostics.Debug.WriteLine("click no datos");
                //string script = @"<script type='text/javascript'>
                //            alert('No ha seleccionado nada ');
                //        </script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            }

            // Response.Redirect(GetRouteUrl("PlantogramaShowRoute", new { idPlantograma = plantogramaEntidds.idPlantograma, id_grupo = grupo.idGrupo }));
            //System.Diagnostics.Debug.WriteLine("click Izquierdo");

        }

        protected void btnEditDerecho_Click(object sender, EventArgs e)
        {
            if (FileUploadPlantaDerecho.HasFile)
            {

                Imagen.Instance.GuardarImagen(FileUploadPlantaDerecho);
                plantogramaEntidds.imgDer = Imagen.Instance.nombreArchivo;
                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                ln.UpdatePlan(plantogramaEntidds);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Actualización!','Se Realizo Correctamente','success','OK');", true);
                //System.Diagnostics.Debug.WriteLine("correcto");
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("click no datos");
                //string script = @"<script type='text/javascript'>
                //            alert('No ha seleccionado ');
                //        </script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertNoRedirect('Error!','Seleccione una Imagen','error','OK');", true);
            }

            //Response.Redirect(GetRouteUrl("PlantogramaShowRoute", new { idPlantograma = plantogramaEntidds.idPlantograma, id_grupo = grupo.idGrupo }));
            //System.Diagnostics.Debug.WriteLine("click Derecho");
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
            plantogramaEntidds = ln.PlantoID(plantogramaEntidds);
            System.Diagnostics.Debug.WriteLine("print in plantograma ver...");
            string cadenaFinal = "";


            string path = System.Web.HttpContext.Current.Server.MapPath("/img/reporte3.png");
            string pathPacienteFoto = System.Web.HttpContext.Current.Server.MapPath("/" + usuario.foto);
            //string pathFoto = System.Web.HttpContext.Current.Server.MapPath("/img/"+profecional.foto);
            cadenaFinal += "<img src='" + path + "' Height='150' Width='570' /><br/>";

            cadenaFinal += " <TABLE  BORDER=1 BGCOLOR=#EFF8FB> <TR> <TD>Nombre:  " + usuario.nombres + "" + usuario.Apellidos + " 1</TD>  <TD ROWSPAN=4> <center><img style='text-align: center;border: solid 1px #ccc;border-radius: 20em;' src='" + pathPacienteFoto + "' Height='120' Width='120' /></center></TD>  <TD>Sexo:  " + sexo.descrpcion + "</TD></TR>" +
                "  <TR>  <TD> Ci:  " + usuario.cedula + "</TD>  <TD> Tipo Sangre:" + usuario.TipoSangre + "</TD>    </TR> " +
                "<TR>  <TD> Fecha Nacimiento:  " + usuario.fechaNacimiento + "</TD>  <TD>Ci Representante:  " + usuario.cedulaRepresentante + "</TD>    </TR>" +
                "<TR>  <TD> Fecha Nacimiento:  " + usuario.Telefono + "</TD>  <TD>Ci Representante:  " + usuario.resinto + "</TD>    </TR>" +
                " </ TABLE > <br/> ";




            string pathImgD = System.Web.HttpContext.Current.Server.MapPath("/img/" + plantogramaEntidds.imgDer);
            string pathImgIz = System.Web.HttpContext.Current.Server.MapPath("/img/" + plantogramaEntidds.imgIzq);
            string pathImgAnlD = System.Web.HttpContext.Current.Server.MapPath("/img/" + plantogramaEntidds.imgDerAnlss);
            string pathImgAnlIz = System.Web.HttpContext.Current.Server.MapPath("/img/" + plantogramaEntidds.imgIzqAnlss);

            cadenaFinal += addtableResultado(plantogramaEntidds, pathImgIz, pathImgD, pathImgAnlIz, pathImgAnlD);

            string path1 = System.Web.HttpContext.Current.Server.MapPath("/img/pie.jpg");
            cadenaFinal += "<img src='" + path1 + "' Height='100' Width='570' /><br/><br/>";

            CrearPdf pdf = new CrearPdf();
            pdf.crear(cadenaFinal);


        }
        public void guardarImagenIzquierdaAnalisisBase64(String dataBase64)
        {
            if (dataBase64 != null && dataBase64 != "")
            {
                int ubm = Convert.ToInt32(txtUmbralIzquierdo.Text.ToString());
                // System.Diagnostics.Debug.WriteLine("Img data->" + dataBase64.Replace("data:image/jpeg;base64,", ""));
                Imagen.Instance.guardarImgeEdit(plantogramaEntidds.imgIzqAnlss, dataBase64.Replace("data:image/png;base64,", ""), ubm);
                LNPlantogramaEntidads lnP = new LNPlantogramaEntidads();
                plantogramaEntidds.imgIzqAnlss = Imagen.Instance.nombreArchivoEditado;//nuevo nombre de imagen analizado
                lnP.UpdatePlan(plantogramaEntidds);//actualizo
                plantogramaEntidds = lnP.PlantoID(plantogramaEntidds);
            }
        }
        public void guardarImagenDerechaAnalisisBase64(String dataBase64)
        {
            if (dataBase64 != null && dataBase64 != "")
            {
                int ubm = Convert.ToInt32(txtUmbralDerecho.Text.ToString());
                //System.Diagnostics.Debug.WriteLine("Img data->" + dataBase64.Replace("data:image/png;base64,", ""));
                Imagen.Instance.guardarImgeEdit(plantogramaEntidds.imgDerAnlss, dataBase64.Replace("data:image/png;base64,", ""), ubm);
                LNPlantogramaEntidads lnP = new LNPlantogramaEntidads();
                plantogramaEntidds.imgDerAnlss = Imagen.Instance.nombreArchivoEditado;//nuevo nombre de imagen analizado
                lnP.UpdatePlan(plantogramaEntidds);//actualizo
                plantogramaEntidds = lnP.PlantoID(plantogramaEntidds);
            }
        }
        public string tipoMetodo(int metodo)
        {
            string cadena = "";
            if (metodo == 0)
            {
                cadena = "Hernández Corvo";
            }
            else
            {
                cadena += "Cavanagh y Rodgers";
            }
            return cadena;
        }
        public string verificarNombre(string name, int metodo)
        {
            string cadena = "";
            if (metodo == 0)
            {
                cadena = name;
            }
            return cadena;
        }

        public string tipoMetodoIAorAI(int metodo, float val)
        {
            string cadena = "";
            if (metodo == 0)
            {
                cadena = "Arco Interno: " + val;
            }
            else
            {
                cadena += "IA: " + val;
            }
            return cadena;
        }
        public string addtableResultado(PlantogramaEntidds plantogramaEntidds, string pathImgIz, string pathImgD, string pathImgAnlIz, string pathImgAnlD)
        {
            string cadenaFinal = "";
            cadenaFinal += "<TABLE  ><TR> <TD BGCOLOR=#F3E2A9 >PIE IZQUIERDO </TD> <TD BGCOLOR=#F3E2A9> PIE DERECHO</TD> </TR>  <BR/>" +
           "<TR>  <TD BGCOLOR=#F5ECCE>  <img src='" + pathImgIz + "' Height='380' Width='280' /></TD><TD BGCOLOR=#F3E2A9>   <img src='" + pathImgD + "' Height='380' Width='280' />  </TD> </TR>" +
           " <TR> <TD> </TD>  <TD> </TD> </TR>" +
             "<TR>  <TD BGCOLOR=#F5ECCE>  <img src='" + pathImgAnlIz + "' Height='380 Width='280' /> </TD><TD BGCOLOR=#F3E2A9>  <img src='" + pathImgAnlD + "' Height='380' Width='280' />  </TD> </TR>" +
              " <TR> <TD> </TD>  <TD> </TD> </TR>";

            cadenaFinal += "<TR> <TD BGCOLOR=#F5ECCE>Método:" + tipoMetodo(plantogramaEntidds.metodo) + " </TD>  <TD BGCOLOR=#F3E2A9>Método: " + tipoMetodo(plantogramaEntidds.metodoD) + " </TD> </TR>";

            cadenaFinal += "<TR>  <TD BGCOLOR=#F5ECCE>" + verificarNombre("X: ", plantogramaEntidds.metodo) + plantogramaEntidds.x + "</TD><TD BGCOLOR=#F3E2A9>" + verificarNombre("X: ", plantogramaEntidds.metodoD) + plantogramaEntidds.xD + " </TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>" + verificarNombre("Y: ", plantogramaEntidds.metodo) + plantogramaEntidds.y + " </TD><TD BGCOLOR=#F3E2A9>" + verificarNombre("Y: ", plantogramaEntidds.metodoD) + plantogramaEntidds.yD + " </TD> </TR>" + 
                                         "<TR> <TD BGCOLOR=#F5ECCE> " + verificarNombre("Medida Fundamenta: ", plantogramaEntidds.metodo) + plantogramaEntidds.mF + " </TD><TD BGCOLOR=#F3E2A9> " + verificarNombre("Medida Fundamental: ", plantogramaEntidds.metodoD) + plantogramaEntidds.mFD + "</TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>" + tipoMetodoIAorAI(plantogramaEntidds.metodo, plantogramaEntidds.aI) + " </TD><TD BGCOLOR=#F3E2A9>" + tipoMetodoIAorAI(plantogramaEntidds.metodoD, plantogramaEntidds.aID) + " </TD> </TR>" +
                                          "<TR>  <TD BGCOLOR=#F5ECCE>" + verificarNombre("Ta:", plantogramaEntidds.metodo) + plantogramaEntidds.tA + " </TD><TD BGCOLOR=#F3E2A9>" + verificarNombre("Ta:", plantogramaEntidds.metodoD) + plantogramaEntidds.tAD + "</TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>Long Pie Y: " + plantogramaEntidds.LongPieY + " </TD><TD BGCOLOR=#F3E2A9>Long Pie Y: " + plantogramaEntidds.LongPieYD + " </TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>Long Pie X: " + plantogramaEntidds.LongPieX + "</TD><TD BGCOLOR=#F3E2A9>Long Pie X :" + plantogramaEntidds.LongPieXD + " </TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>" + verificarNombre("Resultado: ", plantogramaEntidds.metodo) + plantogramaEntidds.resultado + "  </TD><TD BGCOLOR=#F3E2A9>" + verificarNombre("Resultado: ", plantogramaEntidds.metodoD) + plantogramaEntidds.resultadoD + " </TD> </TR>" +
                                        "<TR>  <TD BGCOLOR=#F5ECCE>Diagnostico: " + plantogramaEntidds.diagnostica + " </TD ><TD BGCOLOR=#F3E2A9>Dianostico: " + plantogramaEntidds.diagnosticaD + "</TD> </TR>" +
                                         "</TABLE> <br/>  <br/> <br/> <br/> <br/> ";

            return cadenaFinal;
        }
    }

}