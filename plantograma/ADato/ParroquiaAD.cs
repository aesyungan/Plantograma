using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
   public class ParroquiaAD
    {
        public List<Parroquia> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Parroquia> list = new List<Parroquia>();


            while (Datos.Read())
            {
                Parroquia item = new Parroquia();

                item.id_Parroquia = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public Parroquia ParroquiaId(Parroquia parroquia)
        {
            Parroquia grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Parroquia where id_Parroquia=@id_Parroquia");
            bd.AsignarParametroInt("@id_Parroquia", parroquia.id_Parroquia);

            foreach (Parroquia item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<Parroquia> MostrarParroquia()
        {
            List<Parroquia> list = new List<Parroquia>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Parroquia");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}