using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace plantograma
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://apprioturalexyungan.azurewebsites.net")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true,ResponseFormat = ResponseFormat.Json)]
        public void GetUsuarios()
        {//a json
            //instalar  Newtonsoft.Json por Manage Nuget Packages
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new PacienteLN().Mostrar(),
                Newtonsoft.Json.Formatting.Indented);
            //a objects lsit
            // List<Pacientes> products = JsonConvert.DeserializeObject<List<Pacientes>>(json);
            // Pacientes p = JsonConvert.DeserializeObject<Pacientes>(json);
            converyirToJson(json);
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true,ResponseFormat = ResponseFormat.Json)]
        public void Logear(string ci, string pass)
        {//a json
            Profecional usuario = new Profecional();
            usuario.ci = ci;
            usuario.contrasenia = pass;
            ProfecionalLN lnUsuario = new ProfecionalLN();

            usuario = lnUsuario.Login(usuario);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(usuario, Newtonsoft.Json.Formatting.Indented);
            converyirToJson(json);
        }
        public static void converyirToJson(object obj)
        {//Sin libreria
          //  System.Web.HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(obj));
          //con libreria
            System.Web.HttpContext.Current.Response.Write(obj);
        }
    }
}
