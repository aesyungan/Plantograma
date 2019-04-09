using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
   public class AutoidetificacionLN
    {
        public List<Autoidetificacion> Mostrar()
        {
            AutoidetificacionAD ln = new AutoidetificacionAD();
            return ln.MostrarAutoidetificacion();
        }
    }
}
