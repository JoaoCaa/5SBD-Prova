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
    public class ContatoService : IContatoService
    {
        private IContatoRepository _ContatoRepository;
        private IUnitOfWork _unitOfWork;


        public ContatoService(IContatoRepository ContatoRepository, IUnitOfWork unitOfWork)
        {
            _ContatoRepository = ContatoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Contato Contato)
        {

            Contato.Ativo = true;
            _ContatoRepository.Create(Contato);
            await _unitOfWork.CommitAsync();
        }
        public async Task Update(Contato Contato)
        {
            Contato.Ativo = true;
            _ContatoRepository.Update(Contato);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid id)
        {
            var contato = await Get(id);
            contato.Ativo = false;
            _ContatoRepository.Update(contato);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Contato>> GetAll()
        {
            var data = await _ContatoRepository.ReadAll();
            return data.Where(f => f.Ativo).AsEnumerable();
        }


        public async Task<Contato> Get(Guid id)
        {
            return await _ContatoRepository.Read(id);
        }



    }
}
