using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ADato
{
    public class PnatogramaEntidadsAD
    {
        //insertar plantograma
        public int InsertPlantograma(PlantogramaEntidds item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("insert into Plantograma(imgIzq, imgDer, imgIzqAnlss, imgDerAnlss, x,xD, y,yD, mF,mFD, aI,aID, tA,tAD, LongPieY,LongPieYD,  LongPieX,LongPieXD,resultado,resultadoD, diagnostica, diagnosticaD, id_Paciente,metodo,metodoD)values(@imgIzq, @imgDer, @imgIzqAnlss, @imgDerAnlss, @x,@xD, @y,@yD, @mF,@mFD, @aI,@aID, @tA,@tAD, @LongPieY,@LongPieYD,@LongPieX,@LongPieXD, @resultado,@resultadoD, @diagnostica, @diagnosticaD, @id_Paciente,@metodo,@metodoD)");
            bd.AsignarParametro("@imgIzq", item.imgIzq);
            bd.AsignarParametro("@imgDer", item.imgDer);
            bd.AsignarParametro("@imgIzqAnlss", item.imgIzqAnlss);
            bd.AsignarParametro("@imgDerAnlss", item.imgDerAnlss);
            bd.AsignarParametroDecimal("@x", item.x);
            bd.AsignarParametroDecimal("@xD", item.xD);
            bd.AsignarParametroDecimal("@y", item.y);
            bd.AsignarParametroDecimal("@yD", item.yD);
            bd.AsignarParametroDecimal("@mF", item.mF);
            bd.AsignarParametroDecimal("@mFD", item.mFD);
            bd.AsignarParametroDecimal("@aI", item.aI);
            bd.AsignarParametroDecimal("@aID", item.aID);
            bd.AsignarParametroDecimal("@tA", item.tA);
            bd.AsignarParametroDecimal("@tAD", item.tAD);
            bd.AsignarParametroDecimal("@LongPieY", item.LongPieY);
            bd.AsignarParametroDecimal("@LongPieYD", item.LongPieYD);
            bd.AsignarParametroDecimal("@LongPieX", item.LongPieX);
            bd.AsignarParametroDecimal("@LongPieXD", item.LongPieXD);
            bd.AsignarParametroDecimal("@resultado", item.resultado);
            bd.AsignarParametroDecimal("@resultadoD", item.resultadoD);
            bd.AsignarParametro("@diagnostica", item.diagnostica);
            bd.AsignarParametro("@diagnosticaD", item.diagnosticaD);

            // bd.AsignarParametroFecha("@fecha",item.fecha);dig
            bd.AsignarParametroInt("@id_Paciente", item.pacientes.id_Paciente);
            bd.AsignarParametroInt("@metodo", item.metodo);
            bd.AsignarParametroInt("@metodoD", item.metodoD);
            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }



        public int UpdatePlantograma(PlantogramaEntidds item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();

            bd.CrearComandoStrSql("update  Plantograma set imgIzq=@imgIzq, imgDer=@imgDer, imgIzqAnlss=@imgIzqAnlss, imgDerAnlss=@imgDerAnlss, x=@x, xD=@xD,y=@y,yD=@yD, mF=@mF,mFD=@mFD, aI=@aI, aID=@aID,tA=@tA, tAD=@tAD,LongPieY=@LongPieY, LongPieYD=@LongPieYD, LongPieX=@LongPieX, LongPieXD=@LongPieXD,resultado=@resultado,resultadoD=@resultadoD, diagnostica=@diagnostica , diagnosticaD=@diagnosticaD ,id_Paciente=@id_Paciente ,metodo=@metodo ,metodoD=@metodoD where idPlantograma=" + item.idPlantograma + "");
            bd.AsignarParametro("@imgIzq", item.imgIzq);
            bd.AsignarParametro("@imgDer", item.imgDer);
            bd.AsignarParametro("@imgIzqAnlss", item.imgIzqAnlss);
            bd.AsignarParametro("@imgDerAnlss", item.imgDerAnlss);
            bd.AsignarParametroDecimal("@x", item.x);
            bd.AsignarParametroDecimal("@xD", item.xD);
            bd.AsignarParametroDecimal("@y", item.y);
            bd.AsignarParametroDecimal("@yD", item.yD);
            bd.AsignarParametroDecimal("@mF", item.mF);
            bd.AsignarParametroDecimal("@mFD", item.mFD);
            bd.AsignarParametroDecimal("@aI", item.aI);
            bd.AsignarParametroDecimal("@aID", item.aID);
            bd.AsignarParametroDecimal("@tA", item.tA);
            bd.AsignarParametroDecimal("@tAD", item.tAD);
            bd.AsignarParametroDecimal("@LongPieY", item.LongPieY);
            bd.AsignarParametroDecimal("@LongPieYD", item.LongPieYD);
            bd.AsignarParametroDecimal("@LongPieX", item.LongPieX);
            bd.AsignarParametroDecimal("@LongPieXD", item.LongPieXD);
            bd.AsignarParametroDecimal("@resultado", item.resultado);
            bd.AsignarParametroDecimal("@resultadoD", item.resultadoD);
            bd.AsignarParametro("@diagnostica", item.diagnostica);
            bd.AsignarParametro("@diagnosticaD", item.diagnosticaD);
            bd.AsignarParametroInt("@id_Paciente", item.pacientes.id_Paciente);
            bd.AsignarParametroInt("@metodo", item.metodo);
            bd.AsignarParametroInt("@metodoD", item.metodoD);
            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }


        public int EliminarXupdate(PlantogramaEntidds item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();

            bd.CrearComandoStrSql("update  Plantograma set imgIzq=@imgIzq, imgDer=@imgDer, imgIzqAnlss=@imgIzqAnlss, imgDerAnlss=@imgDerAnlss, x=@x, xD=@xD,y=@y,yD=@yD, mF=@mF,mFD=@mFD, aI=@aI, aID=@aID,tA=@tA, tAD=@tAD,LongPieY=@LongPieY, LongPieYD=@LongPieYD, LongPieX=@LongPieX, LongPieXD=@LongPieXD,resultado=@resultado,resultadoD=@resultadoD, diagnostica=@diagnostica , diagnosticaD=@diagnosticaD ,estado=@estado,id_Paciente=@id_Paciente ,metodo=@metodo ,metodoD=@metodoD where idPlantograma=" + item.idPlantograma + "");
            bd.AsignarParametro("@imgIzq", item.imgIzq);
            bd.AsignarParametro("@imgDer", item.imgDer);
            bd.AsignarParametro("@imgIzqAnlss", item.imgIzqAnlss);
            bd.AsignarParametro("@imgDerAnlss", item.imgDerAnlss);
            bd.AsignarParametroDecimal("@x", item.x);
            bd.AsignarParametroDecimal("@xD", item.xD);
            bd.AsignarParametroDecimal("@y", item.y);
            bd.AsignarParametroDecimal("@yD", item.yD);
            bd.AsignarParametroDecimal("@mF", item.mF);
            bd.AsignarParametroDecimal("@mFD", item.mFD);
            bd.AsignarParametroDecimal("@aI", item.aI);
            bd.AsignarParametroDecimal("@aID", item.aID);
            bd.AsignarParametroDecimal("@tA", item.tA);
            bd.AsignarParametroDecimal("@tAD", item.tAD);
            bd.AsignarParametroDecimal("@LongPieY", item.LongPieY);
            bd.AsignarParametroDecimal("@LongPieYD", item.LongPieYD);
            bd.AsignarParametroDecimal("@LongPieX", item.LongPieX);
            bd.AsignarParametroDecimal("@LongPieXD", item.LongPieXD);
            bd.AsignarParametroDecimal("@resultado", item.resultado);
            bd.AsignarParametroDecimal("@resultadoD", item.resultadoD);
            bd.AsignarParametro("@diagnostica", item.diagnostica);
            bd.AsignarParametro("@diagnosticaD", item.diagnosticaD);
            bd.AsignarParametroInt("@estado", item.estado);
            bd.AsignarParametroInt("@id_Paciente", item.pacientes.id_Paciente);
            bd.AsignarParametroInt("@metodo", item.metodo);
            bd.AsignarParametroInt("@metodoD", item.metodoD);
            int id = bd.EjecutarComandoSqlReturnID();
            bd.Desconectar();
            return id;
        }




        //eliminar plantograma
        public void EliminarPlato(PlantogramaEntidds item)
        {
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("delete Plantograma where idPlantograma=@idPlantograma ");
            bd.AsignarParametroInt("@idPlantograma", item.idPlantograma);
            bd.EjecutarComando();
            bd.Desconectar();


        }

        //mapear datos
        public List<PlantogramaEntidds> Mapear(System.Data.Common.DbDataReader Datos)
        {

            List<PlantogramaEntidds> list = new List<PlantogramaEntidds>();
            while (Datos.Read())
            {
                PlantogramaEntidds item = new PlantogramaEntidds();
                item.idPlantograma = Convert.ToInt32(Datos.GetValue(0));
                item.imgIzq = Convert.ToString(Datos.GetValue(1));
                item.imgDer = Convert.ToString(Datos.GetValue(2));
                item.imgIzqAnlss = Convert.ToString(Datos.GetValue(3));
                item.imgDerAnlss = Convert.ToString(Datos.GetValue(4));
                item.x = Convert.ToSingle(Datos.GetValue(5));
                item.xD = Convert.ToSingle(Datos.GetValue(6));
                item.y = Convert.ToSingle(Datos.GetValue(7));
                item.yD = Convert.ToSingle(Datos.GetValue(8));
                item.mF = Convert.ToSingle(Datos.GetValue(9));
                item.mFD = Convert.ToSingle(Datos.GetValue(10));
                item.aI = Convert.ToSingle(Datos.GetValue(11));
                item.aID = Convert.ToSingle(Datos.GetValue(12));
                item.tA = Convert.ToSingle(Datos.GetValue(13));
                item.tAD = Convert.ToSingle(Datos.GetValue(14));
                item.LongPieY = Convert.ToSingle(Datos.GetValue(15));
                item.LongPieYD = Convert.ToSingle(Datos.GetValue(16));
                item.LongPieX = Convert.ToSingle(Datos.GetValue(17));
                item.LongPieXD = Convert.ToSingle(Datos.GetValue(18));
                item.resultado = Convert.ToSingle(Datos.GetValue(19));
                item.resultadoD = Convert.ToSingle(Datos.GetValue(20));
                item.diagnostica = Convert.ToString(Datos.GetValue(21));
                item.diagnosticaD = Convert.ToString(Datos.GetValue(22));
                item.estado = Convert.ToInt32(Datos.GetValue(23));
                item.fechaCreacion = Convert.ToDateTime(Datos.GetValue(24));
                item.pacientes.id_Paciente = Convert.ToInt32(Datos.GetValue(25));
                item.metodo = Convert.ToInt32(Datos.GetValue(26));
                item.metodoD = Convert.ToInt32(Datos.GetValue(27));
                PacienteAD pacienteAD = new PacienteAD();

                item.pacientes = pacienteAD.PacientesId(item.pacientes);
                list.Add(item);

            }


            return list;
        }


        public List<PlantogramaEntidds> MostrarUsuarioGrupo(Pacientes usuario, Grupo grupo)
        {
            List<PlantogramaEntidds> list = new List<PlantogramaEntidds>();

            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select p.idPlantograma,p.imgIzq,p.imgDer,p.imgIzqAnlss,p.imgDerAnlss,p.x,p.xD,p.y,p.yD,p.mF,p.mFD,p.aI,p.aID,p.tA,p.tAD,p.LongPieY, p.LongPieYD,p.LongPieX, p.LongPieXD,p.resultado,p.resultadoD,p.diagnostica,p.diagnosticaD,p.estado,p.fechaCreacion,p.id_Paciente,p.metodo ,p.metodoD from Plantograma as p inner join  Paciente  as u on p.id_Paciente= u.id_Paciente inner join AsignacionGrupo as ag on u.id_Paciente= ag.id_Paciente where p.estado=1 and u.id_Paciente = " + usuario.id_Paciente + " and  ag.idGrupo = " + grupo.idGrupo + "");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;

        }


        public List<PlantogramaEntidds> PlantogramaGrupo(Grupo grupo)
        {
            List<PlantogramaEntidds> list = new List<PlantogramaEntidds>();

            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql("select  pl.idPlantograma,pl.imgIzq,pl.imgDer,pl.imgIzqAnlss,pl.imgDerAnlss,pl.x,pl.xD,pl.y,pl.yD,pl.mF,pl.mFD,pl.aI,pl.aID,pl.tA,pl.tAD,pl.LongPieY, pl.LongPieYD,pl.LongPieX, pl.LongPieXD,pl.resultado,pl.resultadoD,pl.diagnostica,pl.diagnosticaD,pl.estado,pl.fechaCreacion,pl.id_Paciente,pl.metodo,pl.metodoD  from Plantograma as pl inner join Paciente as p on p.id_Paciente=pl.id_Paciente  inner join AsignacionGrupo as ag on ag.id_Paciente = p.id_Paciente inner join Grupo as g on g.idGrupo = ag.idGrupo where g.idGrupo =" + grupo.idGrupo+"");
            list = Mapear(bd.EjecutarConsulta());


            bd.Desconectar();
            return list;

        }





        public PlantogramaEntidds PlantogramaID(PlantogramaEntidds plantogramaEntidds)
        {

            PlantogramaEntidds plantograma = null;
            BaseDatos bd = new BaseDatos();
            bd.Conectar();
            bd.CrearComandoStrSql(" select p.idPlantograma,p.imgIzq,p.imgDer,p.imgIzqAnlss,p.imgDerAnlss,p.x,p.xD,p.y,p.yD,p.mF,p.mFD,p.aI,p.aID,p.tA,p.tAD,p.LongPieY, p.LongPieYD,p.LongPieX, p.LongPieXD,p.resultado,p.resultadoD,p.diagnostica,p.diagnosticaD,p.estado,p.fechaCreacion,p.id_Paciente,p.metodo,p.metodoD  from Plantograma  as p where idPlantograma= @idPlantograma");

            bd.AsignarParametroInt("@idPlantograma", plantogramaEntidds.idPlantograma);

            foreach (PlantogramaEntidds item in Mapear(bd.EjecutarConsulta()))
            {
                plantograma = item;

            }
            bd.Desconectar();

            return plantograma;
        }


    }
}
