using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories
{
    public class CityRepository(ApplicationDbContext context) : ICityRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<CityEntity> CreateCityAsync(CityEntity city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<List<CityEntity>> CreateCitiesAsync(List<CityEntity> cities)
        {
            _context.Cities.AddRange(cities);
            await _context.SaveChangesAsync();
            return cities;
        }

        public async Task<CityEntity?> GetCityByIdAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<List<CityEntity>> GetAllCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<CityEntity> UpdateCityAsync(int id, CityEntity city)
        {
            var existingCity = await _context.Cities.FindAsync(id) 
                ?? throw new Exception("City not found");
            
            existingCity.Description = city.Description;
            _context.Cities.Update(existingCity);
            await _context.SaveChangesAsync();
            return existingCity;
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id) 
                ?? throw new Exception("City not found");
            
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}