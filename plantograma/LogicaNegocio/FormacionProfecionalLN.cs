using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class FormacionProfecionalLN
    {
        public List<FormacionProfecional> Mostrar() {
            FormacionProfecionalAD ln = new FormacionProfecionalAD();
            return ln.MostrarFormacionProfecional();
        }
      }
}
