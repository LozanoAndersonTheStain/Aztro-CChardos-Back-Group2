using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Mappings
{
    //* Clase de perfil de AutoMapper para mapear entre UserRequest, UserEntity y UserResponse
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //* Mapea de UserRequest a UserEntity
            CreateMap<UserRequest, UserEntity>();
            //* Mapea de UserEntity a UserResponse
            CreateMap<UserEntity, UserResponse>();
        }
    }
}