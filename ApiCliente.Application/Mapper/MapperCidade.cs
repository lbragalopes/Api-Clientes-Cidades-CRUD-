using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface.Mapper;
using ApiCliente.Domain.Entity;
using System.Collections.Generic;

namespace ApiCliente.Application.Mapper
{
    public class MapperCidade : IMapperCidade
    {
        List<CidadeDto> cidadeDtos = new List<CidadeDto>();
        public IEnumerable<CidadeDto> MapperListCidades(IEnumerable<Cidade> cidades)
        {
            foreach (var cidade in cidades)
            {

                CidadeDto cidadeDto = new CidadeDto
                {
                    Nome = cidade.Nome,
                    Estado = cidade.Estado
                };

                cidadeDtos.Add(cidadeDto);
            }
            return cidadeDtos;
        }

        public CidadeDto MapperToDTO(Cidade cidade)
        {
            CidadeDto cidadeDto = new CidadeDto
            {
                Nome = cidade.Nome,
                Estado = cidade.Estado
            };

            return cidadeDto;
        }

        public Cidade MapperToEntity(CidadeDto cidadeDto)
        {
            Cidade cidade = new Cidade
            {
                Nome = cidadeDto.Nome,
                Estado = cidadeDto.Estado
            };
            return cidade;
        }
    }
}
