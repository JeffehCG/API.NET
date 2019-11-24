using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ListaCompra.Models
{
    //public class TokenLogin
    //{
    //    public string Login { get; set; }
    //    public string Senha { get; set; }
    //}

    //public class TokenRetorno
    //{
    //    public string Token { get; set; }
    //    public DateTime DataTokenGerado { get; set; }
    //}

    public class Token
    {
        public string TokenJwt { get; set; }
        public DateTime DataTokenGerado { get; set; }
    }
}
