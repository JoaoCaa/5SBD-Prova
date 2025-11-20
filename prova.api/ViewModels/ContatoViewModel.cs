using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedGrupo.Api.Utils;

namespace MedGrupo.Api.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no minimo {2} e no maximo {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [MinimumAge(18, ErrorMessage = "Esta data {0} é invalida, o contato deve ter pelo menos 18 anos.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [DocumentValidation(ErrorMessage = "O campo {0} é obrigatório")]
        public string Documento { get; set; }
        
    }
}
