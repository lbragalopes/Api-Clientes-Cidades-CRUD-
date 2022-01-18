using ApiCliente.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCliente.Infrastructure.Data.Repository.EF.Configuration
{
    class CidadeEntityConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidades");

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                     .HasColumnType("int");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(c => c.Estado)
                 .HasColumnName("Estado")
                .IsRequired();

        }
    }
}