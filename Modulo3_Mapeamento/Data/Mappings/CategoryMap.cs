using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Tabela. Isso pq o EF pluraliza o nome da tabela por padrão
            builder.ToTable("Category");

            // Chave primária
            builder.HasKey(x => x.Id);

            // Identity --> somente é necessário se for criar a tabela via código
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // IDENTITY(1, 1) se tivesse criando via Banco
        }
    }
}