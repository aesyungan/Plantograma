using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
   public class CodigoMPSAD
    {
        public List<CodigoMPS> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<CodigoMPS> list = new List<CodigoMPS>();


            while (Datos.Read())
            {
                CodigoMPS item = new CodigoMPS();

                item.id_codigoMPS = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public CodigoMPS CodigoMPSId(CodigoMPS codigoMPS)
        {
            CodigoMPS grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from CodigoMPS where id_codigoMPS=@id_codigoMPS");
            bd.AsignarParametroInt("@id_codigoMPS", codigoMPS.id_codigoMPS);

            foreach (CodigoMPS item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<CodigoMPS> MostrarCodigoMPS()
        {
            List<CodigoMPS> list = new List<CodigoMPS>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from CodigoMPS");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}
