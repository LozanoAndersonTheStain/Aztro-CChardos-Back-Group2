using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories
{
    public class TravelPlanRespository(ApplicationDbContext context) : ITravelPlanRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<TravelPlanEntity> CreateTravelPlanAsync(TravelPlanEntity travelPlan)
        {
            _context.TravelPlans.Add(travelPlan);
            await _context.SaveChangesAsync();
            return travelPlan;
        }

        public async Task<List<TravelPlanEntity>> GetAllTravelPlansAsync()
        {
            return await _context.TravelPlans
                .Include(tp => tp.TransportOptions)
                .Include(tp => tp.AccommodationOptions)
                .ToListAsync();
        }

        public async Task<TravelPlanEntity?> GetTravelPlanByDestinationNameAsync(string destinationName)
        {
            return await _context.TravelPlans
                .Include(tp => tp.TransportOptions)
                .Include(tp => tp.AccommodationOptions)
                .FirstOrDefaultAsync(tp => tp.DestinationName == destinationName);
        }

        public async Task<TravelPlanEntity?> GetTravelPlanByIdAsync(int id)
        {
            return await _context.TravelPlans
                .Include(tp => tp.TransportOptions)
                .Include(tp => tp.AccommodationOptions)
                .FirstOrDefaultAsync(tp => tp.Id == id);
        }

        public async Task<TravelPlanEntity> UpdateTravelPlanAsync(int id, TravelPlanEntity travelPlanEntity)
        {
            _context.TravelPlans.Update(travelPlanEntity);
            await _context.SaveChangesAsync();
            return travelPlanEntity;
        }

        
        public async Task<bool> DeleteTravelPlanAsync(int id)
        {
            var travelPlan = await _context.TravelPlans.FindAsync(id);
            if (travelPlan == null) return false;

            _context.TravelPlans.Remove(travelPlan);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}