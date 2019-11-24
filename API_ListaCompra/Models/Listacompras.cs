using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_ListaCompra.Models
{
    public partial class Listacompras
    {
        public Listacompras()
        {
            Produto = new HashSet<Produto>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Data obrigatoria")]
        public DateTime? DataLista { get; set; }

        [Required(ErrorMessage = "ID Usuario obrigatorio")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Descrição obrigatoria")]
        [MinLength(3, ErrorMessage = "Descrição deve conter no minico 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Descrição deve conter no máximo 50 caracteres")]
        public string Descricao { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Produto> Produto { get; set; }
    }
}
