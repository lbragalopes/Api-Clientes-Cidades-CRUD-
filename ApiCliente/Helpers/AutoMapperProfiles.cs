using ApiCliente.Application.DTO;
using ApiCliente.Domain.Entity;
using AutoMapper;

namespace ApiCliente.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cidade, CidadeDto>().ReverseMap();
            CreateMap<ViaCep, ViaCepDto>().ReverseMap();

        }
    }
}
