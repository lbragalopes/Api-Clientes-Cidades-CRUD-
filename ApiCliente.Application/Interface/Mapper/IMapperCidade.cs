using ApiCliente.Application.DTO;
using ApiCliente.Domain.Entity;
using System.Collections.Generic;

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
