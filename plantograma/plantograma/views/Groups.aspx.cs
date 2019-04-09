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
    public partial class Groups : System.Web.UI.Page
    {
       public Profecional profecional = new Profecional();
        public int idSelected = 0;
        public string test = "hola";
        static Grupo grupoEdit = new Grupo();//por q se le utliza en varias actualizaciones
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (IsPostBack != true)
                //{
                    cargarDatos();
                //}
                test = "datos cargados";

            }
            catch (Exception)
            {

                Response.Redirect(GetRouteUrl("LoginRoute", null));
            }

        }
        public void cargarDatos()
        {
            try
            {
                LNGrupo ln = new LNGrupo();
                profecional.id_Profecional = Convert.ToInt32(Session["id_Profecional"].ToString());//muestra los grupos que tiene el usuario logeado
                lvwDatos.DataSource = ln.Mostrar(profecional);

                lvwDatos.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void clickShowAdd(object sender, EventArgs e)
        {
            panelAllGroup.Visible = false;
            panelAddNewGroup.Visible = true;

        }

        protected void btnCalcel_Click(object sender, EventArgs e)
        {
            panelAllGroup.Visible = true;
            panelAddNewGroup.Visible = false;

        }



        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                Grupo grupo = new Grupo();
                grupo.idGrupo = 0;
                grupo.nombreUnidad = nombreUnidad.Text;
                LugarAtencion lugarAtencion = new LugarAtencion();
                lugarAtencion.id_lugarAtencion = Convert.ToInt32(DropDownListlugarAtencion.SelectedValue);
                grupo.lugarAtencion = lugarAtencion;
                TipoEstable tipoEstable = new TipoEstable();
                tipoEstable.id_tipoEstable = Convert.ToInt32(DropDownListTipoEstablecimiento.SelectedValue);
                grupo.tipoEstable = tipoEstable;
                InstitucionSistema institucionSistema = new InstitucionSistema();
                institucionSistema.id_institucionSistema = Convert.ToInt32(DropDownListInstituciondelSistema.SelectedValue);
                grupo.institucionSistema = institucionSistema;
                grupo.profecional = profecional;
                LNGrupo ln = new LNGrupo();
                ln.Insertar(grupo);
                //Response.Write("<script>alert(' Ingreso Correcto')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Creación!','Se Realizo Correctamente','success','OK');", true);
                // Response.Redirect(GetRouteUrl("GruposRoute", null));

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void verGroups(object sender, CommandEventArgs e)
        {
            try
            {
                Grupo item = new Grupo();
                item.idGrupo = Convert.ToInt32(e.CommandArgument.ToString());

                Response.Clear();

                Response.Redirect(GetRouteUrl("PacientesRoute", new { idGrupo = item.idGrupo }), false);


            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void btnEdit(object sender, CommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Editando..");
            Grupo item = new Grupo();
            LNGrupo ln = new LNGrupo();
            item.idGrupo = Convert.ToInt32(e.CommandArgument.ToString());
            item = ln.IdGrupo(item);
            grupoEdit = item;
            grupoEdit.idGrupo = Convert.ToInt32(e.CommandArgument.ToString());
            //datos en la vista
            nombreUnidadEdit.Text = item.nombreUnidad;
            LugarAtencionLN lugarAtencionLN = new LugarAtencionLN();
            //cargar Datos
            int indexSelected = 0;
            foreach (LugarAtencion ite in lugarAtencionLN.Mostrar())
            {
                if (ite.id_lugarAtencion == grupoEdit.lugarAtencion.id_lugarAtencion)
                {
                    DropDownListlugarAtencionEdit.SelectedValue = Convert.ToString(ite.id_lugarAtencion);//recupera 
                }
                indexSelected++;
            }
            TipoEstableLN tipoEstableLN = new TipoEstableLN();
            indexSelected = 0;
            foreach (TipoEstable ite in tipoEstableLN.Mostrar())
            {
                if (ite.id_tipoEstable == grupoEdit.tipoEstable.id_tipoEstable)
                {
                    DropDownListTipoEstablecimientoEdit.SelectedValue = Convert.ToString(ite.id_tipoEstable); ;//recupera 
                }
                indexSelected++;
            }
            InstitucionSistemaLN institucionSistemaLN = new InstitucionSistemaLN();
            indexSelected = 0;
            foreach (InstitucionSistema ite in institucionSistemaLN.Mostrar())
            {
                if (ite.id_institucionSistema == grupoEdit.institucionSistema.id_institucionSistema)
                {
                    DropDownListInstituciondelSistemaEdit.SelectedValue = Convert.ToString(ite.id_institucionSistema); ;//recupera 
                }
                indexSelected++;
            }
            panelAllGroup.Visible = false;
            panelEditGroup.Visible = true;
        }
        protected void btnremoveClic(object sender, CommandEventArgs e)
        {
            try
            {
                Grupo item = new Grupo();
                item.idGrupo = Convert.ToInt32(e.CommandArgument.ToString());

                LNGrupo ln = new LNGrupo();
                item = ln.IdGrupo(item);
                item.estado = 0;
                ln.CambiarEstado(item);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Eliminación!','Se Realizo Correctamente','success','OK');", true);
                //Response.Redirect(GetRouteUrl("GruposRoute", null));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("error" + ex.Message);

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
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

        protected void btnEditarPanel_Click(object sender, EventArgs e)
        {
            //editar
            try
            {

                Grupo item = grupoEdit;
                item.nombreUnidad = nombreUnidadEdit.Text;
                LugarAtencion lugarAtencion = new LugarAtencion();
                lugarAtencion.id_lugarAtencion = Convert.ToInt32(DropDownListlugarAtencionEdit.SelectedValue);
                item.lugarAtencion = lugarAtencion;
                TipoEstable tipoEstable = new TipoEstable();
                tipoEstable.id_tipoEstable = Convert.ToInt32(DropDownListTipoEstablecimientoEdit.SelectedValue);
                item.tipoEstable = tipoEstable;
                InstitucionSistema institucionSistema = new InstitucionSistema();
                institucionSistema.id_institucionSistema = Convert.ToInt32(DropDownListInstituciondelSistemaEdit.SelectedValue);
                item.institucionSistema = institucionSistema;
                item.profecional = profecional;
                LNGrupo ln = new LNGrupo();
                ln.UpdateG(grupoEdit);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Actualización!','Se Realizo Correctamente','success','OK');", true);
                //Response.Redirect(GetRouteUrl("GruposRoute", null));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error.." + ex.Message);
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void btnCalcelEdit_Click(object sender, EventArgs e)
        {
            panelAllGroup.Visible = true;
            panelEditGroup.Visible = false;

        }
    }

}