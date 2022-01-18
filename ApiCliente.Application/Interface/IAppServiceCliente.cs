using ApiCliente.Application.DTO;
using System.Collections.Generic;

namespace ApiCliente.Application.Interface
{
    public interface IAppServiceCliente
    {
        void Add(ClienteDto obj);
        void Update(int id, ClienteDto obj);
        void Remove(int id);
        IEnumerable<ClienteDto> GetAll();
        ClienteDto GetById(int id);
    }
}