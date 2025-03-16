using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class QuestionOptionService(IQuestionOptionRepository optionRepository, IMapper mapper) : IQuestionOptionService
    {
        private readonly IQuestionOptionRepository _optionRepository = optionRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<QuestionOptionResponse> CreateOptionAsync(int questionId, QuestionOptionRequest request)
        {
            var option = _mapper.Map<QuestionOptionEntity>(request);
            option.QuestionId = questionId;
            var createdOption = await _optionRepository.CreateOptionAsync(option);
            var response = _mapper.Map<QuestionOptionResponse>(createdOption);
            response.Success = true;
            return response;
        }

        public async Task<QuestionOptionResponse> GetOptionByIdAsync(int id)
        {
            var option = await _optionRepository.GetOptionByIdAsync(id) ?? throw new Exception("Option not found");
            var response = _mapper.Map<QuestionOptionResponse>(option);
            response.Success = true;
            return response;
        }

        public async Task<List<QuestionOptionResponse>> GetOptionsByQuestionIdAsync(int questionId)
        {
            var options = await _optionRepository.GetOptionsByQuestionIdAsync(questionId);
            return _mapper.Map<List<QuestionOptionResponse>>(options);
        }

        public async Task<QuestionOptionResponse> UpdateOptionAsync(int id, QuestionOptionRequest request)
        {
            var option = _mapper.Map<QuestionOptionEntity>(request);
            var updatedOption = await _optionRepository.UpdateOptionAsync(id, option);
            var response = _mapper.Map<QuestionOptionResponse>(updatedOption);
            response.Success = true;
            return response;
        }

        public async Task<bool> DeleteOptionAsync(int id)
        {
            return await _optionRepository.DeleteOptionAsync(id);
        }
    }
}