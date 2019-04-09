using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
   public class AfiliadoPacienteAD
    {
        public List<AfiliadoPaciente> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<AfiliadoPaciente> list = new List<AfiliadoPaciente>();


            while (Datos.Read())
            {
                AfiliadoPaciente item = new AfiliadoPaciente();

                item.id_AfiliadoPaciente = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public AfiliadoPaciente AfiliadoPacienteId(AfiliadoPaciente afiliadoPaciente)
        {
            AfiliadoPaciente grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from AfiliadoPaciente where id_AfiliadoPaciente=@id_AfiliadoPaciente");
            bd.AsignarParametroInt("@id_AfiliadoPaciente", afiliadoPaciente.id_AfiliadoPaciente); 

            foreach (AfiliadoPaciente item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<AfiliadoPaciente> MostrarAfiliadoPaciente()
        {
            List<AfiliadoPaciente> list = new List<AfiliadoPaciente>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from AfiliadoPaciente");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}