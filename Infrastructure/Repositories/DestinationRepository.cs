using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories
{
    public class DestinationRepository(ApplicationDbContext context) : IDestinationRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<DestinationEntity> CreateDestinationAsync(DestinationEntity destination)
        {
            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async Task<DestinationEntity?> GetDestinationByIdAsync(int id)
        {
            return await _context.Destinations
                .Include(d => d.FirstCity)
                .Include(d => d.SecondCity)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DestinationEntity>> GetAllDestinationsAsync()
        {
            return await _context.Destinations
                .Include(d => d.FirstCity)
                .Include(d => d.SecondCity)
                .ToListAsync();
        }

        public async Task<List<DestinationEntity>> GetDestinationsByFirstCityIdAsync(int cityId)
        {
            return await _context.Destinations
                .Include(d => d.SecondCity)
                .Where(d => d.FirstCityId == cityId)
                .ToListAsync();
        }

        public async Task<List<DestinationEntity>> GetDestinationsBySecondCityIdAsync(int cityId)
        {
            return await _context.Destinations
                .Include(d => d.FirstCity)
                .Where(d => d.SecondCityId == cityId)
                .ToListAsync();
        }

        public async Task<DestinationEntity> UpdateDestinationAsync(int id, DestinationEntity destination)
        {
            var existingDestination = await _context.Destinations.FindAsync(id) 
                ?? throw new Exception("Destination not found");
            
            existingDestination.Combination = destination.Combination;
            existingDestination.FirstCityId = destination.FirstCityId;
            existingDestination.SecondCityId = destination.SecondCityId;
            
            _context.Destinations.Update(existingDestination);
            await _context.SaveChangesAsync();
            return existingDestination;
        }

        public async Task<bool> DeleteDestinationAsync(int id)
        {
            var destination = await _context.Destinations.FindAsync(id) 
                ?? throw new Exception("Destination not found");
            
            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}