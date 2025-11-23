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
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;
        private IUnitOfWork _unitOfWork;

        public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Produto produto)
        {
            produto.Ativo = true;
            _produtoRepository.Create(produto);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Produto produto)
        {
            produto.Ativo = true;
            _produtoRepository.Update(produto);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid id)
        {
            var produto = await Get(id);
            produto.Ativo = false;
            _produtoRepository.Update(produto);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            var data = await _produtoRepository.ReadAll();
            return data.Where(f => f.Ativo).AsEnumerable();
        }

        public async Task<Produto> Get(Guid id)
        {
            return await _produtoRepository.Read(id);
        }
    }
}
