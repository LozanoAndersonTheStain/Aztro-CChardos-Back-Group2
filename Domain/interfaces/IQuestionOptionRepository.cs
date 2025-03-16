using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IQuestionOptionRepository
    {
        Task<QuestionOptionEntity> CreateOptionAsync(QuestionOptionEntity option);
        Task<QuestionOptionEntity?> GetOptionByIdAsync(int id);
        Task<List<QuestionOptionEntity>> GetOptionsByQuestionIdAsync(int questionId);
        Task<QuestionOptionEntity> UpdateOptionAsync(int id, QuestionOptionEntity option);
        Task<bool> DeleteOptionAsync(int id);
    }
}