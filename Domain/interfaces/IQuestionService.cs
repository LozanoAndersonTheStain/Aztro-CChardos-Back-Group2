using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionResponse> CreateQuestionAsync(QuestionRequest request);
        Task<List<QuestionResponse>> CreateMultipleQuestionsAsync(List<QuestionRequest> requests);
        Task<QuestionResponse> GetQuestionByIdAsync(int id);
        Task<List<QuestionResponse>> GetAllQuestionsAsync();
        Task<List<QuestionResponse>> GetQuestionsPaginatedAsync(int page, int pageSize);
        Task<QuestionResponse> UpdateQuestionAsync(int id, QuestionRequest request);
        Task<bool> DeleteQuestionAsync(int id);
    }
}