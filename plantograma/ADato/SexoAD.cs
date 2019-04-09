using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
    public class SexoAD
    {

        public List<Sexo> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Sexo> list = new List<Sexo>();


            while (Datos.Read())
            {
                Sexo item = new Sexo();

                item.id_sexo = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public Sexo SexoId(Sexo sexo)
        {
            Sexo grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Sexo where id_sexo=@id_sexo");
            bd.AsignarParametroInt("@id_sexo", sexo.id_sexo);

            foreach (Sexo item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<Sexo> MostrarSexo()
        {
            List<Sexo> list = new List<Sexo>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Sexo");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}
