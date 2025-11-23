using Prova.DomainModel.Entity;
using Prova.DomainModel.Interfaces.Repositories;
using Prova.DomainModel.Interfaces.Services;
using Prova.DomainModel.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.DomainService
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        private IUnitOfWork _unitOfWork;

        public ClienteService(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Cliente cliente)
        {
            cliente.Ativo = true;
            _clienteRepository.Create(cliente);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Cliente cliente)
        {
            cliente.Ativo = true;
            _clienteRepository.Update(cliente);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid id)
        {
            var cliente = await Get(id);
            cliente.Ativo = false;
            _clienteRepository.Update(cliente);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            var data = await _clienteRepository.ReadAll();
            return data.Where(f => f.Ativo).AsEnumerable();
        }

        public async Task<Cliente> Get(Guid id)
        {
            return await _clienteRepository.Read(id);
        }
    }
}
