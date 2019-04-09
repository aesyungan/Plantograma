using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
   public  class NacionalidadAD
    {
        public List<Nacionalidad> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Nacionalidad> list = new List<Nacionalidad>();


            while (Datos.Read())
            {
                Nacionalidad item = new Nacionalidad();

                item.id_nacionalidad = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public Nacionalidad NacionalidadId(Nacionalidad nacionalidad)
        {
            Nacionalidad grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Nacionalidad where id_nacionalidad=@id_nacionalidad");
            bd.AsignarParametroInt("@id_nacionalidad", nacionalidad.id_nacionalidad);

            foreach (Nacionalidad item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<Nacionalidad> MostrarNacionalidad()
        {
            List<Nacionalidad> list = new List<Nacionalidad>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Nacionalidad");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}