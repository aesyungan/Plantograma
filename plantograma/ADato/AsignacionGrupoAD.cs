using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
    public class AsignacionGrupoAD
    {
        public void InsertUser(AsignacionGrupo item)

        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("insert  AsignacionGrupo (idGrupo,id_Paciente,creador) values (@idGrupo,@id_Paciente,@creador)");
            bd.AsignarParametroInt("@idGrupo", item.grupo.idGrupo);
            bd.AsignarParametroInt("@id_Paciente", item.pacientes.id_Paciente);
            bd.AsignarParametrobyte("@creador",item.creador);
            bd.EjecutarComando();
            bd.Desconectar();
        }

        public void eliminarAsig(AsignacionGrupo item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("delete AsignacionGrupo where idGrupo = @idGrupo And id_Paciente=@id_Paciente");
            bd.AsignarParametroInt("@idGrupo",item.grupo.idGrupo);
            bd.AsignarParametroInt("@id_Paciente", item.pacientes.id_Paciente);
           // bd.CrearComandoStrSql("delete AsignacionGrupo where idGrupo ="+item.grupo.idGrupo+" And idUsuario="+item.usuario.id_usuario+"");
            
            bd.EjecutarComando();
            bd.Desconectar();
        }
    }
}
