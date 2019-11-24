using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_ListaCompra.Models
{
    public partial class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatorio")]
        [MinLength(3, ErrorMessage = "Nome deve conter no minico 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve conter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Indicativo obrigatorio")]
        public bool? Comprado { get; set; }

        [Required(ErrorMessage = "Id Lista obrigatorio")]

        public int? IdLista { get; set; }

        public Listacompras IdListaNavigation { get; set; }
    }
}
