using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IDestinationService
    {
        Task<DestinationResponse> CreateDestinationAsync(DestinationRequest request);
        Task<DestinationResponse> GetDestinationByIdAsync(int id);
        Task<List<DestinationResponse>> GetAllDestinationsAsync();
        Task<List<DestinationResponse>> GetDestinationsByFirstCityIdAsync(int cityId);
        Task<List<DestinationResponse>> GetDestinationsBySecondCityIdAsync(int cityId);
        Task<DestinationResponse> UpdateDestinationAsync(int id, DestinationRequest request);
        Task<bool> DeleteDestinationAsync(int id);
    }
}