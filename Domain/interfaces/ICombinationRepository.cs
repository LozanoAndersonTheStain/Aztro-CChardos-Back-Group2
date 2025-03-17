using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface ICombinationRepository
    {
        Task<CombinationEntity> CreateCombinationAsync(CombinationEntity combination);
        Task<List<CombinationEntity>> CreateMultipleCombinationsAsync(List<CombinationEntity> combinations);
        Task<CombinationEntity?> GetCombinationByIdAsync(int id);
        Task<CombinationEntity?> GetCombinationByOptionsAsync(
            int destinationOptionId,
            int climateOptionId,
            int activityOptionId,
            int accommodationOptionId,
            int durationOptionId,
            int ageOptionId
        );
        Task<List<CombinationEntity>> GetAllCombinationsAsync();
        Task<CombinationEntity?> GetDefaultCombinationAsync();
        Task<CombinationEntity> UpdateCombinationAsync(CombinationEntity combination);
        Task<bool> DeleteCombinationAsync(int id);
    }
}