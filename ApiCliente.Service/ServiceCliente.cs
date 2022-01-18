using ApiCliente.Core.Interface.Repository;
using ApiCliente.Core.Interface.Service;
using ApiCliente.Domain.Entity;
using System.Linq;

namespace ApiCliente.Service
{
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ServiceCliente(IRepositoryCliente repositoryCliente)
            : base(repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        //verificar a quantidade de cliente utilizando o Id da Cidade.
        public Cliente GetByCidadeId(int id)
        {
            var cidadeID = _repositoryCliente.GetAll().Where(c => c.CidadeId.Equals(id)).FirstOrDefault();
            if (cidadeID != null)
            {
                throw new System.ArgumentException($" Motivo: Clientes estão utilizando a cidade no cadastro.");
            }
            return null;

        }
    }
}

