using ApiCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Core.Interface.Service
{
    public interface IServiceCidade : IServiceBase<Cidade>
    {
        Cidade GetByLocalidade(string localidade, string uf);
    }
}