using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface ITravelPlanRepository
    {
        Task<TravelPlanEntity> CreateTravelPlanAsync(TravelPlanEntity travelPlanEntity);
        Task<TravelPlanEntity?> GetTravelPlanByIdAsync(int id);
        Task<TravelPlanEntity?> GetTravelPlanByDestinationNameAsync(string destinationName);
        Task<List<TravelPlanEntity>> GetAllTravelPlansAsync();
        Task<TravelPlanEntity> UpdateTravelPlanAsync(int id, TravelPlanEntity travelPlanEntity);
        Task<bool> DeleteTravelPlanAsync(int id); 
    }
}