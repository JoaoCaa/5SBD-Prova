using System.Threading.Tasks;

namespace Prova.DomainModel.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
