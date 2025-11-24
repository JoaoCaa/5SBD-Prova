using AutoMapper;
using  Prova.Api.ViewModels;
using Prova.DomainModel.Entity;

namespace Prova.Api.Configuration
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<ItemPedido, ItemPedidoViewModel>().ReverseMap();
        }
    }
}
