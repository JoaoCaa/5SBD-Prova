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

         
            // Contato
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IContatoService, ContatoService>();
            
            return services;
        }
    }
}

