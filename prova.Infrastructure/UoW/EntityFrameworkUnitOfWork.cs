using System.Threading.Tasks;
using Prova.DomainModel.Interfaces.UoW;
using Prova.Infra.Context;

namespace Prova.Infra.UoW
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly ProvaContext _context;

        public EntityFrameworkUnitOfWork(ProvaContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

      
    }
}
