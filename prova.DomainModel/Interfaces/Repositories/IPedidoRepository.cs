using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.DomainModel.Entity;

namespace Prova.DomainModel.Interfaces.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> GetPedidos();
        Task<Pedido> GetPedido(Guid id);
    }
}
