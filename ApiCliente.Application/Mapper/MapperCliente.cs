using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface.Mapper;
using ApiCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Application.Mapper
{
    public class MapperCliente : IMapperCliente
    {
        List<ClienteDto> clienteDTOs = new List<ClienteDto>();
        public IEnumerable<ClienteDto> MapperListClientes(IEnumerable<Cliente> clientes)
        {
            foreach (var item in clientes)
            {
                ClienteDto clienteDTO = new ClienteDto
                {
                    Nome = item.Nome,
                    DataNascimento = item.DataNascimento,
                    Cep = item.Cep,
                };
                clienteDTOs.Add(clienteDTO);
            }

            return clienteDTOs;
        }

        public ClienteDto MapperToDTO(Cliente Cliente)
        {

            ClienteDto clienteDTO = new ClienteDto
            {
                Nome = Cliente.Nome,
                DataNascimento = Cliente.DataNascimento,
                Cep = Cliente.Cep,
            };

            return clienteDTO;
        }

        public Cliente MapperToEntity(ClienteDto clienteDto)
        {
            {

                Cliente cliente = new Cliente
                {
                    Nome = clienteDto.Nome,
                    DataNascimento = clienteDto.DataNascimento,
                    Cep = clienteDto.Cep,
                };

                return cliente;
            }
        }
    }
}
