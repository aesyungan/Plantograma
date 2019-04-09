using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADato
{
    public class PacienteAD
    {
        public int InsertPacientes(Pacientes item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            //SELECT SCOPE_IDENTITY() retorna el id que fue insertado
            bd.CrearComandoStrSql("INSERT INTO Paciente(nombres, Apellidos, cedula, fechaNacimiento, id_sexo, cedulaRepresentante, id_nacionalidad, id_autoidetificacion, id_AfiliadoPaciente, id_GrupoPrioritario, semanaGestacion, id_Provincia, id_Canton,  id_Parroquia, Resinto, TipoSangre, foto, Telefono) values(@nombres, @Apellidos, @cedula, @fechaNacimiento, @id_sexo, @cedulaRepresentante, @id_nacionalidad, @id_autoidetificacion, @id_AfiliadoPaciente, @id_GrupoPrioritario, @semanaGestacion, @id_Provincia, @id_Canton, @id_Parroquia, @Resinto, @TipoSangre, @foto, @Telefono) SELECT SCOPE_IDENTITY()");
            bd.AsignarParametro("@nombres", item.nombres);
            bd.AsignarParametro("@Apellidos", item.Apellidos);
            bd.AsignarParametro("@cedula", item.cedula);
            bd.AsignarParametroInt("@id_sexo ", item.sexo.id_sexo);
            bd.AsignarParametroFecha("@fechaNacimiento", item.fechaNacimiento);
            bd.AsignarParametro("@cedulaRepresentante", item.cedulaRepresentante);
            bd.AsignarParametroInt("@id_nacionalidad", item.Nacionalidad.id_nacionalidad);
            bd.AsignarParametroInt("@id_autoidetificacion", item.autoidetificacion.id_autoidetificacion);
            bd.AsignarParametroInt("@id_AfiliadoPaciente", item.afiliadoPaciente.id_AfiliadoPaciente);
            bd.AsignarParametroInt("@id_GrupoPrioritario", item.grupoPrioritario.id_GrupoPrioritario);
            bd.AsignarParametroInt("@semanaGestacion", item.semanaGestacion);
            bd.AsignarParametroInt("@id_Provincia", item.provincia.id_Provincia);
            bd.AsignarParametroInt("@id_Canton", item.canton.id_Canton);
            bd.AsignarParametroInt("@id_Parroquia", item.parroquia.id_Parroquia);
            bd.AsignarParametro("@Resinto", item.resinto);
            bd.AsignarParametro("@TipoSangre", item.TipoSangre);
            bd.AsignarParametro("@Telefono", item.Telefono);
            bd.AsignarParametro("@foto", item.foto);
            //el id que fue insertado

            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }

        public int UpdatePacientes(Pacientes item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            //SELECT SCOPE_IDENTITY() retorna el id que fue insertado
            bd.CrearComandoStrSql(" update Paciente set nombres = @nombres, Apellidos = @Apellidos, cedula = @cedula, id_sexo = @id_sexo, fechaNacimiento = @fechaNacimiento, cedulaRepresentante = @cedulaRepresentante, id_nacionalidad = @id_nacionalidad, id_autoidetificacion = @id_autoidetificacion, id_AfiliadoPaciente = @id_AfiliadoPaciente, id_GrupoPrioritario = @id_GrupoPrioritario, semanaGestacion = @semanaGestacion, id_Provincia = @id_Provincia, id_Canton = @id_Canton, id_Parroquia = @id_Parroquia, Resinto = @Resinto, TipoSangre = @TipoSangre, Telefono = @Telefono, foto = @foto, fechaRejistro = @fechaRejistro, estado = @estado where id_Paciente="+item.id_Paciente+"");
            bd.AsignarParametro("@nombres", item.nombres);
            bd.AsignarParametro("@Apellidos", item.Apellidos);
            bd.AsignarParametro("@cedula", item.cedula);
            bd.AsignarParametroInt("@id_sexo ", item.sexo.id_sexo);
            bd.AsignarParametroFecha("@fechaNacimiento", item.fechaNacimiento);
            bd.AsignarParametro("@cedulaRepresentante", item.cedulaRepresentante);
            bd.AsignarParametroInt("@id_nacionalidad", item.Nacionalidad.id_nacionalidad);
            bd.AsignarParametroInt("@id_autoidetificacion", item.autoidetificacion.id_autoidetificacion);
            bd.AsignarParametroInt("@id_AfiliadoPaciente", item.afiliadoPaciente.id_AfiliadoPaciente);
            bd.AsignarParametroInt("@id_GrupoPrioritario", item.grupoPrioritario.id_GrupoPrioritario);
            bd.AsignarParametroInt("@semanaGestacion", item.semanaGestacion);
            bd.AsignarParametroInt("@id_Provincia", item.provincia.id_Provincia);
            bd.AsignarParametroInt("@id_Canton", item.canton.id_Canton);
            bd.AsignarParametroInt("@id_Parroquia", item.parroquia.id_Parroquia);
            bd.AsignarParametro("@Resinto", item.resinto);
            bd.AsignarParametro("@TipoSangre", item.TipoSangre);
            bd.AsignarParametro("@Telefono", item.Telefono);
            bd.AsignarParametro("@foto", item.foto);
            bd.AsignarParametroFecha("@fechaRejistro", item.fechaRejistro);
            bd.AsignarParametroInt("@estado", item.estado);

            //el id que fue insertado

            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }





        public List<Pacientes> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Pacientes> list = new List<Pacientes>();


            while (Datos.Read())
            {
                Pacientes item = new Pacientes();

                item.id_Paciente = Convert.ToInt32(Datos.GetValue(0));
                item.nombres = Convert.ToString(Datos.GetValue(1));
                item.Apellidos = Convert.ToString(Datos.GetValue(2));
                item.cedula = Convert.ToString(Datos.GetValue(3));
                item.sexo.id_sexo = Convert.ToInt32(Datos.GetValue(4));
                item.fechaNacimiento = Convert.ToDateTime(Datos.GetValue(5));
                item.cedulaRepresentante = Convert.ToString(Datos.GetValue(6));
                item.Nacionalidad.id_nacionalidad = Convert.ToInt32(Datos.GetValue(7));
                item.autoidetificacion.id_autoidetificacion = Convert.ToInt32(Datos.GetValue(8));
                item.afiliadoPaciente.id_AfiliadoPaciente = Convert.ToInt32(Datos.GetValue(9));
                item.grupoPrioritario.id_GrupoPrioritario = Convert.ToInt32(Datos.GetValue(10));
                item.semanaGestacion = Convert.ToInt32(Datos.GetValue(11));
                item.provincia.id_Provincia = Convert.ToInt32(Datos.GetValue(12));
                item.canton.id_Canton= Convert.ToInt32(Datos.GetValue(13));
                item.parroquia.id_Parroquia = Convert.ToInt32(Datos.GetValue(14));
                item.resinto = Convert.ToString(Datos.GetValue(15));
                item.TipoSangre = Convert.ToString(Datos.GetValue(16));
                item.Telefono = Convert.ToString(Datos.GetValue(17));
                item.foto = Convert.ToString(Datos.GetValue(18));
                item.fechaRejistro = Convert.ToDateTime(Datos.GetValue(19));
                item.estado = Convert.ToInt32(Datos.GetValue(20));

                SexoAD sexoAD = new SexoAD();
                item.sexo = sexoAD.SexoId(item.sexo);   

                list.Add(item);
            }
            return list;
        }
        public Pacientes PacientesId(Pacientes pacientes)
        {
            Pacientes grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Paciente where id_Paciente= @id_Paciente");
          bd.AsignarParametroInt("@id_Paciente",pacientes.id_Paciente);

            foreach (Pacientes item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }

        public List <Pacientes> PacientesIdProfecional(Profecional profecional)
        {
            List<Pacientes> list = new List<Pacientes>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select p.id_Paciente, p.nombres, p.Apellidos, p.cedula, p.id_sexo, p.fechaNacimiento, p.cedulaRepresentante, p.id_nacionalidad, p.id_autoidetificacion, p.id_AfiliadoPaciente, p.id_GrupoPrioritario, p.semanaGestacion, p.id_Provincia, p.id_Canton, p.id_Parroquia, p.Resinto, p.TipoSangre, p.Telefono, p.foto, p.fechaRejistro, p.estado from Paciente  as p inner join   AsignacionGrupo ag  on  p.id_Paciente = ag.id_Paciente inner join Grupo as g on ag.idGrupo = g.idGrupo inner join Profecional as prof on prof.id_Profecional = g.id_Profecional where p.estado=1 and  prof.id_Profecional =" + profecional.id_Profecional+"");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

        public List<Pacientes> Listar(Grupo grupo)
        {
            List<Pacientes> list = new List<Pacientes>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select p.id_Paciente, p.nombres, p.Apellidos, p.cedula, p.id_sexo, p.fechaNacimiento, p.cedulaRepresentante, p.id_nacionalidad, p.id_autoidetificacion, p.id_AfiliadoPaciente, p.id_GrupoPrioritario, p.semanaGestacion, p.id_Provincia, p.id_Canton, p.id_Parroquia, p.Resinto, p.TipoSangre, p.Telefono, p.foto, p.fechaRejistro, p.estado from Paciente  as p inner join   AsignacionGrupo ag  on  p.id_Paciente = ag.id_Paciente inner join Grupo as g on ag.idGrupo = g.idGrupo inner join Profecional as prof on prof.id_Profecional = g.id_Profecional where p.estado=1 and g.idGrupo="+grupo.idGrupo);
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }
        public List<Pacientes> PacientesProfecionalNoAgregado(Grupo g)
        {
            List<Pacientes> list = new List<Pacientes>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select *from Paciente as p where  not p.id_Paciente=dbo.fN_ver_si_esta_en_grupo("+g.idGrupo+",p.id_Paciente)");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

        public List<Pacientes> PacientesNoAgregadosByCedulaBuscar(Pacientes pacientes,Grupo g )
        {
            List<Pacientes> list = new List<Pacientes>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select *from Paciente as p where  not p.id_Paciente=dbo.fN_ver_si_esta_en_grupo("+g.idGrupo+",p.id_Paciente) and p.cedula like'%"+pacientes.cedula+"%'");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }


        public List<Pacientes> MostrarPacientes()
        {
            List<Pacientes> list = new List<Pacientes>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Paciente");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }


    }
}
