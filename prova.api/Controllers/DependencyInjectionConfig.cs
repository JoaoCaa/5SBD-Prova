using Prova.DomainModel.Interfaces.Repositories;
using Prova.DomainModel.Interfaces.Services;
using Prova.DomainModel.Interfaces.UoW;
using Prova.DomainService;
using Prova.Infra.Context;
using Prova.Infra.Repository;
using Prova.Infra.UoW;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;



namespace Prova.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProvaContext>();

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

