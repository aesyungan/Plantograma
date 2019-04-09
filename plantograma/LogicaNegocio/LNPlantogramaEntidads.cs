using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

using ADato;

namespace LogicaNegocio
{
   public  class LNPlantogramaEntidads
    {

        public void InsertarPl(PlantogramaEntidds plantograma)
        {
            PnatogramaEntidadsAD acceso = new PnatogramaEntidadsAD();
            acceso.InsertPlantograma(plantograma);

        }
        public void UpdateEliminar(PlantogramaEntidds plantograma)
        {
            PnatogramaEntidadsAD acceso = new PnatogramaEntidadsAD();
            acceso.EliminarXupdate(plantograma);
        }

        public void UpdatePlan(PlantogramaEntidds plantograma) {
            PnatogramaEntidadsAD acceso = new PnatogramaEntidadsAD();
            acceso.UpdatePlantograma(plantograma);
        }

        public void eliminarPl(PlantogramaEntidds plantograma) {
            PnatogramaEntidadsAD acceso = new PnatogramaEntidadsAD();
            acceso.EliminarPlato(plantograma);

        }

        public List<PlantogramaEntidds> PlantoUsuarioGrupo(Pacientes usuario, Grupo grupo ) {
            PnatogramaEntidadsAD acceso = new PnatogramaEntidadsAD();
           return  acceso.MostrarUsuarioGrupo(usuario, grupo);
        }
       

        public List<PlantogramaEntidds> PlantogramaGrupo(Grupo grupo)
        {
            PnatogramaEntidadsAD acceso = new PnatogramaEntidadsAD();
            return acceso.PlantogramaGrupo( grupo);
        }

        public PlantogramaEntidds PlantoID(PlantogramaEntidds plantograma) {
            PnatogramaEntidadsAD acceso = new PnatogramaEntidadsAD();
            return acceso.PlantogramaID(plantograma);

        }
    }
}
