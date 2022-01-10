﻿using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface;
using ApiCliente.Application.Interface.Mapper;
using ApiCliente.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Application
{
    public class AppServiceCliente : IAppServiceCliente

    {
        private readonly IServiceCliente _clienteService;
        private readonly IMapperCliente _clienteMapper;
        private readonly IAppViaCep _viaCepService;
        private readonly IServiceCidade _cidadeService;

        public AppServiceCliente(IServiceCliente clienteService, IMapperCliente mapperCliente, IAppViaCep viaCepService, IServiceCidade cidadeService)
        {
            _clienteService = clienteService;
            _clienteMapper = mapperCliente;
            _viaCepService = viaCepService;
            _cidadeService = cidadeService;
        }

        public void Add(ClienteDto clienteDto)
        {
           // ClienteValidation clienteValidation = new ClienteValidation();

           // if (clienteValidation.ValidaNome(clienteDto.Nome))
               // throw new System.ArgumentException("Campo nome é obrigatório ou tem mais de 30 caracteres", "Erro cliente");

            var cliente = _clienteMapper.MapperToEntity(clienteDto);
            //popular o restante dos dados da classe cliente
            var endereco = _viaCepService.GetEnderecoAsync(clienteDto.Cep).Result;
            cliente.Bairro = endereco.Bairro;
            cliente.Logradouro = endereco.Logradouro;
            //consultar a cidade no banco atraves do campo localidade do endereço
            var cidade = _cidadeService.GetByLocalidade(endereco.Localidade, endereco.Uf);
            // Se encontrar a cidade setar a cidade encontrada ao cliente
            if (cidade != null)
            {
                cliente.Cidade = cidade;
            }
            else
            {
                //Senão criar uma nova cidade
                cliente.Cidade = new Domain.Entity.Cidade() { Nome = endereco.Localidade, Estado = endereco.Uf };
            }

            _clienteService.Add(cliente);
        }

        public IEnumerable<ClienteDto> GetAll()
        {
            var objCliente = _clienteService.GetAll();

            var clientes = _clienteMapper.MapperListClientes(objCliente);

            return clientes;
        }

        public ClienteDto GetById(int id)
        {
            var objCliente = _clienteService.GetById(id);
            ClienteDto cliente = _clienteMapper.MapperToDTO(objCliente);
            return cliente;
        }

        public void Remove(ClienteDto clienteDto)
        {
            var objCliente = _clienteMapper.MapperToEntity(clienteDto);
            _clienteService.Remove(objCliente);
        }

        public void Update(ClienteDto clienteDto)
        {
            //ClienteValidation clienteValidation = new ClienteValidation();

           // if (clienteValidation.ValidaNome(clienteDto.Nome))
              //  throw new System.ArgumentException("Campo nome é obrigatório ou tem mais de 30 caracteres", "Erro cliente");

            var objCliente = _clienteMapper.MapperToEntity(clienteDto);
            _clienteService.Update(objCliente);
        }
    }
}