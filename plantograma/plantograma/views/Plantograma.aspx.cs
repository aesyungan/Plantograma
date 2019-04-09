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
    public partial class Plantograma : System.Web.UI.Page
    {
        Pacientes usuario = new Pacientes();
        Grupo grupo = new Grupo();
      
        Sexo sexo = new Sexo();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {



                string id = Request.QueryString["id_Paciente"];
                usuario.id_Paciente = Convert.ToInt32(id);
                grupo.idGrupo = Convert.ToInt32(Request.QueryString["id_grupo"]);
                System.Diagnostics.Debug.WriteLine("usuario Id=" + usuario.id_Paciente);
                System.Diagnostics.Debug.WriteLine("grupo Id=" + grupo.idGrupo);
                PacienteLN pacienteLN = new PacienteLN();
                usuario = pacienteLN.PacienteID(usuario);
                LNUsuario lnu = new LNUsuario();
                // usuario = lnu.UsuarioID(usuario);
                cargarDatos(usuario, grupo);
                labelNombreUsuario.Text = usuario.nombres + " " + usuario.Apellidos;
                imagenUsuario.ImageUrl = "../" + usuario.foto;
            }
            catch (Exception)
            {

                Response.Redirect(GetRouteUrl("LoginRoute", null));
            }

        }
        public void cargarDatos(Pacientes usuario, Grupo grupo)
        {
            try
            {
                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                lvwDatos.DataSource = ln.PlantoUsuarioGrupo(usuario, grupo);

                //u.id_Paciente = Convert.ToInt32(Session["id_Paciente"].ToString());//muestra los grupos que tiene el usuario logeado



                lvwDatos.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


        protected void shopanelAdd(object sender, EventArgs e)
        {
            panelAllPlantograma.Visible = false;
            panelAddPlantograma.Visible = true;

        }
        protected void btnCalcel_Click(object sender, EventArgs e)
        {
            panelAllPlantograma.Visible = true;
            panelAddPlantograma.Visible = false;

        }
        protected void selectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            if (lvwDatos.SelectedIndex != e.NewSelectedIndex)
            {
                lvwDatos.SelectedIndex = e.NewSelectedIndex;
            }
            else
            {
                lvwDatos.SelectedIndex = -1;
            }
            //string idGrupo =  lvwDatos.SelectedDataKey.Value.ToString();
            lvwDatos.DataBind();
            //  Response.Write("<script>alert('" + lvwDatos.SelectedDataKey.Value.ToString() + "')</script>");
        }
        protected void btnVerClic(object sender, CommandEventArgs e)
        {
            try
            {
                PlantogramaEntidds plantogramaEntidds = new PlantogramaEntidds();
                plantogramaEntidds.idPlantograma = Convert.ToInt32(e.CommandArgument.ToString());

                // int correcto = UsuarioLN.getInstance().Eliminar(u);
                Response.Redirect(GetRouteUrl("PlantogramaShowRoute", new { idPlantograma = plantogramaEntidds.idPlantograma, id_grupo = grupo.idGrupo }),false);


            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void regresar(object sender, EventArgs e)
        {
           
            Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = grupo.idGrupo }),false);
           
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUploadPlantaDerecho.HasFile && FileUploadPlantaIzquierdo.HasFile)
                {
                    PlantogramaEntidds item = new PlantogramaEntidds();
                    Imagen.Instance.GuardarImagen(FileUploadPlantaDerecho);
                    item.imgDer = Imagen.Instance.nombreArchivo;
                    Imagen.Instance.GuardarImagen(FileUploadPlantaIzquierdo);
                    item.imgIzq = Imagen.Instance.nombreArchivo;
                    LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                    item.imgIzqAnlss = "";
                    item.imgDerAnlss = "";
                    item.x = 0;
                    item.y = 0;
                    item.mF = 0;
                    item.aI = 0;
                    item.tA = 0;
                    item.LongPieY = 0;
                    item.LongPieYD = 0;
                    item.LongPieX = 0;
                    item.LongPieXD = 0;
                    item.resultado = 0;
                    item.diagnostica = "";
                    item.diagnosticaD = "";
                    item.pacientes = usuario;
                    ln.InsertarPl(item);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Creación!','Se Realizo Correctamente','success','OK');", true);
                   // Response.Redirect(GetRouteUrl("PlantogramaRoute", new { id_Paciente = usuario.id_Paciente, id_grupo = grupo.idGrupo }));


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertNoRedirect('Error!','Debe subir las 2 huellas del pie','error','OK');", true);
                    //Response.Write("<script>alert('Debe Llenar Todos los Campos')</script>");
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void lnkRemove_Click(object sender, CommandEventArgs e)
        {
            try
            {

                PlantogramaEntidds p = new PlantogramaEntidds();
                p.idPlantograma = Convert.ToInt32(e.CommandArgument.ToString());
                LNPlantogramaEntidads ln = new LNPlantogramaEntidads();
                p = ln.PlantoID(p);
                p.estado = 0;
                ln.UpdateEliminar(p);
                System.Diagnostics.Debug.WriteLine("Eliminacion correcta");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Eliminación!','Se Realizo Correctamente','success','OK');", true);
               // Response.Redirect(GetRouteUrl("PlantogramaRoute", new { id_Paciente = usuario.id_Paciente, id_grupo = grupo.idGrupo }));


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("error" + ex.Message);

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("print");
            string cadenaFinal = "";


            string path = System.Web.HttpContext.Current.Server.MapPath("/img/reporte2.png");
            cadenaFinal += "<img src='" + path + "' Height='150' Width='570' /><br/><br/>";

            string pathPacienteFoto = System.Web.HttpContext.Current.Server.MapPath("/" + usuario.foto);


            cadenaFinal += " <TABLE  BORDER=1 BGCOLOR=#EFF8FB> <TR> <TD>Nombre:  " + usuario.nombres + "" + usuario.Apellidos + " 1</TD>  <TD ROWSPAN=4> <center><img style='text-align: center;border: solid 1px #ccc;border-radius: 20em;' src='" + pathPacienteFoto + "' Height='120' Width='120' /></center></TD>  <TD>Sexo:  " + sexo.descrpcion + "</TD></TR>" +
                "  <TR>  <TD> Ci:  " + usuario.cedula + "</TD>  <TD> Tipo Sangre:" + usuario.TipoSangre + "</TD>    </TR> " +
                "<TR>  <TD> Fecha Nacimiento:  " + usuario.fechaNacimiento + "</TD>  <TD>Ci Representante:  " + usuario.cedulaRepresentante + "</TD>    </TR>" +
                "<TR>  <TD> Fecha Nacimiento:  " + usuario.Telefono + "</TD>  <TD>Ci Representante:  " + usuario.resinto + "</TD>    </TR>" +
                " </ TABLE > <br/> ";
            LNPlantogramaEntidads ln = new LNPlantogramaEntidads();

            int i = 0;
            foreach (var plantogramaEntidds in ln.PlantoUsuarioGrupo(usuario, grupo))
            {
                i++;
                cadenaFinal += "<center><h2  style='text-align: center;width:100%;border: solid 1px #ccc;border-radius: 20em;' >" + i+"</h2></center>";
                cadenaFinal += "<h4>fecha:" + plantogramaEntidds.fechaCreacion.ToString()+"</h4> <br/>";
                string pathImgD = System.Web.HttpContext.Current.Server.MapPath("/img/" + plantogramaEntidds.imgDer);
                string pathImgIz = System.Web.HttpContext.Current.Server.MapPath("/img/" + plantogramaEntidds.imgIzq);
                string pathImgAnlD = System.Web.HttpContext.Current.Server.MapPath("/img/" + plantogramaEntidds.imgDerAnlss);
                string pathImgAnlIz = System.Web.HttpContext.Current.Server.MapPath("/img/" + plantogramaEntidds.imgIzqAnlss);

                cadenaFinal += "<TABLE  ><TR> <TD BGCOLOR=#F3E2A9 >PIE IZQUIERDO </TD> <TD BGCOLOR=#F3E2A9> PIE DERECHO</TD> </TR>  <BR/>" +
                "<TR>  <TD BGCOLOR=#F5ECCE>  <img src='" + pathImgIz + "' Height='380' Width='280' /></TD><TD BGCOLOR=#F3E2A9>   <img src='" + pathImgD + "' Height='380' Width='280' />  </TD> </TR>" +
                " <TR> <TD> </TD>  <TD> </TD> </TR>" +
                  "<TR>  <TD BGCOLOR=#F5ECCE>  <img src='" + pathImgAnlIz + "' Height='380 Width='280' /> </TD><TD BGCOLOR=#F3E2A9>  <img src='" + pathImgAnlD + "' Height='380' Width='280' />  </TD> </TR>" +
                   " <TR> <TD> </TD>  <TD> </TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE> X:  " + plantogramaEntidds.x + "</TD><TD BGCOLOR=#F3E2A9>X: " + plantogramaEntidds.xD + " </TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>Y: " + plantogramaEntidds.y + " </TD><TD BGCOLOR=#F3E2A9>Y:  " + plantogramaEntidds.yD + " </TD> </TR>" +
                                         "<TR> <TD BGCOLOR=#F5ECCE> Medida Fundamenta: " + plantogramaEntidds.mF + " </TD><TD BGCOLOR=#F3E2A9>Medida Fundamental: " + plantogramaEntidds.mFD + "</TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>Arco Interno: " + plantogramaEntidds.aI + " </TD><TD BGCOLOR=#F3E2A9>Arco Interno:" + plantogramaEntidds.aID + " </TD> </TR>" +
                                          "<TR>  <TD BGCOLOR=#F5ECCE>Ta: " + plantogramaEntidds.tA + " </TD><TD BGCOLOR=#F3E2A9>Ta: " + plantogramaEntidds.tAD + "</TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>Long Pie Y: " + plantogramaEntidds.LongPieY + " </TD><TD BGCOLOR=#F3E2A9>Long Pie Y: " + plantogramaEntidds.LongPieYD + " </TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>Long Pie X: " + plantogramaEntidds.LongPieX + "</TD><TD BGCOLOR=#F3E2A9>Long Pie X :" + plantogramaEntidds.LongPieXD + " </TD> </TR>" +
                                         "<TR>  <TD BGCOLOR=#F5ECCE>Resultado:" + plantogramaEntidds.resultado + "  </TD><TD BGCOLOR=#F3E2A9>Resultado:" + plantogramaEntidds.resultadoD + " </TD> </TR>" +
                                        "<TR>  <TD BGCOLOR=#F5ECCE>Diagnostico: " + plantogramaEntidds.diagnostica + " </TD ><TD BGCOLOR=#F3E2A9>Dianostico: " + plantogramaEntidds.diagnosticaD + "</TD> </TR>" +
                                         "</TABLE> <br/>  <br/> <br/> <br/> <br/> ";
                
            }
            cadenaFinal += "</center>";

            string path1 = System.Web.HttpContext.Current.Server.MapPath("/img/pie.jpg");
         

            CrearPdf pdf = new CrearPdf();
            pdf.crear(cadenaFinal);

        }
    }
}