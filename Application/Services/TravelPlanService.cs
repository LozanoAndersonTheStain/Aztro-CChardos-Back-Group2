using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class TravelPlanService(ITravelPlanRepository travelPlanRepository, ICityRepository cityRepository, IMapper mapper) : ITravelPlanService
    {
        private readonly ITravelPlanRepository _travelPlanRepository = travelPlanRepository;
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<TravelPlanResponse> CreateTravelPlanAsync(TravelPlanRequest travelPlanRequest)
        {
            var travelPlan = _mapper.Map<TravelPlanEntity>(travelPlanRequest);
            var result = await _travelPlanRepository.CreateTravelPlanAsync(travelPlan);
            return _mapper.Map<TravelPlanResponse>(result);
        }

        public async Task<List<TravelPlanResponse>> CreateTravelPlansAsync(List<TravelPlanRequest> travelPlanRequests)
        {
            var responses = new List<TravelPlanResponse>();

            foreach (var request in travelPlanRequests)
            {
                var travelPlan = _mapper.Map<TravelPlanEntity>(request);
                var result = await _travelPlanRepository.CreateTravelPlanAsync(travelPlan);
                responses.Add(_mapper.Map<TravelPlanResponse>(result));
            }

            return responses;
        }

        public async Task<List<TravelPlanResponse>> GetAllTravelPlansAsync()
        {
            var travelPlans = await _travelPlanRepository.GetAllTravelPlansAsync();
            return _mapper.Map<List<TravelPlanResponse>>(travelPlans);
        }

        public async Task<TravelPlanResponse?> GetTravelPlanByDestinationNameAsync(string destinationName)
        {
            var travelPlan = await _travelPlanRepository.GetTravelPlanByDestinationNameAsync(destinationName);
            return travelPlan == null ? null : _mapper.Map<TravelPlanResponse>(travelPlan);
        }

        public async Task<TravelPlanResponse> GetTravelPlanByIdAsync(int id)
        {
            var travelPlan = await _travelPlanRepository.GetTravelPlanByIdAsync(id);
            return _mapper.Map<TravelPlanResponse>(travelPlan);
        }

        public async Task<TravelPlanResponse> UpdateTravelPlanAsync(int id, TravelPlanRequest travelPlanRequest)
        {
            var existingTravelPlan = await _travelPlanRepository.GetTravelPlanByDestinationNameAsync(travelPlanRequest.DestinationName)
                ?? throw new Exception($"Travel plan for destination '{travelPlanRequest.DestinationName}' not found");

            _mapper.Map(travelPlanRequest, existingTravelPlan);
            var result = await _travelPlanRepository.UpdateTravelPlanAsync(id, existingTravelPlan);
            return _mapper.Map<TravelPlanResponse>(result);
        }

        public async Task<bool> DeleteTravelPlanAsync(int id)
        {
            return await _travelPlanRepository.DeleteTravelPlanAsync(id);
        }

        public async Task<TravelPlanResponse> AssignToCityAsync(int travelPlanId, int cityId)
        {
            var travelPlan = await _travelPlanRepository.GetTravelPlanByIdAsync(travelPlanId)
                ?? throw new Exception($"Travel Plan with ID {travelPlanId} not found");

            var city = await _cityRepository.GetCityByIdAsync(cityId)
                ?? throw new Exception($"City with ID {cityId} not found");

            var success = await _cityRepository.AssignTravelPlanAsync(city, travelPlan);
            if (!success)
                throw new Exception("Failed to assign travel plan to city");

            return _mapper.Map<TravelPlanResponse>(travelPlan);
        }
    }
}