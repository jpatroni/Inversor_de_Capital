using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio  // para acordarme Esta clase representa el resultado de una inversión concreta
{
    public class ResultadoInversion
    {
        public Banco Banco { get; set; }
        public ModalidadInversion Modalidad { get; set; }

        // prop 
        public decimal TasaAnualPromedio { get; set; }
        public decimal CapitalInicial { get; set; }
        public decimal CapitalFinal { get; set; }

        public decimal Ganancia
        {

            get
            {
                return CapitalFinal - CapitalInicial;
            }

        }


    }
}
