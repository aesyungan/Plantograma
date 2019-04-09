using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profecional
    {
        public int id_Profecional { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string ci { get; set; }
        public string contrasenia { get; set; }
        public string FirmaSello { get; set; }
        public CodigoMPS codigoMPS { get; set; }
        public Sexo sexo { get; set; }
        public FormacionProfecional formacionProfecional { get; set; }
        public Especialidad especialidad { get; set; }
        public Nacionalidad nacionalidad { get; set; }
        public string foto { get; set; }

        public Autoidetificacion autoidetificacion { get; set; }


        public Profecional()
        {
            codigoMPS = new CodigoMPS();
            sexo = new Sexo();
            formacionProfecional = new FormacionProfecional();
            especialidad = new Especialidad();
            nacionalidad = new Nacionalidad();
            autoidetificacion = new Autoidetificacion();
        }

    }
}
