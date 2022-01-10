using ApiCliente.Application.DTO;
using ApiCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Application.Interface.Mapper
{
    public interface IMapperCidade
    {
        #region Interfaces Mappers
        Cidade MapperToEntity(CidadeDto cidadeDTO);

        IEnumerable<CidadeDto> MapperListCidades(IEnumerable<Cidade> cidades);

        CidadeDto MapperToDTO(Cidade cidade);

        #endregion
    }
}
