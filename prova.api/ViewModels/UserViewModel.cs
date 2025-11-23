using Prova.Api.Utils;
using System.ComponentModel.DataAnnotations;

namespace Prova.Api.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} deve ser um email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [PasswordValidation(ErrorMessage = "O campo {0} deve conter pelo menos uma letra maisucula, uma letra minuscula, um caracter especial e um numro.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no minimo {2} e no maximo {1} caracteres.", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas devem ser iguais.")]
        public string ConfirmarSenha { get; set; }
    }

    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} is in invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no minimo {2} e no maximo {1} caracteres.", MinimumLength = 6)]
        public string Senha { get; set; }
    }
}