using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
   public class CodigoMPSLN
    {
        public List<CodigoMPS> Mostrar()
        {
            CodigoMPSAD ln = new CodigoMPSAD();
            return ln.MostrarCodigoMPS();
        }
    }
}
