using ApiCliente.Domain.Entity;

namespace ApiCliente.Core.Interface.Service
{
    public interface IServiceCliente : IServiceBase<Cliente>
    {
        Cliente GetByCidadeId(int Id);
    }
}