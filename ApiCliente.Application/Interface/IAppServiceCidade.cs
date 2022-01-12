using ApiCliente.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Application.Interface
{
   public interface IAppServiceCidade
    {
        void Add(CidadeDto obj);

        void Update(CidadeDto obj);

        void Remove(int id);

        IEnumerable<CidadeDto> GetAll();

        CidadeDto GetById(int id);
    }
}