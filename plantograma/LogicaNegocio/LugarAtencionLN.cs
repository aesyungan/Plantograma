using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
 public   class LugarAtencionLN
    {
        public List<LugarAtencion> Mostrar()
        {
            LugarAtencionAD ln = new LugarAtencionAD();
            return ln.MostrarLugarAtenciond();
        }
    }
}
