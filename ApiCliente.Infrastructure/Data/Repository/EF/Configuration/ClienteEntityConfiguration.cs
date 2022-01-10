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
    public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            
            builder.Property(c => c.Id)
                 .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .HasColumnName("DataNascimento");


            builder.Property(c => c.Cep)
                .HasColumnName("Cep");


            builder.Property(c => c.Logradouro)
                .HasColumnName("Logradouro");


            builder.Property(c => c.Bairro)
                .HasColumnName("Bairro");
                

        

          


        }
    }
}