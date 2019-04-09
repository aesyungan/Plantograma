using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace ADato
{
    public class CantonAD
    {
        public List<Canton> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Canton> list = new List<Canton>();


            while (Datos.Read())
            {
                Canton item = new Canton();

                item.id_Canton = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public Canton CantonId(Canton canton)
        {
            Canton grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Canton where id_Canton=@id_Canton");
            bd.AsignarParametroInt("@id_Canton", canton.id_Canton);

            foreach (Canton item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<Canton> MostrarCanton()
        {
            List<Canton> list = new List<Canton>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Canton");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}
