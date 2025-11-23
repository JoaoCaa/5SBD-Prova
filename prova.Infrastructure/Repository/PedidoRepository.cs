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
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ProvaContext context) : base(context) { }

        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await Db.Pedidos
                .Include(p => p.Items)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pedido> GetPedido(Guid id)
        {
            return await Db.Pedidos
                .Include(p => p.Items)
                .AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
