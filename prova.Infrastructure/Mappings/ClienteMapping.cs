using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.DomainModel.Entity;

namespace Prova.Infra.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Cliente");
        }
    }
}
