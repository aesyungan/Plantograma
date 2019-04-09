using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Entidades;
using LogicaNegocio;
namespace service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }
        [WebGet(RequestFormat = WebMessageFormat.Json, UriTemplate = "/Tutorial",ResponseFormat =WebMessageFormat.Json)]
        public List<Pacientes> GetAllTutorial()
        {
            return new LNUsuario().Mostrar();
        }
        [WebGet(RequestFormat = WebMessageFormat.Json,UriTemplate = "/nombre/{name}", ResponseFormat = WebMessageFormat.Json)]
        public String nombre(String name)
        {
            return "Hola:" + name;
        }
        // Add more operations here and mark them with [OperationContract]
    }
}
