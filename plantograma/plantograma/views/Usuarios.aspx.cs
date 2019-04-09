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
    public partial class Usuarios : System.Web.UI.Page
    {
        Grupo grupo = new Grupo();
         Profecional profecional = new Profecional();
        static Pacientes pacientesEdit = new Pacientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                profecional.id_Profecional = Convert.ToInt32(Session["id_Profecional"].ToString());//profeccional logeado

                string id = Request.QueryString["idGrupo"];
                grupo.idGrupo = Convert.ToInt32(id);
                System.Diagnostics.Debug.WriteLine("grupo Id=" + grupo.idGrupo);
                LNGrupo lng = new LNGrupo();
                grupo = lng.IdGrupo(grupo);
                lbnameGrupo.Text = grupo.nombreUnidad;
                cargarDatos(grupo);
                if (pacientesEdit != null)
                {
                    //cargarDatosSelect(pacientesEdit);
                }
                cargarSeachPeopleDefaul();
                //default Foto
                ImgDefaulFoto.ImageUrl = "../img/User.png";
            }
            catch (Exception)
            {


                Response.Redirect(GetRouteUrl("LoginRoute", null));
            }
        }
        public void cargarDatos(Grupo g)
        {
            try
            {
                PacienteLN nUsuario = new PacienteLN();
                // nUsuario.Mostrar();
                lvwDatos.DataSource = nUsuario.Listar(g);
                lvwDatos.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        public void cargarSeachPeople()
        {

            PacienteLN nUsuario = new PacienteLN();
            // nUsuario.Mostrar();
            listSearchingPerson.DataSource = nUsuario.Mostrar();
            listSearchingPerson.DataBind();
            listSearchingPerson.DataSource = nUsuario.PacientesProfecionalNoAgregado(grupo);
            listSearchingPerson.DataBind();
        }

        public void cargarSeachPeopleDefaul()
        {

            PacienteLN nUsuario = new PacienteLN();
            // nUsuario.Mostrar();
            if (txt_searchItem.Text == "")
            {
                listSearchingPerson.DataSource = nUsuario.PacientesProfecionalNoAgregado(grupo);
                listSearchingPerson.DataBind();
            }
            else
            {
                Pacientes u = new Pacientes();
                u.cedula = txt_searchItem.Text;

                listSearchingPerson.DataSource = nUsuario.PacientesNoAgregadosByCedulaBuscar(u, grupo);
                System.Diagnostics.Debug.WriteLine("cedula  usuario =" + u.cedula + " -" + "id grupo = " + grupo.idGrupo);
                listSearchingPerson.DataBind();
            }

        }

        protected void btnVerClic(object sender, CommandEventArgs e)
        {
            try
            {
                Pacientes u = new Pacientes();
                u.id_Paciente = Convert.ToInt32(e.CommandArgument.ToString());

                // int correcto = UsuarioLN.getInstance().Eliminar(u);
                Response.Redirect(GetRouteUrl("PlantogramaRoute", new { id_Paciente = u.id_Paciente, id_grupo = grupo.idGrupo }),false);


            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void btnremoveClic(object sender, CommandEventArgs e)
        {
            try
            {
                Pacientes u = new Pacientes();
                u.id_Paciente = Convert.ToInt32(e.CommandArgument.ToString());
                LNAsignarGrupo ln = new LNAsignarGrupo();

                AsignacionGrupo asi = new AsignacionGrupo();
                asi.grupo = grupo;
                asi.pacientes = u;
                ln.EliminarAG(asi);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Eliminación!','Se Realizo Correctamente','success','OK');", true);
               // Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = grupo.idGrupo }));


            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void shopanelAdd(object sender, EventArgs e)
        {
            panelAllUsuario.Visible = false;
            panelAddUser.Visible = true;

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                panelAddUser.Visible = false;
                panelAllUsuario.Visible = true;
                LNAsignarGrupo ln = new LNAsignarGrupo();
                AsignacionGrupo ag = new AsignacionGrupo();
                Pacientes u = new Pacientes();
                u.id_Paciente = Convert.ToInt32(listSearchingPerson.SelectedDataKey.Value.ToString());
                ag.grupo = grupo;
                ag.pacientes = u;
                ag.creador = 0;
                ln.IsertarGrupoUsuario(ag);
               // System.Diagnostics.Debug.WriteLine(" Add persona   Id SElect =" + listSearchingPerson.SelectedDataKey.Value);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Creación!','Se Realizo Correctamente','success','OK');", true);


            }
            catch (Exception ex)
            {
                // Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = grupo.idGrupo }));
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
            finally
            {
               // Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = grupo.idGrupo }));
            }


        }

        protected void btnCalcel_Click(object sender, EventArgs e)
        {
            panelAddUser.Visible = false;
            panelAllUsuario.Visible = true;
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

        protected void selectedIndexChangingListSearch(object sender, ListViewSelectEventArgs e)
        {
            cargarSeachPeopleDefaul();

            listSearchingPerson.SelectedIndex = e.NewSelectedIndex;

            //string idGrupo =  lvwDatos.SelectedDataKey.Value.ToString();
            listSearchingPerson.DataBind();
            //  Response.Write("<script>alert('" + lvwDatos.SelectedDataKey.Value.ToString() + "')</script>");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PacienteLN ln = new PacienteLN();

            string buscar = txt_searchItem.Text;

            cargarSeachPeopleDefaul();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               
                PacienteLN data = new PacienteLN();
                List<Pacientes> lst = data.Mostrar();
                Boolean noExiste = true;
                Pacientes item = new Pacientes();
                item.id_Paciente = 0;
                item.nombres = register_nombres.Text;
                item.Apellidos = register_apellidos.Text;
                item.cedula = register_cedula.Text;
                Sexo sexo = new Sexo();
                sexo.id_sexo = Convert.ToInt32(DropDownListSexo.SelectedValue);
                item.sexo = sexo;

                DateTime dateTimefechaNacimiento = DateTime.Parse(register_fechaNacimiento.Text);
                item.fechaNacimiento = dateTimefechaNacimiento;
                item.cedulaRepresentante = register_cedula_representante.Text;
                Nacionalidad nacionalidad = new Nacionalidad();
                nacionalidad.id_nacionalidad = Convert.ToInt32(DropDownListNacionalidad.SelectedValue);
                item.Nacionalidad = nacionalidad;
                Autoidetificacion autoidetificacion = new Autoidetificacion();
                autoidetificacion.id_autoidetificacion = Convert.ToInt32(DropDownListAutoidentificación.SelectedValue);
                item.autoidetificacion = autoidetificacion;
                AfiliadoPaciente afiliadoPaciente = new AfiliadoPaciente();
                afiliadoPaciente.id_AfiliadoPaciente = Convert.ToInt32(DropDownListAfiliadoPaciente.SelectedValue);
                item.afiliadoPaciente = afiliadoPaciente;
                GrupoPrioritario grupoPrioritario = new GrupoPrioritario();
                grupoPrioritario.id_GrupoPrioritario = Convert.ToInt32(DropDownListGrupoPrioritario.SelectedValue);
                item.grupoPrioritario = grupoPrioritario;
                Provincia provincia = new Provincia();
                provincia.id_Provincia = Convert.ToInt32(DropDownListProvincia.SelectedValue);
                item.provincia = provincia;
                Canton canton = new Canton();
                canton.id_Canton = Convert.ToInt32(DropDownListCanton.SelectedValue);
                item.canton = canton;
                Parroquia parroquia = new Parroquia();
                parroquia.id_Parroquia = Convert.ToInt32(DropDownListParroquia.SelectedValue);
                item.parroquia = parroquia;
                item.resinto = register_resinto.Text;
                item.TipoSangre = DropDownLisTipoSangre.SelectedValue;
                item.Telefono = register_telefono.Text;
                if (FileUploadNewUser.HasFile)
                {
                    Imagen.Instance.GuardarImagen(FileUploadNewUser);
                    item.foto = "img/" + Imagen.Instance.nombreArchivo;
                }
                else
                {
                    item.foto = "img/User.png";
                }
               
                foreach (Pacientes ite in lst)
                {
                    if (ite.cedula.Equals(item.cedula))
                    {
                        noExiste = false;
                    }
                }
                if (noExiste)
                {
                    Pacientes u = new Pacientes();
                    u.id_Paciente = data.InsertUsuarioReturnID(item);//inserta y se va home 
                    LNAsignarGrupo lna = new LNAsignarGrupo();
                    AsignacionGrupo a = new AsignacionGrupo();
                    a.creador = 0;
                    a.grupo = grupo;
                    a.pacientes = u;
                    lna.IsertarGrupoUsuario(a);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Creación!','Se Realizo Correctamente','success','OK');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertNoRedirect('Error!','Usuario ya esta registrado','error','OK');", true);
                    //string script = @"<script type='text/javascript'>
                    //        alert('Usuario Ya registrado ');
                    //    </script>";
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    //redirecciona


                }
               // Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = grupo.idGrupo }));

            }
            catch (Exception ex)
            {
                Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = grupo.idGrupo }),false);
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }

        protected void lnkEdit_Command(object sender, CommandEventArgs e)
        {
            pacientesEdit = new Pacientes();
            mostrarEdit();
            pacientesEdit.id_Paciente = Convert.ToInt32(e.CommandArgument.ToString());
            PacienteLN ln = new PacienteLN();
            pacientesEdit = ln.PacienteID(pacientesEdit);
            cargarDatosSelect(pacientesEdit);
        }

        public void cargarDatosSelect(Pacientes pacientesEdit)
        {
            //cargar Datos
            Edit_register_nombres.Text = pacientesEdit.nombres;
            Edit_register_apellidos.Text = pacientesEdit.Apellidos;
            Edit_register_cedula.Text = pacientesEdit.cedula;

            SexoLN sexoLN = new SexoLN();
            List<Sexo> lstSexo = new List<Sexo>();
            foreach (Sexo item in sexoLN.Mostrar())
            {
                if (pacientesEdit.sexo.id_sexo == item.id_sexo)
                {
                    Edit_DropDownListSexo.SelectedValue = Convert.ToString(item.id_sexo);
                }
            }

            Edit_register_fechaNacimiento.Text = pacientesEdit.fechaNacimiento.ToString("yyyy-MM-dd");
            System.Diagnostics.Debug.WriteLine("fecha=" + pacientesEdit.fechaNacimiento.ToString("yyyy-MM-dd"));
            Edit_register_cedula_representante.Text = pacientesEdit.cedulaRepresentante;

            NacionalidadLN nacionalidadLN = new NacionalidadLN();
            List<Nacionalidad> lstNacionalidad = new List<Nacionalidad>();
            foreach (Nacionalidad item in nacionalidadLN.Mostrar())
            {
                if (pacientesEdit.Nacionalidad.id_nacionalidad == item.id_nacionalidad)
                {
                    Edit_DropDownListNacionalidad.SelectedValue = Convert.ToString(item.id_nacionalidad);
                }
            }

            AutoidetificacionLN autoidetificacionLN = new AutoidetificacionLN();
            List<Autoidetificacion> lstAutoidetificacion = new List<Autoidetificacion>();
            foreach (Autoidetificacion item in autoidetificacionLN.Mostrar())
            {
                if (pacientesEdit.autoidetificacion.id_autoidetificacion == item.id_autoidetificacion)
                {
                    Edit_DropDownListAutoidentificación.SelectedValue = Convert.ToString(item.id_autoidetificacion);
                }
            }

            AfiliadoPacienteLN afiliadoPacienteLN = new AfiliadoPacienteLN();
            List<AfiliadoPaciente> lstAfiliadoPaciente = new List<AfiliadoPaciente>();
            foreach (AfiliadoPaciente item in afiliadoPacienteLN.Mostrar())
            {
                if (pacientesEdit.afiliadoPaciente.id_AfiliadoPaciente == item.id_AfiliadoPaciente)
                {
                    Edit_DropDownListAfiliadoPaciente.SelectedValue = Convert.ToString(item.id_AfiliadoPaciente);
                }
            }

            GrupoPrioritarioLN grupoPrioritarioLN = new GrupoPrioritarioLN();
            List<GrupoPrioritario> lstGrupoPrioritarioe = new List<GrupoPrioritario>();
            foreach (GrupoPrioritario item in grupoPrioritarioLN.Mostrar())
            {
                if (pacientesEdit.grupoPrioritario.id_GrupoPrioritario == item.id_GrupoPrioritario)
                {
                    Edit_DropDownListGrupoPrioritario.SelectedValue = Convert.ToString(item.id_GrupoPrioritario);
                }
            }
            ProvinciaLN provinciaLN = new ProvinciaLN();
            List<Provincia> lstProvincia = new List<Provincia>();
            foreach (Provincia item in provinciaLN.Mostrar())
            {
                if (pacientesEdit.provincia.id_Provincia == item.id_Provincia)
                {
                    Edit_DropDownListProvincia.SelectedValue = Convert.ToString(item.id_Provincia);
                }
            }


            CantonLN cantonLN = new CantonLN();
            List<Canton> lstCanton = new List<Canton>();
            foreach (Canton item in cantonLN.Mostrar())
            {
                if (pacientesEdit.canton.id_Canton == item.id_Canton)
                {
                    Edit_DropDownListCanton.SelectedValue = Convert.ToString(item.id_Canton);
                }
            }

            ParroquiaLN parroquiaLN = new ParroquiaLN();
            List<Parroquia> lstParroquia = new List<Parroquia>();
            foreach (Parroquia item in parroquiaLN.Mostrar())
            {
                if (pacientesEdit.parroquia.id_Parroquia == item.id_Parroquia)
                {
                    Edit_DropDownListParroquia.SelectedValue = Convert.ToString(item.id_Parroquia);
                }
            }
            Edit_register_resinto.Text = pacientesEdit.resinto;
            Edit_DropDownLisTipoSangre.SelectedValue = pacientesEdit.TipoSangre;
            Edit_register_telefono.Text = pacientesEdit.Telefono;
            Edit_1ImagePerfil.ImageUrl = "../" + pacientesEdit.foto;
        }
        public void mostrarEdit()
        {
            panelEditPaciente.Visible = true;
            panelAllUsuario.Visible = false;
        }

        protected void btnCloseEdit_Click(object sender, EventArgs e)
        {
            panelAllUsuario.Visible = true;
            panelEditPaciente.Visible = false;
            Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = grupo.idGrupo }),false);
        }

        protected void btnEditPaciente_Click(object sender, EventArgs e)
        {
            Pacientes item = pacientesEdit;
            item.nombres = Edit_register_nombres.Text;
            item.Apellidos = Edit_register_apellidos.Text;
            item.cedula = Edit_register_cedula.Text;
            Sexo sexo = new Sexo();
            sexo.id_sexo = Convert.ToInt32(Edit_DropDownListSexo.SelectedValue);
            item.sexo = sexo;
            string fecha = Edit_register_fechaNacimiento.Text;
          
           // DateTime dateTimefechaNacimiento = DateTime.ParseExact(fecha, "yyyy-MM-dd", null);
            DateTime dateTimefechaNacimiento = DateTime.Parse(Edit_register_fechaNacimiento.Text.ToString());
            // DateTime dateTimefechaNacimiento = DateTime.Parse(Edit_register_fechaNacimiento.Text);
            item.fechaNacimiento = dateTimefechaNacimiento;
            item.cedulaRepresentante = Edit_register_cedula_representante.Text;
            Nacionalidad nacionalidad = new Nacionalidad();
            nacionalidad.id_nacionalidad = Convert.ToInt32(Edit_DropDownListNacionalidad.SelectedValue);
            item.Nacionalidad = nacionalidad;
            Autoidetificacion autoidetificacion = new Autoidetificacion();
            autoidetificacion.id_autoidetificacion = Convert.ToInt32(Edit_DropDownListAutoidentificación.SelectedValue);
            item.autoidetificacion = autoidetificacion;
            AfiliadoPaciente afiliadoPaciente = new AfiliadoPaciente();
            afiliadoPaciente.id_AfiliadoPaciente = Convert.ToInt32(Edit_DropDownListAfiliadoPaciente.SelectedValue);
            item.afiliadoPaciente = afiliadoPaciente;
            GrupoPrioritario grupoPrioritario = new GrupoPrioritario();
            grupoPrioritario.id_GrupoPrioritario = Convert.ToInt32(Edit_DropDownListGrupoPrioritario.SelectedValue);
            item.grupoPrioritario = grupoPrioritario;
            Provincia provincia = new Provincia();
            provincia.id_Provincia = Convert.ToInt32(Edit_DropDownListProvincia.SelectedValue);
            item.provincia = provincia;
            Canton canton = new Canton();
            canton.id_Canton = Convert.ToInt32(Edit_DropDownListCanton.SelectedValue);
            item.canton = canton;
            Parroquia parroquia = new Parroquia();
            parroquia.id_Parroquia = Convert.ToInt32(Edit_DropDownListParroquia.SelectedValue);
            item.parroquia = parroquia;
            item.resinto = Edit_register_resinto.Text;
            item.TipoSangre = Edit_DropDownLisTipoSangre.SelectedValue;
            item.Telefono = Edit_register_telefono.Text;
            if (Edit_1FileUploadFotoPerfil.HasFile)
            {
                Imagen.Instance.GuardarImagen(Edit_1FileUploadFotoPerfil);
                item.foto = "img/" + Imagen.Instance.nombreArchivo;
            }
            //item.foto = "graficos/avatar-2.jpg";
            PacienteLN pacienteLN = new PacienteLN();
            pacienteLN.UpdatePaciente(item);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Actualización!','Se Realizo Correctamente','success','OK');", true);
            //Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = grupo.idGrupo }));

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            LNResultado res = new LNResultado();
            LNPlantogramaEntidads pl = new LNPlantogramaEntidads();

            System.Diagnostics.Debug.WriteLine("print");
            string cadenaFinal = "";

            string path = System.Web.HttpContext.Current.Server.MapPath("/img/reporte1.png");
            cadenaFinal += "<img src='" + path + "' Height='150' Width='570' /><br/><br/>";
            cadenaFinal += "<table><tr> <h2> <td>" + res.cantidadPacienteGrupo(grupo).resultado + " </td></h2> </tr> </table>";

                cadenaFinal+= "<table BGCOLOR=#F5ECCE> <tr><td>Total Paciente: " + res.cantidadPacienteGrupo(grupo).cantidad.ToString()+ "</td>" +
                " <td> Total Hombres:" + res.cantidaHombreGrupo(grupo).cantidad.ToString() + " </td>" +
                " <td>Total Mujeres: " + res.cantidaMujerGrupo(grupo).cantidad.ToString() + " </tr></table> <br/> ";
            cadenaFinal += "<table border=1> <tr BGCOLOR=#FBF8EF ><td>Nombre</td> <td>Pie Izquierdo</td> <td> Pie Derecho</td> <td> Fecha Plantograma</td> </tr>";

            foreach (PlantogramaEntidds item in pl.PlantogramaGrupo(grupo))
            {
                cadenaFinal += "<tr>";
                cadenaFinal += "<td  BGCOLOR=#E0F8EC>" + item.pacientes.nombres + " " + item.pacientes.Apellidos+"</td>";
                cadenaFinal += "<td BGCOLOR=#E0F8EC>" + item.diagnostica + "</td>";
                cadenaFinal += "<td BGCOLOR=#E0F8EC>" + item.diagnosticaD + "</td>";
                cadenaFinal += "<td BGCOLOR=#E0F8EC>" + item.fechaCreacion.ToString("yyyy-MM-dd") + "</td>";
                cadenaFinal += "</tr>";
            }
            cadenaFinal += "</table>";
            CrearPdf pdf = new CrearPdf();
            pdf.crear(cadenaFinal);

        }
    }
}