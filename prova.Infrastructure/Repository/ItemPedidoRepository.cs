using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedGrupo.DomainModel.Entity;
using MedGrupo.DomainModel.Interfaces.Repositories;
using MedGrupo.Infra.Context;

namespace MedGrupo.Infra.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(MedGrupoContext context) : base(context) { }

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
