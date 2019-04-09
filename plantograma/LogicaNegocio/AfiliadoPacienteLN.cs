using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
  public  class AfiliadoPacienteLN
    {

        public List<AfiliadoPaciente> Mostrar()
        {
            AfiliadoPacienteAD ln = new AfiliadoPacienteAD();
            return ln.MostrarAfiliadoPaciente();
        }

        public AfiliadoPaciente AfiliadoPacienteID(AfiliadoPaciente afiliadoPaciente)
        {
            AfiliadoPacienteAD acceso = new AfiliadoPacienteAD();
            return acceso.AfiliadoPacienteId(afiliadoPaciente);

        }


    }
}
