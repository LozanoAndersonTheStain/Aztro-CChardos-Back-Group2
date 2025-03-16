using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Mappings
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerRequest, AnswerEntity>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<AnswerEntity, AnswerResponse>()
                .ForMember(dest => dest.UtcDate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.LocalDate, opt => opt.MapFrom(src =>
                    TimeZoneInfo.ConvertTimeFromUtc(
                        src.Date,
                        TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")
                    ).ToString("dd/MM/yyyy HH:mm:ss")));
        }
    }
}