using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
    public class GruposAD
    {
        public int InsertGrupo(Grupo item)

        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            //SELECT SCOPE_IDENTITY() retorna el id que fue insertado
            bd.CrearComandoStrSql("INSERT INTO Grupo(nombreUnidad,id_lugarAtencion,id_tipoEstable,id_institucionSistema,id_Profecional) values(@nombreUnidad,@id_lugarAtencion,@id_tipoEstable,@id_institucionSistema,@id_Profecional) SELECT SCOPE_IDENTITY()");
            bd.AsignarParametro("@nombreUnidad", item.nombreUnidad);
            bd.AsignarParametroInt("@id_lugarAtencion", item.lugarAtencion.id_lugarAtencion);
            bd.AsignarParametroInt("@id_tipoEstable", item.tipoEstable.id_tipoEstable);
            bd.AsignarParametroInt("@id_institucionSistema", item.institucionSistema.id_institucionSistema);
            bd.AsignarParametroInt("@id_Profecional", item.profecional.id_Profecional);
            //el id que fue insertado
            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }

        public void UpdateGrupo(Grupo item)

        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            //SELECT SCOPE_IDENTITY() retorna el id que fue insertado
            bd.CrearComandoStrSql("update Grupo set nombreUnidad=@nombreUnidad,id_lugarAtencion=@id_lugarAtencion,id_tipoEstable=@id_tipoEstable ,id_institucionSistema=@id_institucionSistema ,id_Profecional=@id_Profecional, estado=@estado where idGrupo =@idGrupo");
            bd.AsignarParametro("@nombreUnidad", item.nombreUnidad);
            bd.AsignarParametroInt("@id_lugarAtencion", item.lugarAtencion.id_lugarAtencion);
            bd.AsignarParametroInt("@id_tipoEstable", item.tipoEstable.id_tipoEstable);
            bd.AsignarParametroInt("@id_institucionSistema", item.institucionSistema.id_institucionSistema);
            bd.AsignarParametroInt("@id_Profecional", item.profecional.id_Profecional);
            bd.AsignarParametroInt("@estado", item.estado);
            bd.AsignarParametroInt("@idGrupo", item.idGrupo);
            bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();

        }



        public List<Grupo> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Grupo> list = new List<Grupo>();


            while (Datos.Read())
            {
                Grupo item = new Grupo();

                item.idGrupo = Convert.ToInt32(Datos.GetValue(0));
                item.nombreUnidad = Convert.ToString(Datos.GetValue(1));
                item.lugarAtencion.id_lugarAtencion = Convert.ToInt32(Datos.GetValue(2));
                item.tipoEstable.id_tipoEstable = Convert.ToInt32(Datos.GetValue(3));
                item.institucionSistema.id_institucionSistema = Convert.ToInt32(Datos.GetValue(4));
                item.profecional.id_Profecional = Convert.ToInt32(Datos.GetValue(5));
                item.estado = Convert.ToInt32(Datos.GetValue(6));
                list.Add(item);
            }
            return list;
        }



        public void EliminarGrupo(Grupo item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("delete Grupo where idGrupo =@idGrupo");
            bd.AsignarParametroInt("@idGrupo", item.idGrupo);

            bd.EjecutarComando();
            bd.Desconectar();
        }

        public void CambiarEstado(Grupo item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("update Grupo set estado=@estado  where idGrupo =@idGrupo");
            bd.AsignarParametroInt("@estado", item.estado);
            bd.AsignarParametroInt("@idGrupo", item.idGrupo);
            bd.EjecutarComando();
            bd.Desconectar();
        }

        public Grupo GrupoId(Grupo grupo)
        {
            Grupo grup = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Grupo where idGrupo= @idGrupo");
            bd.AsignarParametroInt("@idGrupo", grupo.idGrupo);

            foreach (Grupo item in Mapear(bd.EjecutarConsulta()))
            {
                grup = item;

            }
            bd.Desconectar();

            return grup;
        }

        public List<Grupo> MostrarGrupo()
        {
            List<Grupo> list = new List<Grupo>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Grupo");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }




        public List<Grupo> Mostrar(Pacientes usuario)
        {
            List<Grupo> list = new List<Grupo>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select  g.idGrupo, g.nombre,g.descripcion,g.nombreEst,g.tipoestable,g.canton,g.parroquia, g.estado, g.fechaCreacion from  Grupo  g inner join AsignacionGrupo  Ag on g.idGrupo = Ag.idGrupo inner join Usuarios U on Ag.idUsuario = u.idUsuario where Ag.creador=1 and g.estado=1 and  u.idUsuario =" + usuario.id_Paciente);
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }
        public List<Grupo> Mostrar(Profecional usuario)
        {
            List<Grupo> list = new List<Grupo>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select g.idGrupo,g.nombreUnidad,g.id_lugarAtencion,g.id_tipoEstable,g.id_institucionSistema,g.id_Profecional,g.estado from Profecional as p inner join Grupo as g on p.id_Profecional=g.id_Profecional where g.estado=1 and p.id_Profecional=" + usuario.id_Profecional);
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }



    }

}
