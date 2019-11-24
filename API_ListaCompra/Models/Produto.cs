using System;
using System.Collections.Generic;

namespace API_ListaCompra.Models
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool? Comprado { get; set; }
        public int? IdLista { get; set; }

        public Listacompras IdListaNavigation { get; set; }
    }
}
