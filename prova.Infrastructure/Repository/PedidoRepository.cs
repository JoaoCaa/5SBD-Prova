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
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(MedGrupoContext context) : base(context) { }

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
