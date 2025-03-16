using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IDestinationRepository
    {
        Task<DestinationEntity> CreateDestinationAsync(DestinationEntity destination);
        Task<DestinationEntity?> GetDestinationByIdAsync(int id);
        Task<List<DestinationEntity>> GetAllDestinationsAsync();
        Task<List<DestinationEntity>> GetDestinationsByFirstCityIdAsync(int cityId);
        Task<List<DestinationEntity>> GetDestinationsBySecondCityIdAsync(int cityId);
        Task<DestinationEntity> UpdateDestinationAsync(int id, DestinationEntity destination);
        Task<bool> DeleteDestinationAsync(int id);
    }
}