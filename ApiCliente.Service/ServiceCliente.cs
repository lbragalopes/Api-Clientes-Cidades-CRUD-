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
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ServiceCliente(IRepositoryCliente repositoryCliente)
            : base(repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Cliente GetByCidadeId(int id)
        {

        return _repositoryCliente.GetAll().Where(c => c.CidadeId == id).FirstOrDefault();
            
                    
        }
    }
  }

