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
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;
        private IUnitOfWork _unitOfWork;

        public PedidoService(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Pedido pedido)
        {
            // calcula total se houver items
            if (pedido.Items != null)
                pedido.Total = pedido.Items.Sum(i => i.Preco * i.Quantidade);

            _pedidoRepository.Create(pedido);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Pedido pedido)
        {
            if (pedido.Items != null)
                pedido.Total = pedido.Items.Sum(i => i.Preco * i.Quantidade);

            _pedidoRepository.Update(pedido);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid id)
        {
            _pedidoRepository.Delete(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await _pedidoRepository.ReadAll();
        }

        public async Task<Pedido> Get(Guid id)
        {
            return await _pedidoRepository.Read(id);
        }
    }
}
