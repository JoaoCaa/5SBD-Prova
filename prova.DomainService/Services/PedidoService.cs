using Prova.DomainModel.Entity;
using Prova.DomainModel.Interfaces.Repositories;
using Prova.DomainModel.Interfaces.Services;
using Prova.DomainModel.Interfaces.UoW;

namespace Prova.DomainService
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;
        private IItemPedidoRepository _itemPedidoRepository;

        private IUnitOfWork _unitOfWork;

        public PedidoService(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork, IItemPedidoRepository itemPedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
            _itemPedidoRepository = itemPedidoRepository;
        }

        public async Task Add(Pedido pedido)
        {
           _pedidoRepository.Create(pedido);

            if(pedido.Items.Count > 0)
            {
                foreach (var item in pedido.Items)
                {
                     _itemPedidoRepository.Create(item);
                }
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Pedido pedido)
        {
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
            return await _pedidoRepository.GetPedidos();
        }

        public async Task<Pedido> Get(Guid id)
        {
            return await _pedidoRepository.GetPedido(id);
        }
    }
}
