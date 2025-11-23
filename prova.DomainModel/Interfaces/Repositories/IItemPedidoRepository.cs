using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.DomainModel.Entity;

namespace Prova.DomainModel.Interfaces.Repositories
{
    public interface IItemPedidoRepository : IRepository<ItemPedido>
    {
        Task<IEnumerable<ItemPedido>> GetItensPorPedido(Guid pedidoId);
    }
}
