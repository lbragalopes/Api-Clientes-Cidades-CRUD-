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

            
            var cidadeID = _repositoryCliente.GetAll().Where(c => c.CidadeId.Equals(id)).FirstOrDefault();
            if(cidadeID != null)
            {
                throw new System.ArgumentException($"Motivo: Clientes estão utilizando a cidade {cidadeID.Nome} no cadastro.");
            }
            return null;
                    
        }
    }
  }

