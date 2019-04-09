using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{


    public class ResultadoAD
    {

        public Resultado UsuarioNum(Profecional profecional)
        {
            Resultado res = new Resultado("", 0);
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select res.nombres+''+res.apellidos as nombres,res.cantidad from (select p.id_Profecional,p.nombres,p.apellidos,count(*) as cantidad from Profecional as p inner join Grupo as g on p.id_Profecional=g.id_Profecional inner join AsignacionGrupo as ag on ag.idGrupo=g.idGrupo inner join Paciente  as ps on ag.id_Paciente=ps.id_Paciente  where p.id_Profecional=1 and ps.estado= 1 group by p.id_Profecional,p.nombres,p.apellidos)as res");
            foreach (Resultado item in Mapear(bd.EjecutarConsulta()))
            {
                res = item;

            }
            bd.Desconectar();

            return res;
        }
        public List<Resultado> TiposDePie(Profecional item)
        {
            List<Resultado> lst = new List<Resultado>();
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select res.tipo , count(*) as res from (select pla.diagnostica as tipo  from Grupo as g inner join AsignacionGrupo ag on ag.idGrupo=g.idGrupo inner join Paciente as p on p.id_Paciente=ag.id_Paciente inner join Plantograma as pla on pla.id_Paciente=p.id_Paciente where g.id_Profecional="+item.id_Profecional+"  union all select pla.diagnosticaD  from Grupo as g inner join AsignacionGrupo ag on ag.idGrupo=g.idGrupo inner join Paciente as p on p.id_Paciente=ag.id_Paciente inner join Plantograma as pla on pla.id_Paciente=p.id_Paciente where g.id_Profecional="+item.id_Profecional+") as res group by res.tipo");
            lst = Mapear(bd.EjecutarConsulta());
            bd.Desconectar();

            return lst;




        }


        public Resultado CantidadHombre(Profecional profecional)
        {
            Resultado res = new Resultado("", 0);
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select res.sexoPa, res.cantidad from  (select  s.descrpcion as sexoPa, count(*) as cantidad  from Paciente   as p  inner join  Sexo as s  on p.id_sexo = s.id_sexo inner join AsignacionGrupo as ag on ag.id_Paciente = p.id_Paciente inner join Grupo as g on  g.idGrupo = ag.idGrupo inner join Profecional as pr on pr.id_Profecional = g.id_Profecional where s.codigo = 1   and pr.id_Profecional ="+profecional.id_Profecional+" group by s.descrpcion) as res");
            foreach (Resultado item in Mapear(bd.EjecutarConsulta()))
            {
                res = item;

            }
            bd.Desconectar();

            return res;
        }
        public Resultado CantidadMujer(Profecional profecional)
        {
            Resultado res = new Resultado("", 0);
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select res.sexoPa, res.cantidad from  (select  s.descrpcion as sexoPa, count(*) as cantidad  from Paciente   as p  inner join  Sexo as s  on p.id_sexo = s.id_sexo inner join AsignacionGrupo as ag on ag.id_Paciente = p.id_Paciente inner join Grupo as g on  g.idGrupo = ag.idGrupo inner join Profecional as pr on pr.id_Profecional = g.id_Profecional where s.codigo = 2   and pr.id_Profecional =" + profecional.id_Profecional + " group by s.descrpcion) as res");
            foreach (Resultado item in Mapear(bd.EjecutarConsulta()))
            {
                res = item;

            }
            bd.Desconectar();

            return res;
        }

        public Resultado CantidadPlantograma(Profecional profecional)
        {
            Resultado res = new Resultado("", 0);
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("  select res.nombre , res.cantidad from  (select pr.nombres+ + pr.apellidos as nombre, count(*) as cantidad  from Plantograma as pl inner join Paciente as p on pl.id_Paciente= p.id_Paciente inner join AsignacionGrupo as ag on ag.id_Paciente = p.id_Paciente inner join Grupo as g on  g.idGrupo = ag.idGrupo inner join Profecional as pr on pr.id_Profecional = g.id_Profecional where pr.id_Profecional ="+profecional.id_Profecional+"  group by pr.nombres, pr.apellidos) as res ");
            foreach (Resultado item in Mapear(bd.EjecutarConsulta()))
            {
                res = item;

            }
            bd.Desconectar();

            return res;
        }


        public List<Resultado> Mapear(System.Data.Common.DbDataReader Datos)
        {
            List<Resultado> list = new List<Resultado>();


            while (Datos.Read())
            {
                Resultado item = new Resultado(Convert.ToString(Datos.GetValue(0).ToString()), Convert.ToInt32(Datos.GetValue(1)));
                list.Add(item);
            }
            return list;
        }




        public Resultado CantidadHombreGrupo(Grupo grupo)
        {
            Resultado res = new Resultado("", 0);
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("  select res.descrpcion, res.cantidad  from(select s.descrpcion ,count(*) as cantidad from Paciente   as p inner join  AsignacionGrupo  as ag on p.id_Paciente= ag.id_Paciente inner join Grupo as g on g.idGrupo = ag.idGrupo inner join Sexo as s on p.id_sexo = s.id_sexo where s.codigo = 1 and g.idGrupo ="+grupo.idGrupo+"  group by s.descrpcion) as res");
            foreach (Resultado item in Mapear(bd.EjecutarConsulta()))
            {
                res = item;

            }
            bd.Desconectar();

            return res;
        }

        public Resultado CantidadMujerGrupo(Grupo grupo)
        {
            Resultado res = new Resultado("", 0);
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("  select res.descrpcion, res.cantidad  from(select s.descrpcion ,count(*) as cantidad from Paciente   as p inner join  AsignacionGrupo  as ag on p.id_Paciente= ag.id_Paciente inner join Grupo as g on g.idGrupo = ag.idGrupo inner join Sexo as s on p.id_sexo = s.id_sexo where s.codigo = 2 and g.idGrupo =" + grupo.idGrupo + "  group by s.descrpcion) as res");
            foreach (Resultado item in Mapear(bd.EjecutarConsulta()))
            {
                res = item;

            }
            bd.Desconectar();

            return res;
        }


        public Resultado CantidadPacientesGrupo(Grupo grupo)
        {
            Resultado res = new Resultado("", 0);
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select res.nombreUnidad, res.cantidad  from(select g.nombreUnidad ,count(*) as cantidad from Paciente   as p inner join  AsignacionGrupo  as ag on p.id_Paciente= ag.id_Paciente inner join Grupo as g on g.idGrupo = ag.idGrupo where g.idGrupo ="+grupo.idGrupo+" group by g.nombreUnidad) as res");
            foreach (Resultado item in Mapear(bd.EjecutarConsulta()))
            {
                res = item;

            }
            bd.Desconectar();

            return res;
        }


    }
}
