using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedGrupo.DomainModel.Entity;

namespace MedGrupo.DomainModel.Interfaces.Services
{
    public interface IClienteService
    {
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(Guid id);
        Task<Cliente> Get(Guid id);
        Task<IEnumerable<Cliente>> GetAll();
    }
}
