using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
    public class GrupoPrioritarioLN
    {
        public List<GrupoPrioritario> Mostrar()
        {
            GrupoPrioritarioAD ln = new GrupoPrioritarioAD();
            return ln.MostrarGrupoPrioritario();
        }

        public GrupoPrioritario GrupoPrioritarioID(GrupoPrioritario GrupoPrioritario)
        {
            GrupoPrioritarioAD acceso = new GrupoPrioritarioAD();
            return acceso.GrupoPrioritarioId(GrupoPrioritario);

        }
    }
}
