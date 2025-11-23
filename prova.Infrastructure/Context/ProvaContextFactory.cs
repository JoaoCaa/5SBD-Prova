using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Prova.Infra.Context
{ 
    public class ProvaContextFactory : IDesignTimeDbContextFactory<ProvaContext>
    {
        public ProvaContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? Environment.GetEnvironmentVariable("PROVA_CONNECTION")
                ?? "Server=localhost\\SQLEXPRESS;Database=ProvaDb;Trusted_Connection=True;TrustServerCertificate=True";

            var optionsBuilder = new DbContextOptionsBuilder<ProvaContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ProvaContext(optionsBuilder.Options);
        }
    }
}
