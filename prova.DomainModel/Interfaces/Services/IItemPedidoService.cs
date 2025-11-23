using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedGrupo.DomainModel.Entity;

namespace MedGrupo.DomainModel.Interfaces.Services
{
    public interface IItemPedidoService
    {
        Task Add(ItemPedido item);
        Task Update(ItemPedido item);
        Task Delete(Guid id);
        Task<ItemPedido> Get(Guid id);
        Task<IEnumerable<ItemPedido>> GetAll();
    }
}
