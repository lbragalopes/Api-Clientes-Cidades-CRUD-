using ApiCliente.Application.DTO;
using System.Collections.Generic;

namespace ApiCliente.Application.Interface
{
    public interface IAppServiceCidade
    {
        void Add(CidadeDto obj);
        void Update(int id, CidadeDto obj);
        void Remove(int id);
        IEnumerable<CidadeDto> GetAll();
        CidadeDto GetById(int id);
    }
}