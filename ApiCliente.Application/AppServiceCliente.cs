using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface;
using ApiCliente.Application.Interface.Mapper;
using ApiCliente.Core.Interface.Service;
using ApiCliente.Domain.Entity;
using System.Collections.Generic;

namespace ApiCliente.Application
{
    public class AppServiceCliente : IAppServiceCliente
    {
        private readonly IServiceCliente _clienteService;
        private readonly IMapperCliente _clienteMapper;
        private readonly IMapperCidade _cidadeMapper;
        private readonly IAppViaCep _viaCepService;
        private readonly IServiceCidade _cidadeService;

        public AppServiceCliente(IServiceCliente clienteService, IMapperCliente mapperCliente, IMapperCidade mapperCidade, IAppViaCep viaCepService, IServiceCidade cidadeService)
        {
            _clienteService = clienteService;
            _clienteMapper = mapperCliente;
            _cidadeMapper = mapperCidade;
            _viaCepService = viaCepService;
            _cidadeService = cidadeService;
        }
        public void Add(ClienteDto obj)
        {
            // validação Nome cliente
           var cliente = _clienteMapper.MapperToEntity(obj);

            //popular o restante dos dados da classe cliente
            var endereco = _viaCepService.GetViaCepJson(obj.Cep).Result;
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
                cliente.Cidade = new Cidade() { Nome = endereco.Localidade, Estado = endereco.Uf };
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

        public void Remove(int id)
        {

            var objCliente = _clienteService.GetById(id);
            _clienteService.Remove(objCliente);
        }

        public void Update(int id, ClienteDto obj)
        {

            var objCliente = _clienteService.GetById(id);

            objCliente.Nome = obj.Nome;
            objCliente.DataNascimento = obj.DataNascimento;
            objCliente.Cep = obj.Cep;
            var endereco = _viaCepService.GetViaCepJson(obj.Cep).Result;
            objCliente.Bairro = endereco.Bairro;
            objCliente.Logradouro = endereco.Logradouro;
           
            //consultar a cidade no banco atraves do campo localidade do endereço
            var cidade = _cidadeService.GetByLocalidade(endereco.Localidade, endereco.Uf);

            // Se encontrar a cidade setar a cidade encontrada ao cliente
            if (cidade != null)
            {
                objCliente.Cidade = cidade;

            }
            else
            {
                objCliente.Cidade = new Cidade() { Nome = endereco.Localidade, Estado = endereco.Uf };

            }
            _clienteService.Update(objCliente);
        }
    }
}