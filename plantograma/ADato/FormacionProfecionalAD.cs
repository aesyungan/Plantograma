using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
  public   class FormacionProfecionalAD
    {
        public List<FormacionProfecional> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<FormacionProfecional> list = new List<FormacionProfecional>();


            while (Datos.Read())
            {
                FormacionProfecional item = new FormacionProfecional();

                item.id_formacionProfecional = Convert.ToInt32(Datos.GetValue(0));
                item.codigo = Convert.ToInt32(Datos.GetValue(1));
                item.descrpcion = Convert.ToString(Datos.GetValue(2));

                list.Add(item);
            }
            return list;
        }

        public FormacionProfecional FormacionProfecionalId(FormacionProfecional formacionProfecional)
        {
            FormacionProfecional grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from FormacionProfecional where id_FormacionProfecional=@id_FormacionProfecional");
            bd.AsignarParametroInt("@id_FormacionProfecional", formacionProfecional.id_formacionProfecional);

            foreach (FormacionProfecional item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }


        public List<FormacionProfecional> MostrarFormacionProfecional()
        {
            List<FormacionProfecional> list = new List<FormacionProfecional>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from FormacionProfecional");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

    }
}
