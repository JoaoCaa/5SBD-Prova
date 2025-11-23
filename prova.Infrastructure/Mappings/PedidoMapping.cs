using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.DomainModel.Entity;

namespace Prova.Infra.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataPedido)
                .IsRequired()
                .HasColumnType("Datetime");

            builder.Property(p => p.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Pedido");
        }
    }
}
