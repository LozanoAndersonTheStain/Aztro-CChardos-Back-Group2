using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface ICombinationService
    {
        Task<CombinationResponse> CreateCombinationAsync(CombinationRequest request);
        Task<List<CombinationResponse>> CreateMultipleCombinationsAsync(CreateCombinationsRequest request);
        Task<CombinationResponse> GetCombinationByIdAsync(int id);
        Task<List<CombinationResponse>> GetAllCombinationsAsync();
        Task<DestinationResponse> GetMatchingDestinationsAsync(List<int> answerIds);
        Task<DestinationResponse> GetDefaultDestinationsAsync();
        Task<CombinationResponse> UpdateCombinationAsync(int id, CombinationRequest request);
        Task<bool> DeleteCombinationAsync(int id);
    }
}