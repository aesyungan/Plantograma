using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
   public  class ParroquiaLN
    {
        public List<Parroquia> Mostrar()
        {
            ParroquiaAD ln = new ParroquiaAD();
            return ln.MostrarParroquia();
        }

        public Parroquia ParroquiaID(Parroquia parroquia)
        {
            ParroquiaAD acceso = new ParroquiaAD();
            return acceso.ParroquiaId(parroquia);

        }


    }
}
