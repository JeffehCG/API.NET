using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_ListaCompra.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Listacompras = new HashSet<Listacompras>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Login obrigatorio")]
        [MinLength(3, ErrorMessage = "Login deve conter no minico 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Login deve conter no máximo 50 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha obrigatorio")]
        [MinLength(6, ErrorMessage = "Senha deve conter no minico 6 caracteres")]
        [MaxLength(50, ErrorMessage = "Senha deve conter no máximo 50 caracteres")]
        public string Senha { get; set; }

        public ICollection<Listacompras> Listacompras { get; set;}
    }
}
