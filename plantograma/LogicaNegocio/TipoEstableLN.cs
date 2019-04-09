using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class TipoEstableLN
    {
        public List<TipoEstable> Mostrar()
        {
            TipoEstableAD ln = new TipoEstableAD();
            return ln.MostrarTipoEstable();
        }
    }
}
