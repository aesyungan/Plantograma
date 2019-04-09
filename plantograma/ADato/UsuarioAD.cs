using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace ADato
{
    public class UsuarioAD
    {

        public void InsertUsuario(Pacientes item)

        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("insert Usuarios (nombre_usuario, ApellidoPaterno, ApellidoMaterno ,Sexo ,Edad,cedula ,email ,contrasenia ,TipoSangre ,Telefono ,Domicilio ,fechaNacimiento ,estado ,tipousuario, foto ) values( @nombre_usuario, @ApellidoPaterno, @ApellidoMaterno ,@Sexo ,@Edad,@cedula ,@email ,@contrasenia ,@TipoSangre ,@Telefono ,@Domicilio  ,@fechaNacimiento ,@estado ,@tipousuario,@foto)");

            //bd.AsignarParametro("@nombre_usuario", item.nombre_usuario);
            //bd.AsignarParametro("@ApellidoPaterno", item.ApellidoPaterno);
            //bd.AsignarParametro("@ApellidoMaterno", item.ApellidoMaterno);
            //bd.AsignarParametro("@Sexo", item.Sexo);
            //bd.AsignarParametroInt("@Edad", item.Edad);
            //bd.AsignarParametro("@cedula", item.cedula);
            //bd.AsignarParametro("@email", item.email);
            //bd.AsignarParametro("@contrasenia", item.contrasenia);
            //bd.AsignarParametro("@TipoSangre", item.TipoSangre);
            //bd.AsignarParametro("@Telefono", item.Telefono);
            //bd.AsignarParametro("@Domicilio", item.Domicilio);
            //bd.AsignarParametro("@fechaNacimiento", item.fechaNacimiento);
            //bd.AsignarParametroInt("@estado", item.estado);
            //bd.AsignarParametro("@tipousuario", item.tipousuario);
            //bd.AsignarParametro("@foto", item.foto);


          //  bd.AsignarParametroInt("@idGrupo",item.grupo.idGrupo);

            bd.EjecutarComando();
            bd.Desconectar();
        }

        public int InsertUsuarioReturnID(Pacientes item)

        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("insert Usuarios (nombre_usuario, ApellidoPaterno, ApellidoMaterno ,Sexo ,Edad,cedula ,email ,contrasenia ,TipoSangre ,Telefono ,Domicilio ,fechaNacimiento ,estado ,tipousuario, foto ) values( @nombre_usuario, @ApellidoPaterno, @ApellidoMaterno ,@Sexo ,@Edad,@cedula ,@email ,@contrasenia ,@TipoSangre ,@Telefono ,@Domicilio  ,@fechaNacimiento ,@estado ,@tipousuario,@foto) SELECT SCOPE_IDENTITY()");

            //bd.AsignarParametro("@nombre_usuario", item.nombre_usuario);
            //bd.AsignarParametro("@ApellidoPaterno", item.ApellidoPaterno);
            //bd.AsignarParametro("@ApellidoMaterno", item.ApellidoMaterno);
            //bd.AsignarParametro("@Sexo", item.Sexo);
            //bd.AsignarParametroInt("@Edad", item.Edad);
            //bd.AsignarParametro("@cedula", item.cedula);
            //bd.AsignarParametro("@email", item.email);
            //bd.AsignarParametro("@contrasenia", item.contrasenia);
            //bd.AsignarParametro("@TipoSangre", item.TipoSangre);
            //bd.AsignarParametro("@Telefono", item.Telefono);
            //bd.AsignarParametro("@Domicilio", item.Domicilio);
            //bd.AsignarParametro("@fechaNacimiento", item.fechaNacimiento);
            //bd.AsignarParametroInt("@estado", item.estado);
            //bd.AsignarParametro("@tipousuario", item.tipousuario);
            //bd.AsignarParametro("@foto", item.foto);


            //  bd.AsignarParametroInt("@idGrupo",item.grupo.idGrupo);

            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }


        public Pacientes Logear(Pacientes usuario) {

            Pacientes user = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select  * from Usuarios  where cedula ='" + usuario.cedula+"' AND contrasenia='"+usuario.Apellidos+"'");
        
            
            foreach (Pacientes item in Mapear(bd.EjecutarConsulta()))
            {
                user = item;

            }
            bd.Desconectar();
           
            return user;

        }

        public List<Pacientes> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Pacientes> list = new List<Pacientes>();            
        
          
            while (Datos.Read())
            {
                Pacientes item = new Pacientes();
                //item.id_usuario = Convert.ToInt32(Datos.GetValue(0));
                //item.nombre_usuario = Convert.ToString(Datos.GetValue(1));
                //item.ApellidoPaterno = Convert.ToString(Datos.GetValue(2));
                //item.ApellidoMaterno = Convert.ToString(Datos.GetValue(3));
                //item.Sexo = Convert.ToString(Datos.GetValue(4));
                //item.Edad = Convert.ToInt32(Datos.GetValue(5));
                //item.cedula = Convert.ToString(Datos.GetValue(6));
                //item.email = Convert.ToString(Datos.GetValue(7));
                //item.contrasenia = Convert.ToString(Datos.GetValue(8));
                //item.TipoSangre = Convert.ToString(Datos.GetValue(9));
                //item.Telefono = Convert.ToString(Datos.GetValue(10));
                //item.Domicilio = Convert.ToString(Datos.GetValue(11));                
                //item.fechaNacimiento = Convert.ToString(Datos.GetValue(12));
                //item.estado = Convert.ToInt32(Datos.GetValue(13));
                //item.tipousuario = Convert.ToString(Datos.GetValue(14));
                //item.foto = Convert.ToString(Datos.GetValue(15));
                //item.fechaCreacion = Convert.ToDateTime(Datos.GetDateTime(16));


                //item.grupo.idGrupo = Convert.ToInt32(Datos.GetValue(16));


                list.Add(item);
            }
            return list;
        }



        public void EliminarUsuario(Pacientes item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("delete Usuarios where id_usuario =@id_usuario");
            bd.AsignarParametroInt("@id_usuario", item.id_Paciente);

            bd.EjecutarComando();
            bd.Desconectar();
        }



        public List<Pacientes> MostraruUsuariCedula(Pacientes usuario , Grupo grupo)
        {


  
            List<Pacientes> list = new List<Pacientes>();
            
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
           // bd.CrearComandoStrSql("select DisTINCT  u.idUsuario,u.nombre_usuario,u.ApellidoPaterno, u.ApellidoMaterno,u.Sexo,u.Edad,u.cedula,u.email,u.contrasenia,u.TipoSangre,u.Telefono,u.Domicilio,u.fechaNacimiento,u.estado,u.tipousuario,u.foto, u.fechaCreacion from Usuarios as u inner join AsignacionGrupo  as ag on not u.idUsuario=ag.idUsuario where(not  ag.idGrupo = " + grupo.idGrupo + " and not  u.idUsuario = dbo.fN_creador_grupo(" + grupo.idGrupo + ")) and not u.idUsuario = dbo.fN_ver_si_esta_en_grupo(" + grupo.idGrupo + ", u.idUsuario) and u.cedula like '%"+usuario.cedula+"%'");
            bd.CrearComandoStrSql("select DisTINCT  u.idUsuario,u.nombre_usuario,u.ApellidoPaterno, u.ApellidoMaterno,u.Sexo,u.Edad,u.cedula,u.email,u.contrasenia,u.TipoSangre,u.Telefono,u.Domicilio,u.fechaNacimiento,u.estado,u.tipousuario,u.foto, u.fechaCreacion from Usuarios as u inner join AsignacionGrupo  as ag on not u.idUsuario=ag.idUsuario where( not  u.idUsuario = dbo.fN_creador_grupo(" + grupo.idGrupo + ")) and not u.idUsuario = dbo.fN_ver_si_esta_en_grupo(" + grupo.idGrupo + ", u.idUsuario) and u.cedula like '%" + usuario.cedula + "%'");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }


        public List<Pacientes> Mostrar()
        {
            List<Pacientes> list = new List<Pacientes>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select * from Usuarios");
            list= Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }





        public List<Pacientes> MostrarUsuario(Grupo grupo)
        {
            List<Pacientes> list = new List<Pacientes>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select  u.idUsuario, u.nombre_usuario,u.ApellidoPaterno,u.ApellidoMaterno,u.Sexo,u.Edad,u.cedula,u.email,u.contrasenia,u.TipoSangre,u.Telefono,u.Domicilio,u.fechaNacimiento,u.estado,u.tipousuario,u.foto, u.fechaCreacion from Usuarios as u inner join AsignacionGrupo ag on ag.idUsuario=u.idUsuario inner join  Grupo as g on  ag.idGrupo=g.idGrupo where ag.creador=0 and g.idGrupo=" + grupo.idGrupo);
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }


        //metodo return un usuario dado un id del grupo




        public List<Pacientes> MostraruUsuarioGrupo(Grupo grupo)
        {
            List<Pacientes> list = new List<Pacientes>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select DisTINCT  u.idUsuario,u.nombre_usuario,u.ApellidoPaterno, u.ApellidoMaterno,u.Sexo,u.Edad,u.cedula,u.email,u.contrasenia,u.TipoSangre,u.Telefono,u.Domicilio,u.fechaNacimiento,u.estado,u.tipousuario,u.foto, u.fechaCreacion from Usuarios as u inner join AsignacionGrupo  as ag on not u.idUsuario=ag.idUsuario where( u.idUsuario = dbo.fN_creador_grupo("+grupo.idGrupo+")) and not u.idUsuario = dbo.fN_ver_si_esta_en_grupo("+ grupo.idGrupo+", u.idUsuario)");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;
        }

        public Pacientes UsuarioId(Pacientes usuario) {

            Pacientes user = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select  u.idUsuario,u.nombre_usuario,u.ApellidoPaterno, u.ApellidoMaterno,u.Sexo,u.Edad,u.cedula,u.email,u.contrasenia,u.TipoSangre,u.Telefono,u.Domicilio,u.fechaNacimiento,u.estado,u.tipousuario,u.foto,u.fechaCreacion from Usuarios as u where u.idUsuario= @idUsuario");
            bd.AsignarParametroInt("@idUsuario",usuario.id_Paciente);

            foreach (Pacientes item in Mapear(bd.EjecutarConsulta()))
            {
                user = item;

            }
            bd.Desconectar();

            bd.Desconectar();
            return user;
        }

        


    }

}
