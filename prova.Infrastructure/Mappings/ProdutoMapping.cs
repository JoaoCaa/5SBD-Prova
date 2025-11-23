using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedGrupo.DomainModel.Entity;

namespace MedGrupo.Infra.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(255)");

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Estoque)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Produto");
        }
    }
}
