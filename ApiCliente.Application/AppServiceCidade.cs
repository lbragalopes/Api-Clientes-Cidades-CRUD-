using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface;
using ApiCliente.Application.Interface.Mapper;
using ApiCliente.Core.Interface.Service;
using ApiCliente.Domain.Validations;
using System.Collections.Generic;

namespace ApiCliente.Application
{
    public class AppServiceCidade : IAppServiceCidade
    {
        private readonly IServiceCidade _cidadeService;
        private readonly IMapperCidade _cidadeMapper;


        public AppServiceCidade(IServiceCidade cidadeService, IMapperCidade cidadeMapper)
        {
            _cidadeService = cidadeService;
            _cidadeMapper = cidadeMapper;
        }

        public void Add(CidadeDto obj)
        {
            CidadeValidation cidadeValidation = new CidadeValidation();

            if (cidadeValidation.ValidarNomeCidade(obj.Nome))
                throw new System.ArgumentException("Campo logradouro é obrigatório ou tem mais de 20 caracteres", "Erro cliente");
            if (cidadeValidation.ValidarEstado(obj.Estado))
                throw new System.ArgumentException("O campo estado é obrigatório ou tem mais de 2 caracteres", "Erro cliente");


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

        public void Remove(int id)
        {
            var objCidade = _cidadeService.GetById(id);
            _cidadeService.Remove(objCidade);
        }

        public void Update(int id, CidadeDto obj)
        {
            CidadeValidation cidadeValidation = new CidadeValidation();

            if (cidadeValidation.ValidarNomeCidade(obj.Nome))
                throw new System.ArgumentException("Campo logradouro é obrigatório ou tem mais de 20 caracteres", "Erro cliente");
            if (cidadeValidation.ValidarEstado(obj.Estado))
                throw new System.ArgumentException("O campo estado é obrigatório ou tem mais de 2 caracteres", "Erro cliente");


            var objCidade = _cidadeService.GetById(id);

            objCidade.Nome = obj.Nome;
            objCidade.Estado = obj.Estado;

            _cidadeService.Update(objCidade);
        }
    }
}
