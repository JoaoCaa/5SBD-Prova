using System.ComponentModel.DataAnnotations;

namespace Prova.Api.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no minimo {2} e no maximo {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        public string Documento { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}
