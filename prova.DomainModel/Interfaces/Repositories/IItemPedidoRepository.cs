using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedGrupo.DomainModel.Entity;

namespace MedGrupo.DomainModel.Interfaces.Repositories
{
    public interface IItemPedidoRepository : IRepository<ItemPedido>
    {
        Task<IEnumerable<ItemPedido>> GetItensPorPedido(Guid pedidoId);
    }
}
