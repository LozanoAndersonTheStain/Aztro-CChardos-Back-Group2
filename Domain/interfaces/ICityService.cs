using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface ICityService
    {
        Task<CityResponse> CreateCityAsync(CityRequest request);
        Task<List<CityResponse>> CreateCitiesAsync(List<CityRequest> requests);
        Task<CityResponse> GetCityByIdAsync(int id);
        Task<List<CityResponse>> GetAllCitiesAsync();
        Task<CityResponse> UpdateCityAsync(int id, CityRequest request);
        Task<bool> DeleteCityAsync(int id);
    }
}