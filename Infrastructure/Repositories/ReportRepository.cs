using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnswerEntity>> GetAnswersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.QuestionOption)
                .Include(a => a.User)
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .ToListAsync();
        }

        public async Task<List<AnswerEntity>> GetAnswersByCategoryAsync(string category)
        {
            return await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.QuestionOption)
                .Include(a => a.User)
                .Where(a => a.Question.Category == category)
                .ToListAsync();
        }

        public async Task<List<CombinationEntity>> GetDestinationStatisticsAsync()
        {
            return await _context.Combinations
                .Include(c => c.FirstCity)
                .Include(c => c.SecondCity)
                .ToListAsync();
        }

        public async Task<List<UserEntity>> GetUserActivityStatisticsAsync()
        {
            return await _context.Users
                .Include(u => u.Answers)
                    .ThenInclude(a => a.Question)
                .Include(u => u.Answers)
                    .ThenInclude(a => a.QuestionOption)
                .ToListAsync();
        }

        public async Task<List<AnswerEntity>> GetAllAnswersWithDetailsAsync()
        {
            return await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.QuestionOption)
                .Include(a => a.User)
                .ToListAsync();
        }
    }
}