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
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(MedGrupoContext context) : base(context) { }

        public async Task<IEnumerable<Contato>> GetContatos()
        {
            return await Db.Contatos.AsNoTracking()

                .ToListAsync();
        }

        public async Task<Contato> GetContato(Guid id)
        {
            return await Db.Contatos.AsNoTracking()

                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

    }
}
