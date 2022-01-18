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
            if (objCidade == null)
            {
                throw new System.ArgumentException($"Motivo: A cidade não está cadastrada.");

            }
            var objCidadeId = _clienteService.GetByCidadeId(objCidade.Id);
            if (objCidadeId == null)
                _cidadeService.Remove(objCidade);

        }

        public void Update(int id, CidadeDto obj)
        {

            var objCidade = _cidadeService.GetById(id);

            objCidade.Nome = obj.Nome;
            objCidade.Estado = obj.Estado;

            _cidadeService.Update(objCidade);
        }
    }
}
