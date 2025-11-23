using Newtonsoft.Json;
using System;

namespace Prova.DomainModel.Entity
{
    [JsonObject(IsReference = true)]
    public class ItemPedido : EntityBase
    {
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
