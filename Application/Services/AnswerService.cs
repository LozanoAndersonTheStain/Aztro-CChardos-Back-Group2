using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class AnswerService(IAnswerRepository answerRepository, IMapper mapper) : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository = answerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<AnswerResponse> CreateAnswerAsync(AnswerRequest request)
        {
            try
            {
                var answer = _mapper.Map<AnswerEntity>(request);
                var createdAnswer = await _answerRepository.CreateAnswerAsync(answer);
                var response = _mapper.Map<AnswerResponse>(createdAnswer);
                response.Success = true;
                response.Message = "Answer created successfully";
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating answer: {ex.Message}");
            }
        }

        public async Task<AnswerResponse> GetAnswerByIdAsync(int id)
        {
            var answer = await _answerRepository.GetAnswerByIdAsync(id) ?? throw new Exception("Answer not found");

            var response = _mapper.Map<AnswerResponse>(answer);
            response.Success = true;
            return response;
        }

        public async Task<List<AnswerResponse>> GetAnswersByUserIdAsync(int userId)
        {
            var answers = await _answerRepository.GetAnswersByUserIdAsync(userId);
            return _mapper.Map<List<AnswerResponse>>(answers);
        }

        public async Task<List<AnswerResponse>> GetAnswersByQuestionIdAsync(int questionId)
        {
            var answers = await _answerRepository.GetAnswersByQuestionIdAsync(questionId);
            return _mapper.Map<List<AnswerResponse>>(answers);
        }

        public async Task<bool> DeleteAnswerAsync(int id)
        {
            return await _answerRepository.DeleteAnswerAsync(id);
        }
    }
}