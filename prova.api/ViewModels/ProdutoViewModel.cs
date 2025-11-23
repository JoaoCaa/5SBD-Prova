using System;
using System.ComponentModel.DataAnnotations;

namespace MedGrupo.Api.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public int Estoque { get; set; }
    }
}
