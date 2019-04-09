using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlantogramaEntidds
    {
        public int idPlantograma { get; set; }
        public string imgIzq { get; set; }
        public string imgDer { get; set; }
        public string imgIzqAnlss { get; set; }
        public string imgDerAnlss { get; set; }
        public float x { get; set; }
        public float xD { get; set; }
        public float y { get; set; }
        public float yD { get; set; }
        public float mF { get; set; }
        public float mFD { get; set; }
        public float aI { get; set; }
        public float aID { get; set; }
        public float tA { get; set; }
        public float tAD { get; set; }
        public float LongPieY { get; set; }
        public float LongPieYD { get; set; }
        public float LongPieX { get; set; }
        public float LongPieXD { get; set; }
        public float resultado { get; set; }
        public float resultadoD { get; set; }
        public string diagnostica { get; set; }
        public string diagnosticaD { get; set; }
        public int estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        // public Citas citas { get; set; }
        public Pacientes pacientes { get; set; }
        public int metodo { get; set; }
        public int metodoD { get; set; }
        public PlantogramaEntidds()
        {

            pacientes = new Pacientes();
            metodo = 0;
            metodoD = 0;
        }


    }
}
