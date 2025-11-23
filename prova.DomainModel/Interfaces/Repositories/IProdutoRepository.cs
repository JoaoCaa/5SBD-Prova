using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.DomainModel.Entity;

namespace Prova.DomainModel.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutos();
        Task<Produto> GetProduto(Guid id);
    }
}
