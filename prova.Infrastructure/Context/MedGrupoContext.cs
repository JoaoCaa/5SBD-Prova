using MedGrupo.DomainModel.Entity;
using MedGrupo.Infra.Mappings;
using Microsoft.EntityFrameworkCore;


namespace MedGrupo.Infra.Context
{
    public class MedGrupoContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }

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
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new ItemPedidoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
