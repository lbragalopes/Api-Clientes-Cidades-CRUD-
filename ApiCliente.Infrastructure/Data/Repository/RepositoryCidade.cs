﻿using ApiCliente.Core.Interface.Repository;
using ApiCliente.Domain.Entity;
using ApiCliente.Infrastructure.Data.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Infrastructure.Data.Repository
{
    public class CidadeRepository : RepositoryBase<Cidade>, IRepositoryCidade
    {
        private readonly SqlContext sqlContext;

        public CidadeRepository(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}

