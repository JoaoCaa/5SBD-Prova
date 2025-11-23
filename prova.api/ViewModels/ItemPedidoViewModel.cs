using System.ComponentModel.DataAnnotations;

namespace Prova.Api.ViewModels
{
    public class ItemPedidoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PedidoId { get; set; }

        public Guid ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal Preco { get; set; }
    }
}
