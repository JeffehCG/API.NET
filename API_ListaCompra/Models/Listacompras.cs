using System;
using System.Collections.Generic;

namespace API_ListaCompra.Models
{
    public partial class Listacompras
    {
        public Listacompras()
        {
            Produto = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public DateTime? DataLista { get; set; }
        public int? IdUsuario { get; set; }
        public string Descricao { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Produto> Produto { get; set; }
    }
}
