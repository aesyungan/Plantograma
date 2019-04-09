using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
    public class LNResultado
    {

        public Resultado NumUsuario(Profecional profecional)
        {
            ResultadoAD acceso = new ResultadoAD();
            return acceso.UsuarioNum(profecional);
        }


        public Resultado cantidadHombre(Profecional profecional) {
            ResultadoAD acceso = new ResultadoAD();
            return acceso.CantidadHombre(profecional);
        }
        public Resultado cantidadMujer(Profecional profecional)
        {
            ResultadoAD acceso = new ResultadoAD();
            return acceso.CantidadMujer(profecional);
        }
        public Resultado cantidaPlantograma(Profecional profecional) {
            ResultadoAD acceso = new ResultadoAD();
            return acceso.CantidadPlantograma(profecional);
        }


        public Resultado cantidaHombreGrupo(Grupo grupo) {
            ResultadoAD acceso = new ResultadoAD();
            return acceso.CantidadHombreGrupo(grupo);
        }

        public Resultado cantidaMujerGrupo(Grupo grupo)
        {
            ResultadoAD acceso = new ResultadoAD();
            return acceso.CantidadMujerGrupo(grupo);
        }
        public Resultado cantidadPacienteGrupo(Grupo grupo)
        {
            ResultadoAD acceso = new ResultadoAD();
            return acceso.CantidadPacientesGrupo(grupo);
        }

        public List<Resultado> TiposDePie(Profecional item)
        {

            ResultadoAD acceso = new ResultadoAD();
            return acceso.TiposDePie(item);
        }
    }
}
