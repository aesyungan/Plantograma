using ADato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class InstitucionSistemaLN
    {
        public List<InstitucionSistema> Mostrar()
        {
            InstitucionSistemaAD ln = new InstitucionSistemaAD();
            return ln.MostrarInstitucionSistema();
        }
    }
}
