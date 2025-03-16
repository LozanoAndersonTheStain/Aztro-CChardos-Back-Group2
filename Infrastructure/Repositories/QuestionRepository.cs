using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories
{
    public class QuestionRepository(ApplicationDbContext context) : IQuestionRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<QuestionEntity> CreateQuestionAsync(QuestionEntity question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<List<QuestionEntity>> CreateMultipleQuestionsAsync(List<QuestionEntity> questions) {
            _context.Questions.AddRange(questions);
            await _context.SaveChangesAsync();
            return questions;
        }

        public async Task<QuestionEntity?> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<QuestionEntity>> GetAllQuestionsAsync()
        {
            return await _context.Questions
                .Include(q => q.Options)
                .ToListAsync();
        }

        public async Task<List<QuestionEntity>> GetQuestionsPaginatedAsync(int page, int pageSize)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<QuestionEntity> UpdateQuestionAsync(int id, QuestionEntity question)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var existingQuestion = await _context.Questions
                    .Include(q => q.Options)
                    .FirstOrDefaultAsync(q => q.Id == id) 
                    ?? throw new Exception("Question not found");
                
                // Update question text
                existingQuestion.QuestionText = question.QuestionText;

                // Remove existing options
                _context.QuestionOptions.RemoveRange(existingQuestion.Options);

                // Add new options
                if (question.Options != null && question.Options.Count > 0)
                {
                    foreach (var option in question.Options)
                    {
                        option.QuestionId = id;
                    }
                    existingQuestion.Options = question.Options;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return existingQuestion;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id) 
                ?? throw new Exception("Question not found");
            
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}