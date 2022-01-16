using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface;
using ApiCliente.Application.Interface.Mapper;
using ApiCliente.Core.Interface.Service;
using ApiCliente.Domain.Entity;
using ApiCliente.Domain.Validations;
using System.Collections.Generic;

namespace ApiCliente.Application
{
    public class AppServiceCidade : IAppServiceCidade
    {
        private readonly IServiceCidade _cidadeService;
        private readonly IMapperCidade _cidadeMapper;
        private readonly IServiceCliente _clienteService;
        private readonly IMapperCliente _clienteMapper;
        public AppServiceCidade(IServiceCidade cidadeService, IMapperCidade cidadeMapper, IMapperCliente clienteMapper, IServiceCliente clienteService)
        {
            _cidadeService = cidadeService;
            _cidadeMapper = cidadeMapper;
            _clienteService = clienteService;
            _clienteMapper = clienteMapper;
        }

        public void Add(CidadeDto obj)
        {
            //validação Nome da cidade e Estado
            CidadeValidation cidadeValidation = new CidadeValidation();
            if (cidadeValidation.ValidarNomeCidade(obj.Nome))
                throw new System.ArgumentException("O campo Nome está vazio ou tem mais de 20 caracteres", "Erro cliente");
            if (cidadeValidation.ValidarEstado(obj.Estado))
                throw new System.ArgumentException("O campo Estado está vazio ou tem mais de 2 caracteres (Ex: SP)", "Erro cliente");

            var objCidade = _cidadeMapper.MapperToEntity(obj);
            _cidadeService.Add(objCidade);
        }

        public IEnumerable<CidadeDto> GetAll()
        {
            var objCidade = _cidadeService.GetAll();
            return _cidadeMapper.MapperListCidades(objCidade);
        }
        public CidadeDto GetById(int id)
        {
            var objCidade = _cidadeService.GetById(id);
            return _cidadeMapper.MapperToDTO(objCidade);
        }

        public void Remove(int id, CidadeDto obj)
        {
            var objCidade = _cidadeService.GetById(id);
            var objCidadeId = _clienteService.GetByCidadeId(objCidade.Id);
            if (objCidadeId == null)
             _cidadeService.Remove(objCidade);
        }

        public void Update(int id, CidadeDto obj)
        {
            //validação nome da cidade e estado
            CidadeValidation cidadeValidation = new CidadeValidation();
            if (cidadeValidation.ValidarNomeCidade(obj.Nome))
                throw new System.ArgumentException("Campo logradouro é obrigatório ou tem mais de 20 caracteres", "Erro cidade");
            if (cidadeValidation.ValidarEstado(obj.Estado))
                throw new System.ArgumentException("O campo estado é obrigatório ou tem mais de 2 caracteres", "Erro cidade");

            var objCidade = _cidadeService.GetById(id);

            objCidade.Nome = obj.Nome;
            objCidade.Estado = obj.Estado;

            _cidadeService.Update(objCidade);
        }
    }
}
