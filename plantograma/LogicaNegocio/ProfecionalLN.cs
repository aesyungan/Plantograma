using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ADato;

namespace LogicaNegocio
{
   public  class ProfecionalLN
    {
        public void Insertar(Profecional profecional)
        {
            ProfecionalAD acesso = new ProfecionalAD();
            acesso.InsertProfecional(profecional);

        }

        public void Update(Profecional profecional) {
            ProfecionalAD acceso = new ProfecionalAD();
            acceso.UpdateProfecional(profecional);
        }


        public List<Profecional> Mostrar()
        {
            ProfecionalAD acesso = new ProfecionalAD();
            return acesso.MostrarProfecional();
        }
        public Profecional ProfecionalID(Profecional profecional)
        {
            ProfecionalAD acesso = new ProfecionalAD();
            return acesso.ProfecionalId(profecional);
        }

        public Profecional Login(Profecional usuario)
        {
            ProfecionalAD acceso = new ProfecionalAD();
            return acceso.Logear(usuario);


        }


    }
}
