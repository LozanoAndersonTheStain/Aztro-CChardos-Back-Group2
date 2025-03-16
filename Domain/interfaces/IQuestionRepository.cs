using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<QuestionEntity> CreateQuestionAsync(QuestionEntity question);
        Task<List<QuestionEntity>> CreateMultipleQuestionsAsync(List<QuestionEntity> questions);
        Task<QuestionEntity?> GetQuestionByIdAsync(int id);
        Task<List<QuestionEntity>> GetAllQuestionsAsync();
        Task<List<QuestionEntity>> GetQuestionsPaginatedAsync(int page, int pageSize);
        Task<QuestionEntity> UpdateQuestionAsync(int id, QuestionEntity question);
        Task<bool> DeleteQuestionAsync(int id);
    }
}