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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ProvaContext context) : base(context) { }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await Db.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetCliente(Guid id)
        {
            return await Db.Clientes.AsNoTracking().Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
