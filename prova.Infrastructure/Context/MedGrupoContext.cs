using MedGrupo.DomainModel.Entity;
using MedGrupo.Infra.Mappings;
using Microsoft.EntityFrameworkCore;


namespace MedGrupo.Infra.Context
{
    public class MedGrupoContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public MedGrupoContext(DbContextOptions<MedGrupoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
