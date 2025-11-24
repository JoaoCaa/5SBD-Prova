using Prova.DomainModel.Entity;
using Prova.DomainModel.Interfaces.Repositories;
using Prova.DomainModel.Interfaces.Services;
using Prova.DomainModel.Interfaces.UoW;

namespace Prova.DomainService
{
    public class ItemPedidoService : IItemPedidoService
    {
        private IItemPedidoRepository _itemRepository;
        private IProdutoRepository _produtoRepository;
        private IUnitOfWork _unitOfWork;

        public ItemPedidoService(IItemPedidoRepository itemRepository, IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(ItemPedido item)
        {
            var produto = await _produtoRepository.Read(item.ProdutoId);
            if (produto == null)
                throw new ArgumentException("Produto não encontrado");

            if (produto.Estoque < item.Quantidade)
                throw new InvalidOperationException("Estoque insuficiente");

            produto.Estoque -= item.Quantidade;
            _produtoRepository.Update(produto);

            _itemRepository.Create(item);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(ItemPedido item)
        {
            _itemRepository.Update(item);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid id)
        {
            _itemRepository.Delete(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ItemPedido>> GetAll()
        {
            return await _itemRepository.ReadAll();
        }

        public async Task<ItemPedido> Get(Guid id)
        {
            return await _itemRepository.Read(id);
        }

        public async Task<IEnumerable<ItemPedido>> GetByPedido(Guid pedidoId)
        {
            return await _itemRepository.GetItensPorPedido(pedidoId);
        }
    }
}
