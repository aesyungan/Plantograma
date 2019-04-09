using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
    public class ProfecionalAD
    {

        public int InsertProfecional(Profecional item)

        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            //SELECT SCOPE_IDENTITY() retorna el id que fue insertado
                bd.CrearComandoStrSql("insert Profecional (nombres, apellidos, fechaNacimiento, ci, contrasenia, FirmaSello, id_sexo, id_formacionProfecional, id_especialidad, id_nacionalidad, id_autoidetificacion, id_codigoMPS,foto)" +
                " values(@nombres, @apellidos, @fechaNacimiento, @ci, @contrasenia, @FirmaSello, @id_sexo," +
                " @id_formacionProfecional, @id_especialidad, @id_nacionalidad, @id_autoidetificacion, @id_codigoMPS,@foto) SELECT SCOPE_IDENTITY()");

            bd.AsignarParametro("@nombres", item.nombres);
            bd.AsignarParametro("@apellidos", item.apellidos);
            bd.AsignarParametroFecha("@fechaNacimiento", item.fechaNacimiento);
            bd.AsignarParametro("@ci", item.ci);
            bd.AsignarParametro("@contrasenia", item.contrasenia);
            bd.AsignarParametro("@FirmaSello", item.FirmaSello);
            bd.AsignarParametroInt("@id_sexo", item.sexo.id_sexo);
            bd.AsignarParametroInt("@id_formacionProfecional", item.formacionProfecional.id_formacionProfecional);
            bd.AsignarParametroInt("@id_especialidad", item.especialidad.id_especialidad);
            bd.AsignarParametroInt("@id_nacionalidad", item.nacionalidad.id_nacionalidad);
            bd.AsignarParametroInt("@id_autoidetificacion", item.autoidetificacion.id_autoidetificacion);
            bd.AsignarParametroInt("@id_codigoMPS", item.codigoMPS.id_codigoMPS);
            bd.AsignarParametro("@foto", item.foto);
            //el id que fue insertado
            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }

        public int UpdateProfecional(Profecional item)

        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
           
            bd.CrearComandoStrSql("update Profecional set nombres=@nombres, apellidos=@apellidos, fechaNacimiento=@fechaNacimiento, ci=@ci, contrasenia=@contrasenia, FirmaSello=@FirmaSello, id_sexo=@id_sexo, id_formacionProfecional=@id_formacionProfecional, id_especialidad=@id_especialidad, id_nacionalidad=@id_nacionalidad, id_autoidetificacion=@id_autoidetificacion, id_codigoMPS=@id_codigoMPS,foto=@foto where id_Profecional="+item.id_Profecional+"");
            bd.AsignarParametro("@nombres", item.nombres);
            bd.AsignarParametro("@apellidos", item.apellidos);
            bd.AsignarParametroFecha("@fechaNacimiento", item.fechaNacimiento);
            bd.AsignarParametro("@ci", item.ci);
            bd.AsignarParametro("@contrasenia", item.contrasenia);
            bd.AsignarParametro("@FirmaSello", item.FirmaSello);
            bd.AsignarParametroInt("@id_sexo", item.sexo.id_sexo);
            bd.AsignarParametroInt("@id_formacionProfecional", item.formacionProfecional.id_formacionProfecional);
            bd.AsignarParametroInt("@id_especialidad", item.especialidad.id_especialidad);
            bd.AsignarParametroInt("@id_nacionalidad", item.nacionalidad.id_nacionalidad);
            bd.AsignarParametroInt("@id_autoidetificacion", item.autoidetificacion.id_autoidetificacion);
            bd.AsignarParametroInt("@id_codigoMPS", item.codigoMPS.id_codigoMPS);
            bd.AsignarParametro("@foto", item.foto);
            //el id que fue insertado
            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }




        public int UpdateGrupo(Profecional item)

        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            //SELECT SCOPE_IDENTITY() retorna el id que fue insertado
            bd.CrearComandoStrSql("");
            bd.AsignarParametro("@nombre", item.nombres);
            bd.AsignarParametro("@apellidos", item.apellidos);
            bd.AsignarParametroFecha("@fechaNacimiento", item.fechaNacimiento);
            bd.AsignarParametro("@ci", item.ci);
            bd.AsignarParametro("@contrasenia", item.contrasenia);
            bd.AsignarParametro("@firmaSello", item.FirmaSello);
            bd.AsignarParametroInt("@id_sexo", item.sexo.id_sexo);
            bd.AsignarParametroInt("@id_formacionProfecional", item.formacionProfecional.id_formacionProfecional);
            bd.AsignarParametroInt("@id_especialidad", item.especialidad.id_especialidad);
            bd.AsignarParametroInt("@id_nacionalidad", item.nacionalidad.id_nacionalidad);
            bd.AsignarParametroInt("@id_autoidetificacion", item.autoidetificacion.id_autoidetificacion);
            bd.AsignarParametroInt("@id_codigoMPS", item.codigoMPS.id_codigoMPS);
            bd.AsignarParametro("@foto", item.foto);
            //bd.AsignarParametroFecha("@fechaCreacion", item.fechaCreacion);
            //el id que fue insertado
            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }



        public List<Profecional> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Profecional> list = new List<Profecional>();


            while (Datos.Read())
            {
                Profecional item = new Profecional();

                item.id_Profecional = Convert.ToInt32(Datos.GetValue(0));
                item.nombres = Convert.ToString(Datos.GetValue(1));
                item.apellidos = Convert.ToString(Datos.GetValue(2));
                item.fechaNacimiento = Convert.ToDateTime(Datos.GetValue(3));
                item.ci = Convert.ToString(Datos.GetValue(4));
                item.contrasenia = Convert.ToString(Datos.GetValue(5));
                item.FirmaSello = Convert.ToString(Datos.GetValue(6));
                item.sexo.id_sexo = Convert.ToInt32(Datos.GetValue(7));
                item.formacionProfecional.id_formacionProfecional = Convert.ToInt32(Datos.GetValue(8));

                EspecialidadAD especialidadAD = new EspecialidadAD();
                item.especialidad.id_especialidad = Convert.ToInt32(Datos.GetValue(9));
                item.especialidad = especialidadAD.EspecialidadId(item.especialidad);

                item.nacionalidad.id_nacionalidad = Convert.ToInt32(Datos.GetValue(10));
                item.autoidetificacion.id_autoidetificacion = Convert.ToInt32(Datos.GetValue(11));
                item.codigoMPS.id_codigoMPS = Convert.ToInt32(Datos.GetValue(12));
                item.foto = Convert.ToString(Datos.GetValue(13));
                list.Add(item);
            }
            return list;
        }



        public void EliminarProfecional(Profecional item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("delete Profecional where id_Profecional =@id_Profecional");
            bd.AsignarParametroInt("@id_Profecional", item.id_Profecional);

            bd.EjecutarComando();
            bd.Desconectar();
        }



        public Profecional ProfecionalId(Profecional profecional)
        {
            Profecional grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select id_Profecional, nombres, apellidos, fechaNacimiento, ci, contrasenia, FirmaSello, id_sexo, id_formacionProfecional, id_especialidad, id_nacionalidad, id_autoidetificacion, id_codigoMPS, foto from Profecional  where id_Profecional= @id_Profecional");
            bd.AsignarParametroInt("@id_Profecional", profecional.id_Profecional);

            foreach (Profecional item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }

        public List<Profecional> MostrarProfecional()
        {
            List<Profecional> list = new List<Profecional>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Profecional");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

        public Profecional Logear(Profecional usuario)
        {

            Profecional user = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select  * from Profecional  where ci ='" + usuario.ci + "' AND contrasenia='" + usuario.contrasenia + "'");


            foreach (Profecional item in Mapear(bd.EjecutarConsulta()))
            {
                user = item;

            }
            bd.Desconectar();

            return user;

        }



    }

}