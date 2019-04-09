using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADato;
using Entidades;

namespace LogicaNegocio
{
   public  class LNAsignarGrupo
    {

        public void IsertarGrupoUsuario(AsignacionGrupo asignacionGrupo)
        {

            AsignacionGrupoAD acceso = new AsignacionGrupoAD();
            acceso.InsertUser(asignacionGrupo);
        }
          public void EliminarAG(AsignacionGrupo asignacion)
        {
            AsignacionGrupoAD acceso = new AsignacionGrupoAD();
            acceso.eliminarAsig(asignacion);
        }

    }
}
