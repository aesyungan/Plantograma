using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
  public  class NacionalidadLN
    {
        public List<Nacionalidad> Mostrar()
        {
            NacionalidadAD ln = new NacionalidadAD();
            return ln.MostrarNacionalidad();
        }
    }
}
