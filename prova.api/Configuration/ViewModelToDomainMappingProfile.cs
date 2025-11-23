using AutoMapper;
using MedGrupo.Api.ViewModels;
using MedGrupo.DomainModel.Entity;

namespace MedGrupo.Api.Configuration
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            var dtoConfig = AutoMapperConfig.RegisterViewModelDomainMappings();
            var mapper = dtoConfig.CreateMapper();

            // (Contato flow removed)
            // Cliente
            CreateMap<ClienteViewModel, Cliente>();

            // Produto
            CreateMap<ProdutoViewModel, Produto>();

            // Pedido
            CreateMap<PedidoViewModel, Pedido>();
            CreateMap<ItemPedidoViewModel, ItemPedido>();
            //   .ConstructUsing(a => new AddContatoCommand(mapper.Map<ContatoViewModel, Contato>(a)));

            //CreateMap<ContatoViewModel, UpdateContatoCommand>()
            //  .ConstructUsing(a => new UpdateContatoCommand(mapper.Map<ContatoViewModel, Contato>(a)));

            //CreateMap<ContatoViewModel, DeleteContatoCommand>()
            //  .ConstructUsing(a => new DeleteContatoCommand(mapper.Map<ContatoViewModel, Contato>(a)));

          
        }
    }
}
