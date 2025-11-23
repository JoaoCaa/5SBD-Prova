using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova.DomainModel.Entity;
using Prova.DomainModel.Interfaces.Repositories;
using Prova.Infra.Context;

namespace Prova.Infra.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ProvaContext context) : base(context) { }

        public async Task<IEnumerable<ItemPedido>> GetItensPorPedido(Guid pedidoId)
        {
            return await Db.ItemPedidos
                .Include(i => i.Produto)
                .AsNoTracking()
                .Where(i => i.PedidoId == pedidoId)
                .ToListAsync();
        }
    }
}
