using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
    public class PacienteLN
    {
        public int InsertUsuarioReturnID(Pacientes pacientes)
        {
            PacienteAD acesso = new PacienteAD();
            return acesso.InsertPacientes(pacientes);

        }
        //public int RemoveByEstado(Pacientes item)
        //{
        //    PacienteAD acesso = new PacienteAD();
        //    return acesso.RemoveByEstado(item);
        //}

        public int UpdatePaciente(Pacientes pacientes) {
            PacienteAD acceso = new  PacienteAD();
            return acceso.UpdatePacientes(pacientes);
        }

        //public void Eliminar(Pacientes item)
        //{
        //    PacienteAD acesso = new PacienteAD();
        //    acesso.(item);
        //}
        public List<Pacientes> Mostrar()
        {
            PacienteAD acesso = new PacienteAD();
            return acesso.MostrarPacientes();
        }


        public List<Pacientes> MostrarPacienteProfecional(Profecional profecional)
        {
            PacienteAD acesso = new PacienteAD();
            return acesso.PacientesIdProfecional(profecional);
        }
        public List<Pacientes> Listar(Grupo grupo)
        {
            PacienteAD acesso = new PacienteAD();
            return acesso.Listar(grupo);
        }



            //public List<Pacientes> BuscarUsuarioCEdula(Pacientes usuario, Grupo grupo)
            //{
            //    PacienteAD acesso = new PacienteAD();
            //    return acesso.MostraruUsuariCedula(usuario, grupo);
            //}


            public Pacientes PacienteID(Pacientes pacientes)
        {
            PacienteAD acceso = new PacienteAD();
            return acceso.PacientesId(pacientes);
        }

        public List<Pacientes> PacientesProfecionalNoAgregado(Grupo g)
        {
            PacienteAD acceso = new PacienteAD();
            return acceso.PacientesProfecionalNoAgregado(g);
        }

        public List<Pacientes> PacientesNoAgregadosByCedulaBuscar(Pacientes pacientes, Grupo g)
        {
            PacienteAD acceso = new PacienteAD();
            return acceso.PacientesNoAgregadosByCedulaBuscar(pacientes,g);
        }
    }
}
