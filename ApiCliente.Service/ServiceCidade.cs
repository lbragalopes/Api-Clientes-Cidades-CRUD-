using ApiCliente.Core.Interface.Repository;
using ApiCliente.Core.Interface.Service;
using ApiCliente.Domain.Entity;
using System.Linq;

namespace ApiCliente.Service
{
    public class ServiceCidade : ServiceBase<Cidade>, IServiceCidade
    {
        private readonly IRepositoryCidade _repositoryCidade;

        public ServiceCidade(IRepositoryCidade repositoryCidade)
            : base(repositoryCidade)
        {
            _repositoryCidade = repositoryCidade;
        }

        // verificar se existe a cidade cadastrada
        public Cidade GetByLocalidade(string Localidade, string Uf)
        {
            var cidade = _repositoryCidade.GetAll().Where(cidade => cidade.Nome.Equals(Localidade) && cidade.Estado.Equals(Uf)).FirstOrDefault();
            return cidade;
        }
    }
}