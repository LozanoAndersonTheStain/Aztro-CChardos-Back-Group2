using AutoMapper;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class CombinationService(ICombinationRepository combinationRepository, IDestinationRepository destinationRepository, ITravelPlanRepository travelPlanRepository, IMapper mapper) : ICombinationService
    {
        private readonly ICombinationRepository _combinationRepository = combinationRepository;
        private readonly IDestinationRepository _destinationRepository = destinationRepository;
        private readonly ITravelPlanRepository _travelPlanRepository = travelPlanRepository;
        private readonly IMapper _mapper = mapper;

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

        public async Task<DestinationResponse> GetMatchingDestinationsAsync(List<int> optionIds)
        {
            if (optionIds.Count != 6)
                throw new Exception("Must provide exactly 6 answers for matching");

            var destinationOptionId = optionIds[0];
            var climateOptionId = optionIds[1];
            var activityOptionId = optionIds[2];
            var accommodationOptionId = optionIds[3];
            var durationOptionId = optionIds[4];
            var ageOptionId = optionIds[5];

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

            var firstCityTravelPlan = await _travelPlanRepository.GetTravelPlanByDestinationNameAsync(combination.FirstCity.Name);
            var secondCityTravelPlan = await _travelPlanRepository.GetTravelPlanByDestinationNameAsync(combination.SecondCity.Name);

            return new DestinationResponse
            {
                FirstCity = _mapper.Map<CityResponse>(combination.FirstCity),
                SecondCity = _mapper.Map<CityResponse>(combination.SecondCity),
                FirstCityTravelPlan = _mapper.Map<TravelPlanResponse>(firstCityTravelPlan),
                SecondCityTravelPlan = _mapper.Map<TravelPlanResponse>(secondCityTravelPlan),
                Success = true
            };
        }

        public async Task<DestinationResponse> GetDefaultDestinationsAsync()
        {
            var defaultCombination = await _combinationRepository.GetDefaultCombinationAsync()
                ?? throw new Exception("Default combination not found");

            var destination = await _destinationRepository.GetDestinationsByFirstCityIdAsync(defaultCombination.FirstCityId);
            var firstCityTravelPlan = destination?.FirstOrDefault()?.TravelPlan;
            var secondCityTravelPlan = destination?.FirstOrDefault()?.TravelPlan;

            return new DestinationResponse
            {
                FirstCity = _mapper.Map<CityResponse>(defaultCombination.FirstCity),
                SecondCity = _mapper.Map<CityResponse>(defaultCombination.SecondCity),
                FirstCityTravelPlan = _mapper.Map<TravelPlanResponse>(firstCityTravelPlan),
                SecondCityTravelPlan = _mapper.Map<TravelPlanResponse>(secondCityTravelPlan),
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