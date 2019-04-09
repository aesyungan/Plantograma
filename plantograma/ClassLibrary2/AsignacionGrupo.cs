using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades

{
    public class AsignacionGrupo
    {
        public Grupo grupo { get; set; }
        public Pacientes pacientes { get; set; }
        public byte creador { get; set; }
      public DateTime fechaAsignacion { get; set; }

        public AsignacionGrupo()
        {
            grupo = new Grupo();
            pacientes = new Pacientes();
        }
    }
    
}
