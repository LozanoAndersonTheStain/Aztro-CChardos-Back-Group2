using Microsoft.EntityFrameworkCore;
using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories
{
    public class CombinationRepository(ApplicationDbContext context) : ICombinationRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<CombinationEntity> CreateCombinationAsync(CombinationEntity combination)
        {
            _context.Combinations.Add(combination);
            await _context.SaveChangesAsync();
            return combination;
        }

        public async Task<List<CombinationEntity>> CreateMultipleCombinationsAsync(List<CombinationEntity> combinations)
        {
            await _context.Combinations.AddRangeAsync(combinations);
            await _context.SaveChangesAsync();
            return combinations;
        }

        public async Task<CombinationEntity?> GetCombinationByIdAsync(int id)
        {
            return await _context.Combinations
                .Include(c => c.FirstCity)
                .Include(c => c.SecondCity)
                .Include(c => c.DestinationOption)
                .Include(c => c.ClimateOption)
                .Include(c => c.ActivityOption)
                .Include(c => c.AccommodationOption)
                .Include(c => c.DurationOption)
                .Include(c => c.AgeOption)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CombinationEntity?> GetCombinationByOptionsAsync(
            int destinationOptionId,
            int climateOptionId,
            int activityOptionId,
            int accommodationOptionId,
            int durationOptionId,
            int ageOptionId)
        {
            return await _context.Combinations
                .Include(c => c.FirstCity)
                .Include(c => c.SecondCity)
                .Include(c => c.DestinationOption)
                .Include(c => c.ClimateOption)
                .Include(c => c.ActivityOption)
                .Include(c => c.AccommodationOption)
                .Include(c => c.DurationOption)
                .Include(c => c.AgeOption)
                .FirstOrDefaultAsync(c =>
                    c.DestinationOptionId == destinationOptionId &&
                    c.ClimateOptionId == climateOptionId &&
                    c.ActivityOptionId == activityOptionId &&
                    c.AccommodationOptionId == accommodationOptionId &&
                    c.DurationOptionId == durationOptionId &&
                    c.AgeOptionId == ageOptionId);
        }

        public async Task<List<CombinationEntity>> GetAllCombinationsAsync()
        {
            return await _context.Combinations
                .Include(c => c.FirstCity)
                .Include(c => c.SecondCity)
                .Include(c => c.DestinationOption)
                .Include(c => c.ClimateOption)
                .Include(c => c.ActivityOption)
                .Include(c => c.AccommodationOption)
                .Include(c => c.DurationOption)
                .Include(c => c.AgeOption)
                .ToListAsync();
        }

        public async Task<CombinationEntity?> GetDefaultCombinationAsync()
        {
            return await _context.Combinations
                .Include(c => c.FirstCity)
                .Include(c => c.SecondCity)
                .FirstOrDefaultAsync(c => c.Id == 1);
        }

        public async Task<CombinationEntity> UpdateCombinationAsync(CombinationEntity combination)
        {
            _context.Entry(combination).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return combination;
        }

        public async Task<bool> DeleteCombinationAsync(int id)
        {
            var combination = await _context.Combinations.FindAsync(id);
            if (combination == null)
                return false;

            _context.Combinations.Remove(combination);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}