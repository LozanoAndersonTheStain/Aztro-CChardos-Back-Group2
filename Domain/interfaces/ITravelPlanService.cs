using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface ITravelPlanService
    {
        Task<TravelPlanResponse> CreateTravelPlanAsync(TravelPlanRequest travelPlanRequest);
        Task<List<TravelPlanResponse>> CreateTravelPlansAsync(List<TravelPlanRequest> travelPlanRequests);
        Task<TravelPlanResponse> GetTravelPlanByIdAsync(int id);
        Task<TravelPlanResponse?> GetTravelPlanByDestinationNameAsync(string destinationName);
        Task<List<TravelPlanResponse>> GetAllTravelPlansAsync();
        Task<TravelPlanResponse> UpdateTravelPlanAsync(int id, TravelPlanRequest travelPlanRequest);
        Task<bool> DeleteTravelPlanAsync(int id);
        Task<TravelPlanResponse> AssignToCityAsync(int travelPlanId, int cityId);
    }
}