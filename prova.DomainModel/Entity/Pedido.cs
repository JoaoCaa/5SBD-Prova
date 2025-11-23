using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Prova.DomainModel.Entity
{
    [JsonObject(IsReference = true)]
    public class Pedido : EntityBase
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal Total { get; set; }
        public ICollection<ItemPedido> Items { get; set; }
    }
}
