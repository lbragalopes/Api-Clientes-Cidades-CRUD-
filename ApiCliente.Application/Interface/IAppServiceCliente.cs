using ApiCliente.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Application.Interface
{
   public interface IAppServiceCliente
    {
        void Add(ClienteDto clienteDto);

        void Update(int id);

        void Remove(int id);

        IEnumerable<ClienteDto> GetAll();

        ClienteDto GetById(int id);
    }
}