using ApiCliente.Core.Interface.Repository;
using ApiCliente.Domain.Entity;
using ApiCliente.Infrastructure.Data.Repository.EF;

namespace ApiCliente.Infrastructure.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private readonly SqlContext sqlContext;

        public ClienteRepository(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}

