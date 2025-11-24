using AutoMapper;
using Prova.Api.ViewModels;
using Prova.DomainModel.Entity;

namespace Prova.Api.Configuration
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            var dtoConfig = AutoMapperConfig.RegisterViewModelDomainMappings();
            var mapper = dtoConfig.CreateMapper();

            // Cliente
            CreateMap<ClienteViewModel, Cliente>();

            // Produto
            CreateMap<ProdutoViewModel, Produto>();

            // Pedido
            CreateMap<PedidoViewModel, Pedido>();
            CreateMap<ItemPedidoViewModel, ItemPedido>();         
        }
    }
}
