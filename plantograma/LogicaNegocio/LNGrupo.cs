using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADato;
using Entidades;

namespace LogicaNegocio
{
    public class LNGrupo
    {
        public int Insertar(Grupo grupo)
        {
            GruposAD acesso = new GruposAD();
            return acesso.InsertGrupo(grupo);

        }
        public void UpdateG(Grupo item)
        {
            GruposAD acceso = new GruposAD();
            acceso.UpdateGrupo(item);
        }
        public void Eliminar(Grupo item)
        {
            GruposAD acesso = new GruposAD();
            acesso.EliminarGrupo(item);
        }
        public void CambiarEstado(Grupo item)
        {
            GruposAD acesso = new GruposAD();
            acesso.CambiarEstado(item);
        }
        public List<Grupo> MostrarGrupo()
        {
            GruposAD acesso = new GruposAD();
            return acesso.MostrarGrupo();
        }

        public Grupo IdGrupo(Grupo grupo)
        {
            GruposAD acceso = new GruposAD();
            return acceso.GrupoId(grupo);

        }
        public List<Grupo> Mostrar(Pacientes usuario)
        {
            GruposAD acesso = new GruposAD();
            return acesso.Mostrar(usuario);
        }
        public List<Grupo> Mostrar(Profecional usuario)
        {
            GruposAD acesso = new GruposAD();
            return acesso.Mostrar(usuario);
        }



    }
}
