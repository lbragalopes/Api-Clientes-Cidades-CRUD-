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
        void Add(CidadeDto cidadeDto);

        void Update(CidadeDto cidadeDto);

        void Remove(CidadeDto cidadeDto);

        IEnumerable<CidadeDto> GetAll();

        CidadeDto GetById(int id);
    }
}