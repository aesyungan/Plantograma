using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
   public class SexoLN
    {
        public List<Sexo> Mostrar()
        {
            SexoAD acesso = new SexoAD();
            return acesso.MostrarSexo();
        }

    }
}
