using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace ADato
{
   public  class AutoidetificacionAD
    {
        public List<Autoidetificacion> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Autoidetificacion> list = new List<Autoidetificacion>();


            while (Datos.Read())
            {
                Autoidetificacion item = new Autoidetificacion();

                item.id_autoidetificacion = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public Autoidetificacion AutoidetificacionId(Autoidetificacion autoidetificacion)
        {
            Autoidetificacion grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Autoidetificacion where id_autoidetificacion=@id_autoidetificacion");
            bd.AsignarParametroInt("@id_autoidetificacion", autoidetificacion.id_autoidetificacion);

            foreach (Autoidetificacion item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<Autoidetificacion> MostrarAutoidetificacion()
        {
            List<Autoidetificacion> list = new List<Autoidetificacion>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Autoidetificacion");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}

