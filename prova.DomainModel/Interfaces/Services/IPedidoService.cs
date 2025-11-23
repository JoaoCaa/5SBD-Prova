using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.DomainModel.Entity;

namespace Prova.DomainModel.Interfaces.Services
{
    public interface IPedidoService
    {
        Task Add(Pedido pedido);
        Task Update(Pedido pedido);
        Task Delete(Guid id);
        Task<Pedido> Get(Guid id);
        Task<IEnumerable<Pedido>> GetAll();
    }
}
