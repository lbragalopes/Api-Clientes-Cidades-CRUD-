using ApiCliente.Core.Interface.Repository;
using ApiCliente.Core.Interface.Service;
using ApiCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Cidade GetByLocalidade(string localidade, string uf)
        {
            var cidade = _repositoryCidade.GetAll().Where(cidade => cidade.Nome.Equals(localidade) && cidade.Estado.Equals(uf)).FirstOrDefault();
            return cidade;
        }
    }
}