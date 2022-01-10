using ApiCliente.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Infrastructure.Data.Repository.EF.Configuration
{
    class CidadeEntityConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Estado).IsRequired();
           
        }
    }
}