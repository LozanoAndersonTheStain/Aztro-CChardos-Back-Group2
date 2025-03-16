using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class CityService(ICityRepository cityRepository, IMapper mapper) : ICityService
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CityResponse> CreateCityAsync(CityRequest request)
        {
            var city = _mapper.Map<CityEntity>(request);
            var createdCity = await _cityRepository.CreateCityAsync(city);
            var response = _mapper.Map<CityResponse>(createdCity);
            response.Success = true;
            response.Message = "City created successfully";
            return response;
        }

        public async Task<List<CityResponse>> CreateCitiesAsync(List<CityRequest> requests)
        {
            var cities = _mapper.Map<List<CityEntity>>(requests);
            var createdCities = await _cityRepository.CreateCitiesAsync(cities);
            var responses = _mapper.Map<List<CityResponse>>(createdCities);
            foreach (var response in responses)
            {
                response.Success = true;
                response.Message = "City created successfully";
            }
            return responses;
        }

        public async Task<CityResponse> GetCityByIdAsync(int id)
        {
            var city = await _cityRepository.GetCityByIdAsync(id) ?? throw new Exception("City not found");
            var response = _mapper.Map<CityResponse>(city);
            response.Success = true;
            return response;
        }

        public async Task<List<CityResponse>> GetAllCitiesAsync()
        {
            var cities = await _cityRepository.GetAllCitiesAsync();
            return _mapper.Map<List<CityResponse>>(cities);
        }

        public async Task<CityResponse> UpdateCityAsync(int id, CityRequest request)
        {
            var existingCity = await _cityRepository.GetCityByIdAsync(id) ?? throw new Exception($"City with ID {id} not found");

            existingCity.Name = request.Name;
            existingCity.Description = request.Description;
            existingCity.Country = request.Country;
            existingCity.Lenguage = request.Lenguage;
            existingCity.UnmissablePlace = request.UnmissablePlace;
            existingCity.Food = request.Food;
            existingCity.Image = request.Image;
            existingCity.Continent = request.Continent;

            var updatedCity = await _cityRepository.UpdateCityAsync(id, existingCity);
            return _mapper.Map<CityResponse>(updatedCity);
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            return await _cityRepository.DeleteCityAsync(id);
        }
    }
}