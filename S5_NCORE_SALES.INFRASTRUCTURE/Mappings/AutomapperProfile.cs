using AutoMapper;
using S5_NCORE_SALES.CORE.DTOs;
using S5_NCORE_SALES.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.INFRASTRUCTURE.Mappings
{
    public class AutomapperProfile: Profile
    {

        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerFullNameDTO>();
            CreateMap<CustomerFullNameDTO, Customer>();

            CreateMap<Customer, CustomerPostDTO>();
            CreateMap<CustomerPostDTO, Customer>();

            CreateMap<Customer, CustomerCityCountryDTO>()
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Country));
            CreateMap<CustomerCityCountryDTO, Customer>();

        }



    }
}
