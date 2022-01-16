using ApiCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Core.Interface.Service
{
    public interface IServiceCliente : IServiceBase<Cliente>
    {
        Cliente GetByCidadeId(int Id);
    }
}