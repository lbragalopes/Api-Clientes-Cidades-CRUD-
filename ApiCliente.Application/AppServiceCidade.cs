using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface;
using ApiCliente.Application.Interface.Mapper;
using ApiCliente.Core.Interface.Service;
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

        public void Update(CidadeDto obj)
        {
            var objCidade = _cidadeMapper.MapperToEntity(obj);
            _cidadeService.Update(objCidade);
        }
    }
}
