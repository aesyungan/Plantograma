using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
   public class ProvinciaAD
    {

        public List<Provincia> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Provincia> list = new List<Provincia>();


            while (Datos.Read())
            {
                Provincia item = new Provincia();

                item.id_Provincia = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public Provincia ProvinciaId(Provincia provincia)
        {
            Provincia grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Provincia where id_Provincia=@id_Provincia");
            bd.AsignarParametroInt("@id_Provincia", provincia.id_Provincia);

            foreach (Provincia item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<Provincia> MostrarProvincia()
        {
            List<Provincia> list = new List<Provincia>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Provincia");
            list = Mapear(bd.EjecutarConsulta());
            bd.Desconectar();
            return list;
        }

    }
}