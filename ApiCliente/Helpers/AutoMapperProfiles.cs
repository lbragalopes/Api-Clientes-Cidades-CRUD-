using ApiCliente.Application.DTO;
using ApiCliente.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
