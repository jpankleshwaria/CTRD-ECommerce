using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using CTRD.ECommerce.Application.DTO;
using CTRD.ECommerce.Domain.Entities;

namespace Administration.IOC.AutoMappers
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<Csp, CspListDTO>().ReverseMap();
        }
    }
}
