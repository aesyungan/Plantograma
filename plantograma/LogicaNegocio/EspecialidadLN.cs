using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
   public class EspecialidadLN
    {
        public List<Especialidad> Mostrar()
        {
            EspecialidadAD ln= new EspecialidadAD();
            return ln.MostraEspecialidad();
        }
    }
}
