using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Resultado
    {
        public string resultado { get; set; }
        public int cantidad { get; set; }

      
        public Resultado(string resultado,int cantidad)
        {
            this.resultado = resultado;
            this.cantidad = cantidad;
        }
        
    }
}
