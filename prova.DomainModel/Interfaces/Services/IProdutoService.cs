using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.DomainModel.Entity;

namespace Prova.DomainModel.Interfaces.Services
{
    public interface IProdutoService
    {
        Task Add(Produto produto);
        Task Update(Produto produto);
        Task Delete(Guid id);
        Task<Produto> Get(Guid id);
        Task<IEnumerable<Produto>> GetAll();
    }
}
