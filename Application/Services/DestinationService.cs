using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class DestinationService(IDestinationRepository destinationRepository, IMapper mapper) : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository = destinationRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<DestinationResponse> CreateDestinationAsync(DestinationRequest request)
        {
            var destination = _mapper.Map<DestinationEntity>(request);
            var createdDestination = await _destinationRepository.CreateDestinationAsync(destination);
            var response = _mapper.Map<DestinationResponse>(createdDestination);
            response.Success = true;
            response.Message = "Destination created successfully";
            return response;
        }

        public async Task<DestinationResponse> GetDestinationByIdAsync(int id)
        {
            var destination = await _destinationRepository.GetDestinationByIdAsync(id) ?? throw new Exception("Destination not found");
            var response = _mapper.Map<DestinationResponse>(destination);
            response.Success = true;
            return response;
        }

        public async Task<List<DestinationResponse>> GetAllDestinationsAsync()
        {
            var destinations = await _destinationRepository.GetAllDestinationsAsync();
            return _mapper.Map<List<DestinationResponse>>(destinations);
        }

        public async Task<List<DestinationResponse>> GetDestinationsByFirstCityIdAsync(int cityId)
        {
            var destinations = await _destinationRepository.GetDestinationsByFirstCityIdAsync(cityId);
            return _mapper.Map<List<DestinationResponse>>(destinations);
        }

        public async Task<List<DestinationResponse>> GetDestinationsBySecondCityIdAsync(int cityId)
        {
            var destinations = await _destinationRepository.GetDestinationsBySecondCityIdAsync(cityId);
            return _mapper.Map<List<DestinationResponse>>(destinations);
        }

        public async Task<DestinationResponse> UpdateDestinationAsync(int id, DestinationRequest request)
        {
            var destination = _mapper.Map<DestinationEntity>(request);
            var updatedDestination = await _destinationRepository.UpdateDestinationAsync(id, destination);
            var response = _mapper.Map<DestinationResponse>(updatedDestination);
            response.Success = true;
            response.Message = "Destination updated successfully";
            return response;
        }

        public async Task<bool> DeleteDestinationAsync(int id)
        {
            return await _destinationRepository.DeleteDestinationAsync(id);
        }
    }
}