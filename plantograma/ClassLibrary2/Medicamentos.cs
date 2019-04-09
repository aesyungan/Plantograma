
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Medicamentos
    {

     public int id_medicina { get; set; }
public string nombreMedicina { get; set; }
public string Rutina { get; set; }
 public Tratamientos tratamientos { get; set; }


        public Medicamentos() {
            tratamientos = new Tratamientos();
        }

    }
}
