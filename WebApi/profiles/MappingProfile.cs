using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;

namespace WebApi.profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>()
                .ForMember(x => x.FullAddress,
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<AddCompanyDTO, Company>();
            CreateMap<AddEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();

        }
    }
}
