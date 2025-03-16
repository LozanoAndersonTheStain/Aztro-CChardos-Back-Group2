using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IAnswerRepository
    {
        Task<AnswerEntity> CreateAnswerAsync(AnswerEntity answer);
        Task<AnswerEntity?> GetAnswerByIdAsync(int id);
        Task<List<AnswerEntity>> GetAnswersByUserIdAsync(int userId);
        Task<List<AnswerEntity>> GetAnswersByQuestionIdAsync(int questionId);
        Task<bool> DeleteAnswerAsync(int id);
    }
}