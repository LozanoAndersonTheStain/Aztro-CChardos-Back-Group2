using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Mappings
{
    public class CombinationProfile : Profile
    {
        public CombinationProfile()
        {
            CreateMap<CombinationRequest, CombinationEntity>();

            CreateMap<CombinationEntity, CombinationResponse>()
                .ForMember(dest => dest.FirstCity, opt => opt.MapFrom(src => src.FirstCity))
                .ForMember(dest => dest.SecondCity, opt => opt.MapFrom(src => src.SecondCity))
                .ForMember(dest => dest.DestinationOption, opt => opt.MapFrom(src => src.DestinationOption))
                .ForMember(dest => dest.ClimateOption, opt => opt.MapFrom(src => src.ClimateOption))
                .ForMember(dest => dest.ActivityOption, opt => opt.MapFrom(src => src.ActivityOption))
                .ForMember(dest => dest.AccommodationOption, opt => opt.MapFrom(src => src.AccommodationOption))
                .ForMember(dest => dest.DurationOption, opt => opt.MapFrom(src => src.DurationOption))
                .ForMember(dest => dest.AgeOption, opt => opt.MapFrom(src => src.AgeOption));
        }
    }
}