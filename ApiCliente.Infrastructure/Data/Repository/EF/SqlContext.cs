using ApiCliente.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Infrastructure.Data.Repository.EF
{
    public class SqlContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> contextOptions) : base(contextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Sprint5DB;Trusted_Connection=True;");
        }
              
    }

}