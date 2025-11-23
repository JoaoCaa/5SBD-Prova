using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using MedGrupo.DomainModel.Interfaces.Repositories;
using MedGrupo.DomainModel.Interfaces.Services;
using MedGrupo.DomainModel.Interfaces.UoW;
using MedGrupo.DomainService;
using MedGrupo.Infra.Context;
using MedGrupo.Infra.UoW;
using MedGrupo.Infra.Repository;



namespace MedGrupo.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MedGrupoContext>();

            // Unit Of Work
            services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork>();


            //Swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

         
            // (Contato flow removed)
            // Cliente
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            // Produto
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            // Pedido / ItemPedido
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddScoped<IItemPedidoService, ItemPedidoService>();
            
            return services;
        }
    }
}

