using ApiCliente.Application.DTO;
using ApiCliente.Domain.Entity;
using System.Collections.Generic;

namespace ApiCliente.Application.Interface.Mapper
{
    public interface IMapperCliente
    {
        #region Mappers

        Cliente MapperToEntity(ClienteDto clienteDTO);

        IEnumerable<ClienteDto> MapperListClientes(IEnumerable<Cliente> clientes);

        ClienteDto MapperToDTO(Cliente Cliente);

        #endregion

    }
}