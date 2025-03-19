using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class QuestionService(IQuestionRepository questionRepository, IMapper mapper) : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository = questionRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<QuestionResponse> CreateQuestionAsync(QuestionRequest request)
        {
            var question = _mapper.Map<QuestionEntity>(request);
            var createdQuestion = await _questionRepository.CreateQuestionAsync(question);
            var response = _mapper.Map<QuestionResponse>(createdQuestion);
            response.Success = true;
            return response;
        }

        public async Task<List<QuestionResponse>> CreateMultipleQuestionsAsync(List<QuestionRequest> requests)
        {
            var questions = _mapper.Map<List<QuestionEntity>>(requests);
            var createdQuestions = await _questionRepository.CreateMultipleQuestionsAsync(questions);
            var response = _mapper.Map<List<QuestionResponse>>(createdQuestions);
            response.ForEach(q => q.Success = true);
            return response;
        }

        public async Task<List<QuestionResponse>> CreateQuestionsByCategory(string category, List<QuestionRequest> questions)
        {
            questions.ForEach(q => q.Category = category);
            return await CreateMultipleQuestionsAsync(questions);
        }

        public async Task<QuestionResponse> GetQuestionByIdAsync(int id)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(id) ?? throw new Exception("Question not found");
            var response = _mapper.Map<QuestionResponse>(question);
            response.Success = true;
            return response;
        }

        public async Task<List<QuestionResponse>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            return _mapper.Map<List<QuestionResponse>>(questions);
        }

        public async Task<List<QuestionResponse>> GetQuestionsPaginatedAsync(int page, int pageSize)
        {
            var questions = await _questionRepository.GetQuestionsPaginatedAsync(page, pageSize);
            return _mapper.Map<List<QuestionResponse>>(questions);
        }

        public async Task<QuestionResponse> UpdateQuestionAsync(int id, QuestionRequest request)
        {
            var question = _mapper.Map<QuestionEntity>(request);
            var updatedQuestion = await _questionRepository.UpdateQuestionAsync(id, question);
            var response = _mapper.Map<QuestionResponse>(updatedQuestion);
            response.Success = true;
            return response;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            return await _questionRepository.DeleteQuestionAsync(id);
        }
    }
}