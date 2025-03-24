using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Mappings
{
    public class TravelPlanProfile : Profile
    {
        public TravelPlanProfile()
        {
            CreateMap<TravelPlanRequest, TravelPlanEntity>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.TransportOptions, opt => opt.MapFrom(src => src.TransportOptions))
                .ForMember(dest => dest.AccommodationOptions, opt => opt.MapFrom(src => src.AccommodationOptions));

            CreateMap<TravelPlanEntity, TravelPlanResponse>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            CreateMap<TransportOptionRequest, TransportOptionEntity>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<TransportOptionEntity, TransportOptionResponse>();

            CreateMap<AccommodationOptionRequest, AccommodationOptionEntity>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<AccommodationOptionEntity, AccommodationOptionResponse>();
        }
    }
}