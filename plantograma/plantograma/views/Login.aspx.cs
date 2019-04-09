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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            Profecional usuario = new Profecional();
            usuario.ci = login_username.Text != null ? login_username.Text : "";
            usuario.contrasenia = login_password.Text != null ? login_password.Text : "";
            ProfecionalLN lnUsuario = new ProfecionalLN();

            usuario = lnUsuario.Login(usuario);
            if (usuario != null)
            {
                //guarda datos en session 
                //si se logeo corectamente
                Session["logeado"] = true;
                Session["id_Profecional"] = usuario.id_Profecional;
                Session["nombres"] = usuario.nombres;
                Session["apellidos"] = usuario.apellidos;
                Session["fechaNacimiento"] = usuario.fechaNacimiento;
                Session["ci"] = usuario.ci;
                Session["contrasenia"] = usuario.contrasenia;
                Session["foto"] = usuario.foto;
                //Session["foto"] = "";
                Session["FirmaSello"] = usuario.FirmaSello;
                Session["id_sexo"] = usuario.sexo.id_sexo;
                Session["id_formacionProfecional"] = usuario.formacionProfecional.id_formacionProfecional;
                Session["id_especialidad"] = usuario.especialidad.id_especialidad;
                Session["id_nacionalidad"] = usuario.nacionalidad.id_nacionalidad;
                Session["id_autoidetificacion"] = usuario.autoidetificacion.id_autoidetificacion;
                Session["id_codigoMPS"] = usuario.codigoMPS.id_codigoMPS;
                // Response.Redirect("HomeAdmin.aspx");
                Response.Redirect(GetRouteUrl("HomeAdminRoute", null));
            }
            else
            {
                //    string script = @"<script type='text/javascript'>
                //                alert('Error En Nombre de Usuario o Contraseña  ');
                //            </script>";
                //el script esta en js/app/appAlers.js
                //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "errorAlertLogin();", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertRedirect('Actualización','Correcta','success','OK','Register');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertNoRedirect('Error!','Usuario o Contraseña Incorrectos','error','OK');", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlertReload('Error!','Usuario o Contraseña Incorrectos','error','OK');", true);
            }
        }


    }
}