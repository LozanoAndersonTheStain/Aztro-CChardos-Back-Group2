using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories
{
    public class QuestionOptionRepository(ApplicationDbContext context) : IQuestionOptionRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<QuestionOptionEntity> CreateOptionAsync(QuestionOptionEntity option)
        {
            _context.QuestionOptions.Add(option);
            await _context.SaveChangesAsync();
            return option;
        }

        public async Task<QuestionOptionEntity?> GetOptionByIdAsync(int id)
        {
            return await _context.QuestionOptions.FindAsync(id);
        }

        public async Task<List<QuestionOptionEntity>> GetOptionsByQuestionIdAsync(int questionId)
        {
            return await _context.QuestionOptions
                .Where(o => o.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<QuestionOptionEntity> UpdateOptionAsync(int id, QuestionOptionEntity option)
        {
            var existingOption = await _context.QuestionOptions.FindAsync(id) 
                ?? throw new Exception("Option not found");
            
            existingOption.Description = option.Description;
            _context.QuestionOptions.Update(existingOption);
            await _context.SaveChangesAsync();
            return existingOption;
        }

        public async Task<bool> DeleteOptionAsync(int id)
        {
            var option = await _context.QuestionOptions.FindAsync(id) 
                ?? throw new Exception("Option not found");
            
            _context.QuestionOptions.Remove(option);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}