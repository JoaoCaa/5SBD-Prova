using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.DomainModel.Entity;

namespace Prova.DomainModel.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(Guid id);
    }
}
