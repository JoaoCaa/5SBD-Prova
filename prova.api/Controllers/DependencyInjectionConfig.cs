using Prova.DomainModel.Interfaces.Repositories;
using Prova.DomainModel.Interfaces.Services;
using Prova.DomainModel.Interfaces.UoW;
using Prova.DomainService;
using Prova.Infra.Context;
using Prova.Infra.Repository;
using Prova.Infra.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Prova.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProvaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddScoped<IItemPedidoService, ItemPedidoService>();

            return services;
        }
    }
}
