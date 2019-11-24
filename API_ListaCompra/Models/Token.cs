using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ListaCompra.Models
{
    public class Token
    {
        public string TokenJwt { get; set; }
        public DateTime DataTokenGerado { get; set; }
        public string Usuario { get; set; }
        public int Identificador { get; set; }
    }
}
