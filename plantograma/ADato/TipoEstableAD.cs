using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADato
{
   public class TipoEstableAD
    {
        private List<TipoEstable> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<TipoEstable> list = new List<TipoEstable>();


            while (Datos.Read())
            {
                TipoEstable item = new TipoEstable();

                item.id_tipoEstable = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public TipoEstable TipoEstableId(TipoEstable TipoEstable)
        {
            TipoEstable grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from TipoEstable where id_TipoEstable=@id_TipoEstable");
            bd.AsignarParametroInt("@id_TipoEstable", TipoEstable.id_tipoEstable);

            foreach (TipoEstable item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<TipoEstable> MostrarTipoEstable()
        {
            List<TipoEstable> list = new List<TipoEstable>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from TipoEstable");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }
    }
}
