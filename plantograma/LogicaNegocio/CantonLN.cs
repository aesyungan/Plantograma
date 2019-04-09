using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
    public class CantonLN
    {
        public List<Canton> Mostrar()
        {
            CantonAD ln = new CantonAD();
            return ln.MostrarCanton();
        }

        public Canton CantonID(Canton canton)
        {
            CantonAD acceso = new CantonAD();
            return acceso.CantonId(canton);

        }


    }
}
