using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
   public  class ProvinciaLN
    {
        public List<Provincia> Mostrar()
        {
            ProvinciaAD ln = new ProvinciaAD();
            return ln.MostrarProvincia();
        }

        public Provincia ProvinciaID(Provincia Provincia)
        {
            ProvinciaAD acceso = new ProvinciaAD();
            return acceso.ProvinciaId(Provincia);

        }


    }
}
