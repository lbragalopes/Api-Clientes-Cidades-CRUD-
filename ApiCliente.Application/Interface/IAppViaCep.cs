using ApiCliente.Domain.Entity;
using System.Threading.Tasks;

namespace ApiCliente.Application.Interface
{
    public interface IAppViaCep
    {
        Task<ViaCep> GetViaCepJson(string cep);
    }
}