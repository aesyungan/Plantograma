using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
    public class LugarAtencionAD
    {

        public List<LugarAtencion> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<LugarAtencion> list = new List<LugarAtencion>();


            while (Datos.Read())
            {
                LugarAtencion item = new LugarAtencion();

                item.id_lugarAtencion = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public LugarAtencion NacionalidadId(LugarAtencion lugarAtencion)
        {
            LugarAtencion grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from LugarAtencion where id_lugarAtencion=@id_lugarAtencion");
            bd.AsignarParametroInt("@id_lugarAtencion", lugarAtencion.id_lugarAtencion);

            foreach (LugarAtencion item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<LugarAtencion> MostrarLugarAtenciond()
        {
            List<LugarAtencion> list = new List<LugarAtencion>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from LugarAtencion");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}