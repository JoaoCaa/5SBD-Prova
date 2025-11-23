using MedGrupo.DomainModel.Entity;
using MedGrupo.DomainModel.Interfaces.Repositories;
using MedGrupo.DomainModel.Interfaces.Services;
using MedGrupo.DomainModel.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedGrupo.DomainService
{
    public class ItemPedidoService : IItemPedidoService
    {
        private IItemPedidoRepository _itemRepository;
        private IUnitOfWork _unitOfWork;

        public ItemPedidoService(IItemPedidoRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(ItemPedido item)
        {
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
    }
}
