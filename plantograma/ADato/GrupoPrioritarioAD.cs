using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
    public class GrupoPrioritarioAD
    {
        public List<GrupoPrioritario> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<GrupoPrioritario> list = new List<GrupoPrioritario>();


            while (Datos.Read())
            {
                GrupoPrioritario item = new GrupoPrioritario();

                item.id_GrupoPrioritario = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public GrupoPrioritario GrupoPrioritarioId(GrupoPrioritario grupoPrioritario)
        {
            GrupoPrioritario grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from GrupoPrioritario where id_GrupoPrioritario=@id_GrupoPrioritario");
            bd.AsignarParametroInt("@id_GrupoPrioritario", grupoPrioritario.id_GrupoPrioritario);

            foreach (GrupoPrioritario item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<GrupoPrioritario> MostrarGrupoPrioritario()
        {
            List<GrupoPrioritario> list = new List<GrupoPrioritario>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from GrupoPrioritario");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}
