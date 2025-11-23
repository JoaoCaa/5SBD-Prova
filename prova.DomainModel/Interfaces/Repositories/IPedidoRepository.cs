using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedGrupo.DomainModel.Entity;

namespace MedGrupo.DomainModel.Interfaces.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> GetPedidos();
        Task<Pedido> GetPedido(Guid id);
    }
}
