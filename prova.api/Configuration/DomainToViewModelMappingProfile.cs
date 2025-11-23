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
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<ItemPedido, ItemPedidoViewModel>().ReverseMap();
        }
    }
}
