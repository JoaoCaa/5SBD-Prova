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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MedGrupoContext context) : base(context) { }

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
