using System.Threading.Tasks;
using MedGrupo.DomainModel.Interfaces.UoW;
using MedGrupo.Infra.Context;

namespace MedGrupo.Infra.UoW
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly MedGrupoContext _context;

        public EntityFrameworkUnitOfWork(MedGrupoContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

      
    }
}
