using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
    public class EspecialidadAD
    {


        public List<Especialidad> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Especialidad> list = new List<Especialidad>();


            while (Datos.Read())
            {
                Especialidad item = new Especialidad();

                item.id_especialidad = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public Especialidad EspecialidadId(Especialidad especialidad)
        {
            Especialidad grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Especialidad where id_especialidad=@id_especialidad");
            bd.AsignarParametroInt("@id_especialidad", especialidad.id_especialidad);

            foreach (Especialidad item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<Especialidad> MostraEspecialidad()
        {
            List<Especialidad> list = new List<Especialidad>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Especialidad");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}

