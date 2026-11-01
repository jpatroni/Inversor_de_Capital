 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio  /// lo que hace dominio : Dominio representa los datos 
{
    public class Banco
    {
        public string Nombre { get; set; }
        public List<decimal> TasasHistoricas { get; set; }

        // Constructor
        public Banco()
        {
            TasasHistoricas = new List<decimal>();

        }
    }
}
