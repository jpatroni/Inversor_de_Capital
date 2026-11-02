using System;
using Dominio;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InversionWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCalcular_Click(object sender, EventArgs e) // El botón está coordinando: carga las tasas, pide el promedio y después pide el capital final.
        {
            List<Banco> bancos;


            if (!IntentarCargarBancos(out bancos))
            {
                return;
            }
            try
            {
                InversionNegocio negocio = new InversionNegocio();
                List<ResultadoInversion> resultados =
    negocio.CalcularResultadosBancos(bancos, 850000m);
                MostrarResultados(resultados);



            }
            catch (ArgumentException ex)
            {
                lblResultado.Text = ex.Message;
            }

        }


        private bool IntentarCargarBancos(out List<Banco> bancos)
        {
            bancos = new List<Banco>();
            Banco provincia = new Banco();
            provincia.Nombre = "Banco Provincia";
            List<string> tasasProvincia = new List<string>
            {
                txtTasa1.Text,
                txtTasa2.Text,
                txtTasa3.Text
            };
            if (!IntentarCargarTasa(provincia, tasasProvincia)) // rovincia, utiliza la carga que ya funciona y agrega ese banco a una lista
            {
                return false;

            }
            bancos.Add(provincia);


            Banco nacion = new Banco();
            nacion.Nombre = "Banco Nación";
            List<string> tasasNacion = new List<string>
            {
                txtNacionTasa1.Text,
                txtNacionTasa2.Text,
                txtNacionTasa3.Text
            };
            if (!IntentarCargarTasa(nacion, tasasNacion))
            {
                return false;
            }

            bancos.Add(nacion);

            Banco hipotecario = new Banco();
            hipotecario.Nombre = "Banco Hipotecario";
            List<string> tasasHipotecario = new List<string>
{
    txtHipotecarioTasa1.Text,
    txtHipotecarioTasa2.Text,
    txtHipotecarioTasa3.Text
};
            if (!IntentarCargarTasa(hipotecario, tasasHipotecario))
            {
                return false;
            }

            bancos.Add(hipotecario);

            return true;
        }


        private bool IntentarCargarTasa(Banco banco, List<string> textoTasas)
        {
            

            foreach (string texto in textoTasas)
            {
                decimal tasa;

                if (!IntentarLeerTasa(texto, out tasa))
                {
                    lblResultado.Text = "Completá las tres tasas con números válidos mayores o iguales a cero.";
                    return false;
                }

                banco.TasasHistoricas.Add(tasa);
            }


            return true;
        }

        private bool IntentarLeerTasa(string texto, out decimal tasa)
        {
            return decimal.TryParse(texto, out tasa) && tasa >= 0;

        }


        private void MostrarResultados(List<ResultadoInversion> resultados)
        {
            lblResultado.Text = "";
            gvResultados.DataSource = resultados;
            gvResultados.DataBind();
        }
    }
}