using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Mappings
{
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<DestinationRequest, DestinationEntity>();
            CreateMap<DestinationEntity, DestinationResponse>()
                .ForMember(dest => dest.FirstCity, opt => opt.MapFrom(src => src.FirstCity))
                .ForMember(dest => dest.SecondCity, opt => opt.MapFrom(src => src.SecondCity))
                .ForMember(dest => dest.FirstCityTravelPlan, opt => opt.MapFrom(src => src.TravelPlan))
                .ForMember(dest => dest.SecondCityTravelPlan, opt => opt.MapFrom(src => src.TravelPlan));
        }
    }
}