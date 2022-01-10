using ApiCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Application.Interface
{
    public interface IAppViaCep
    {
        Task<ViaCep> GetEnderecoAsync(string cep);
    }
}