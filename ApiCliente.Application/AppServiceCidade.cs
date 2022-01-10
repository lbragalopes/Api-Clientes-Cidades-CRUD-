using ApiCliente.Application.DTO;
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
    public class AppServiceCidade : IAppServiceCidade
    {
        private readonly IServiceCidade _cidadeService;
        private readonly IMapperCidade _cidadeMapper;


        public AppServiceCidade(IServiceCidade cidadeService, IMapperCidade cidadeMapper)
        {
            _cidadeService = cidadeService;
            _cidadeMapper = cidadeMapper;
        }

        public void Add(CidadeDto cidadeDto)
        {
           // CidadeValidation cidadeValidation = new CidadeValidation();
           
           // if (cidadeValidation.ValidarEstado(cidadeDto.Estado))
              //  throw new System.ArgumentException("O campo estado é obrigatório ou tem mais de 40 caracteres", "Erro cliente");

            var objCidade = _cidadeMapper.MapperToEntity(cidadeDto);
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

        public void Remove(CidadeDto cidadeDto)
        {
            var objCidade = _cidadeMapper.MapperToEntity(cidadeDto);
            _cidadeService.Remove(objCidade);
        }

        public void Update(CidadeDto cidadeDto)
        {
           // CidadeValidation cidadeValidation = new CidadeValidation();

            //if (cidadeValidation.ValidarEstado(cidadeDto.Estado))
             //   throw new System.ArgumentException("O campo estado é obrigatório ou tem mais de 40 caracteres", "Erro cliente");

            var objCidade = _cidadeMapper.MapperToEntity(cidadeDto);
            _cidadeService.Update(objCidade);
        }
    }
}
