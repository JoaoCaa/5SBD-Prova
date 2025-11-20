using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedGrupo.DomainModel.Entity;

namespace MedGrupo.Infra.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Documento)
               .IsRequired()
               .HasColumnType("varchar(14)");

            builder.Property(p => p.DataNascimento)
             .IsRequired()
             .HasColumnType("Datetime");

            builder.Property(p => p.Ativo)
            .IsRequired()
            .HasColumnType("bit");

            builder.ToTable("Contato");
        }
    }
}