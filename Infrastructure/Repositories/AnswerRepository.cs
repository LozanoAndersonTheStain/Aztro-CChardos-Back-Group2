using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories
{
    public class AnswerRepository(ApplicationDbContext context) : IAnswerRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<AnswerEntity> CreateAnswerAsync(AnswerEntity answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<AnswerEntity?> GetAnswerByIdAsync(int id)
        {
            return await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.QuestionOption)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<AnswerEntity>> GetAnswersByUserIdAsync(int userId)
        {
            return await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.QuestionOption)
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<AnswerEntity>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _context.Answers
                .Include(a => a.User)
                .Include(a => a.QuestionOption)
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<List<AnswerEntity>> GetAnswersByIdsAsync(List<int> answerIds)
        {
            return await _context.Answers
                .Include(a => a.Question)
                .Where(a => answerIds.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<bool> DeleteAnswerAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id) 
                ?? throw new Exception("Answer not found");
            
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}