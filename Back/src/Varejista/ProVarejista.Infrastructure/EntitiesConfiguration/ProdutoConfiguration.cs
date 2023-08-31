using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProVarejista.Domain.Entities;

namespace ProVarejista.Infrastructure.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Preco).HasPrecision(10, 2);

            builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(p => p.DataCadastro).IsRequired();


            builder.HasOne(e => e.Categoria).WithMany(e => e.Produtos)
                .HasForeignKey(e => e.CategoriaId);
        }
    }
}
