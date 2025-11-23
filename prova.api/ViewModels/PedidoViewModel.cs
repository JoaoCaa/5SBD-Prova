using System.ComponentModel.DataAnnotations;

namespace Prova.Api.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }

        public DateTime DataPedido { get; set; }

        public decimal Total { get; set; }

        public ICollection<ItemPedidoViewModel> Items { get; set; }
    }
}
