using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Grupo
    {
        public int idGrupo { get; set; }
        public string nombreUnidad { get; set; }
        public LugarAtencion lugarAtencion { get; set; }
         public TipoEstable tipoEstable { get; set; }
        public InstitucionSistema institucionSistema { get; set; }
        public Profecional profecional { get; set; }
        public int estado { get; set; }
        public Grupo()
        {
            lugarAtencion = new LugarAtencion();
            tipoEstable = new TipoEstable();
            institucionSistema = new InstitucionSistema();
            profecional = new Profecional();

        }


    }
}
