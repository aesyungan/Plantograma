using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace LogicaNegocio
{
    public class TipoAnalisisLN
    {
        public List<TipoAnalisis> Mostrar()
        {
            List<TipoAnalisis> ls = new List<TipoAnalisis>();
            TipoAnalisis t1 = new TipoAnalisis();
            t1.id_tipo_analisis = 0;
            t1.descrpcion = "Hernández Corvo";
            TipoAnalisis t2 = new TipoAnalisis();
            t2.id_tipo_analisis = 1;
            t2.descrpcion = "Cavanagh y Rodgers";
            ls.Add(t1);
            ls.Add(t2);
            return ls;
        }
    }
}
