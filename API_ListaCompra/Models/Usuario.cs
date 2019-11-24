using System;
using System.Collections.Generic;

namespace API_ListaCompra.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Listacompras = new HashSet<Listacompras>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public ICollection<Listacompras> Listacompras { get; set; }
    }
}
