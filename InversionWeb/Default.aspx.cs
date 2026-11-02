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
            Banco banco = new Banco();
            banco.Nombre = "Banco Provincia";
            List<string> textoTasas = new List<string>
{
    txtTasa1.Text,
    txtTasa2.Text,
    txtTasa3.Text
};

            if (!IntentarCargarTasa(banco, textoTasas))
            {
                return;
            }
            try
            {
                InversionNegocio negocio = new InversionNegocio();
                List<ResultadoInversion> resultados =
    negocio.CalcularResultados(banco, 850000m);
                MostrarResultados(resultados);



            }
            catch (ArgumentException ex)
            {
                lblResultado.Text = ex.Message;
            }

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