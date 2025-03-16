using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Mappings
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityRequest, CityEntity>();
            CreateMap<CityEntity, CityResponse>()
            .ForMember(dest => dest.Success, 
                opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Message, 
                opt => opt.MapFrom(src => "City updated successfully"));
        }
    }
}