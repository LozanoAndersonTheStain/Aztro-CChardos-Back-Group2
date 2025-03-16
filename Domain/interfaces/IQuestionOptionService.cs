using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IQuestionOptionService
    {
        Task<QuestionOptionResponse> CreateOptionAsync(int questionId, QuestionOptionRequest request);
        Task<QuestionOptionResponse> GetOptionByIdAsync(int id);
        Task<List<QuestionOptionResponse>> GetOptionsByQuestionIdAsync(int questionId);
        Task<QuestionOptionResponse> UpdateOptionAsync(int id, QuestionOptionRequest request);
        Task<bool> DeleteOptionAsync(int id);
    }
}