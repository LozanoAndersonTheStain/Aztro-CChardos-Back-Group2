using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IAnswerService
    {
        Task<AnswerResponse> CreateAnswerAsync(AnswerRequest request);
        Task<AnswerResponse> GetAnswerByIdAsync(int id);
        Task<List<AnswerResponse>> GetAnswersByUserIdAsync(int userId);
        Task<List<AnswerResponse>> GetAnswersByQuestionIdAsync(int questionId);
        Task<bool> DeleteAnswerAsync(int id);
    }
}