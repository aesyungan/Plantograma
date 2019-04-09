using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADato
{
    public class InstitucionSistemaAD
    {
        private List<InstitucionSistema> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<InstitucionSistema> list = new List<InstitucionSistema>();


            while (Datos.Read())
            {
                InstitucionSistema item = new InstitucionSistema();

                item.id_institucionSistema = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public InstitucionSistema InstitucionSistemaId(InstitucionSistema InstitucionSistema)
        {
            InstitucionSistema grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from InstitucionSistema where id_InstitucionSistema=@id_InstitucionSistema");
            bd.AsignarParametroInt("@id_InstitucionSistema", InstitucionSistema.id_institucionSistema);

            foreach (InstitucionSistema item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<InstitucionSistema> MostrarInstitucionSistema()
        {
            List<InstitucionSistema> list = new List<InstitucionSistema>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from InstitucionSistema");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }
    }
}
