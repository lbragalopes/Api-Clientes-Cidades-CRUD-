using ApiCliente.Domain.Entity;

namespace ApiCliente.Core.Interface.Service
{
    public interface IServiceCidade : IServiceBase<Cidade>
    {
        Cidade GetByLocalidade(string Localidade, string Uf);
    }
}