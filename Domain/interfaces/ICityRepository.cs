using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface ICityRepository
    {
        Task<CityEntity> CreateCityAsync(CityEntity city);
        Task<List<CityEntity>> CreateCitiesAsync(List<CityEntity> cities);
        Task<CityEntity?> GetCityByIdAsync(int id);
        Task<List<CityEntity>> GetAllCitiesAsync();
        Task<CityEntity?> GetCityByNameAsync(string name);
        Task<CityEntity> UpdateCityAsync(int id, CityEntity city);
        Task<bool> DeleteCityAsync(int id);
    }
}