using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
    public class LNUsuario
    {
        public void Insertar( Pacientes usuario)
        {
            PacienteAD acesso = new PacienteAD();
            acesso.InsertPacientes(usuario);

        }
        public int InsertUsuarioReturnID(Pacientes usuario)
        {
            PacienteAD acesso = new PacienteAD();
           return acesso.InsertPacientes(usuario);

        }
        public void Eliminar(Pacientes item)
        {
            PacienteAD acesso = new PacienteAD();
          //  acesso.EliminarUsuario(item);
        }
        public List<Pacientes> Mostrar()
        {
            PacienteAD acesso = new PacienteAD();
            return acesso.MostrarPacientes();
        }

        //public Pacientes Login(Pacientes usuario)
        //{
        //    PacienteAD acceso = new PacienteAD();
        //    return acceso.(usuario);


        //}


        //public List<Pacientes> MostrarPaciente(Grupo grupo)
        //{
        //    PacienteAD acesso = new PacienteAD();
        //    return acesso.MostrarUsuario(grupo);
        //}

        //public List<Pacientes> MostrarIdUsuario(Grupo grupo)
        //{
        //    PacienteAD acesso = new PacienteAD();
        //    return acesso.MostraruUsuarioGrupo(grupo);
        //}

        //public List<Pacientes> BuscarUsuarioCEdula(Pacientes usuario, Grupo grupo)
        //{
        //    PacienteAD acesso = new PacienteAD();
        //    return acesso.MostraruUsuariCedula(usuario, grupo);
        //}


        //public Pacientes UsuarioID(Pacientes usuario) {
        //    PacienteAD acceso = new PacienteAD();
        //    return acceso.UsuarioId(usuario);
        //}

    }
}
