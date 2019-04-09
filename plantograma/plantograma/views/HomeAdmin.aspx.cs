
using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace plantograma.views
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Profecional profecional = new Profecional();
            try
            {
                Profecional u = new Profecional();
                u.id_Profecional = Convert.ToInt32(Session["id_Profecional"].ToString());//muestra los grupos que tiene el usuario logeado
                LNResultado ln = new LNResultado();
                TextTotalPaciente.Text = ln.NumUsuario(u).cantidad.ToString();

                List<Resultado> listTipoPie = new List<Resultado>();
                List<Resultado> listTipoPieTop4 = new List<Resultado>();
                List<Resultado> listTipoPieTopRestante = new List<Resultado>();
                profecional.id_Profecional = Convert.ToInt32(Session["id_Profecional"].ToString());
                listTipoPie = ln.TiposDePie(profecional);
                for (int i = 0; i < (listTipoPie.Count / 2); i++)
                {
                    listTipoPieTop4.Add(listTipoPie[i]);
                }
                for (int i = listTipoPie.Count / 2; i < listTipoPie.Count; i++)
                {
                    listTipoPieTopRestante.Add(listTipoPie[i]);
                }

                ListViewTiposDeTie.DataSource = listTipoPieTopRestante;
                ListViewTiposDeTie.DataBind();

                ListViewTipoDePieRstante.DataSource = listTipoPieTop4;
                ListViewTipoDePieRstante.DataBind();

                cargarChart();
                txtCantidadHombres.Text = ln.cantidadHombre(profecional).cantidad.ToString();
                txtCantidadMujeres.Text= ln.cantidadMujer(profecional).cantidad.ToString();
                txtCantidadPlantograma.Text= ln.cantidaPlantograma(profecional).cantidad.ToString();

            }
            catch (Exception)
            {

                Response.Redirect(GetRouteUrl("LoginRoute", null));
            }

        }

        public void cargarChart()
        {
            Profecional p = new Profecional();
            LNResultado ln = new LNResultado();
            p.id_Profecional = Convert.ToInt32(Session["id_Profecional"].ToString());
            List<Resultado> lst = new List<Resultado>();
            lst = ln.TiposDePie(p);
            string[] x = new string[lst.Count];
            int[] y = new int[lst.Count];
            for (int i = 0; i < lst.Count; i++)
            {
                x[i] = lst[i].resultado;
                y[i] = lst[i].cantidad;
            }
            ChartTipoPie.Series[0].Points.DataBindXY(x, y);
            //ChartTipoPie.Series[0].YValueMembers = "Volume1";
            //ChartTipoPie.Series[0].XValueMember = "Date";
          //  ChartTipoPie.DataBind();
        }
    }
}