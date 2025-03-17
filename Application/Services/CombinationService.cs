using AutoMapper;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class CombinationService : ICombinationService
    {
        private readonly ICombinationRepository _combinationRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public CombinationService(
            ICombinationRepository combinationRepository,
            IAnswerRepository answerRepository,
            IMapper mapper)
        {
            _combinationRepository = combinationRepository;
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<CombinationResponse> CreateCombinationAsync(CombinationRequest request)
        {
            var combination = _mapper.Map<CombinationEntity>(request);
            var result = await _combinationRepository.CreateCombinationAsync(combination);
            return _mapper.Map<CombinationResponse>(result);
        }

        public async Task<List<CombinationResponse>> CreateMultipleCombinationsAsync(CreateCombinationsRequest request)
        {
            var combinations = _mapper.Map<List<CombinationEntity>>(request.Combinations);
            var results = await _combinationRepository.CreateMultipleCombinationsAsync(combinations);
            return _mapper.Map<List<CombinationResponse>>(results);
        }

        public async Task<CombinationResponse> GetCombinationByIdAsync(int id)
        {
            var combination = await _combinationRepository.GetCombinationByIdAsync(id)
                ?? throw new Exception($"Combination with ID {id} not found");
            return _mapper.Map<CombinationResponse>(combination);
        }

        public async Task<List<CombinationResponse>> GetAllCombinationsAsync()
        {
            var combinations = await _combinationRepository.GetAllCombinationsAsync();
            return _mapper.Map<List<CombinationResponse>>(combinations);
        }

        public async Task<DestinationResponse> GetMatchingDestinationsAsync(List<int> answerIds)
        {
            var answers = await _answerRepository.GetAnswersByIdsAsync(answerIds);
            
            if (answers.Count != 6)
                throw new Exception("Must provide exactly 6 answers for matching");

            var destinationOptionId = answers.First(a => a.Question.QuestionText.Contains("entorno prefieres")).QuestionOptionId;
            var climateOptionId = answers.First(a => a.Question.QuestionText.Contains("clima prefieres")).QuestionOptionId;
            var activityOptionId = answers.First(a => a.Question.QuestionText.Contains("actividades prefieres")).QuestionOptionId;
            var accommodationOptionId = answers.First(a => a.Question.QuestionText.Contains("alojamiento prefieres")).QuestionOptionId;
            var durationOptionId = answers.First(a => a.Question.QuestionText.Contains("tiempo planeas")).QuestionOptionId;
            var ageOptionId = answers.First(a => a.Question.QuestionText.Contains("rango de edad")).QuestionOptionId;

            var combination = await _combinationRepository.GetCombinationByOptionsAsync(
                destinationOptionId,
                climateOptionId,
                activityOptionId,
                accommodationOptionId,
                durationOptionId,
                ageOptionId
            );

            if (combination == null)
                return await GetDefaultDestinationsAsync();

            return new DestinationResponse
            {
                FirstCity = _mapper.Map<CityResponse>(combination.FirstCity),
                SecondCity = _mapper.Map<CityResponse>(combination.SecondCity),
                Success = true
            };
        }

        public async Task<DestinationResponse> GetDefaultDestinationsAsync()
        {
            var defaultCombination = await _combinationRepository.GetDefaultCombinationAsync()
                ?? throw new Exception("Default combination not found");

            return new DestinationResponse
            {
                FirstCity = _mapper.Map<CityResponse>(defaultCombination.FirstCity),
                SecondCity = _mapper.Map<CityResponse>(defaultCombination.SecondCity),
                Success = true
            };
        }

        public async Task<CombinationResponse> UpdateCombinationAsync(int id, CombinationRequest request)
        {
            var existingCombination = await _combinationRepository.GetCombinationByIdAsync(id)
                ?? throw new Exception($"Combination with ID {id} not found");

            _mapper.Map(request, existingCombination);
            var result = await _combinationRepository.UpdateCombinationAsync(existingCombination);
            return _mapper.Map<CombinationResponse>(result);
        }

        public async Task<bool> DeleteCombinationAsync(int id)
        {
            return await _combinationRepository.DeleteCombinationAsync(id);
        }
    }
}