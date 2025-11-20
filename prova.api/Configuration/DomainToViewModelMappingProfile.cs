using AutoMapper;
using  MedGrupo.Api.ViewModels;
using MedGrupo.DomainModel.Entity;

namespace MedGrupo.Api.Configuration
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}
