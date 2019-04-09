using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pacientes
    {

        public int id_Paciente { get; set; }
        public string nombres { get; set; }
        public string Apellidos { get; set; }
        public string cedula { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string cedulaRepresentante { get; set; }
        public string TipoSangre { get; set; }
        public string Telefono { get; set; }
        public string foto { get; set; }
        public int semanaGestacion { get; set; }
        public DateTime fechaRejistro { get; set; }
        public Nacionalidad Nacionalidad { get; set; }
        public Autoidetificacion autoidetificacion { get; set; }
        public AfiliadoPaciente afiliadoPaciente { get; set; }
        public GrupoPrioritario grupoPrioritario { get; set; }
        public Provincia provincia { get; set; }
        public Canton canton { get; set; }
        public Parroquia parroquia { get; set; }
        public string resinto { get; set; }
        public Sexo sexo{ get; set; }
        public int estado { get; set; }


        public Pacientes()
        {
            Nacionalidad = new Nacionalidad();
            autoidetificacion = new Autoidetificacion();
            afiliadoPaciente = new AfiliadoPaciente();
            grupoPrioritario = new GrupoPrioritario();
            provincia = new Provincia();
            canton = new Canton();
            parroquia = new Parroquia();
           
            sexo = new Sexo();

        }

    }
}