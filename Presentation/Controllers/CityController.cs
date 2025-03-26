using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController(ICityService cityService) : ControllerBase
    {
        private readonly ICityService _cityService = cityService;

        [HttpPost("createCity")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCity([FromBody] CityRequest request)
        {
            try
            {
                var response = await _cityService.CreateCityAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("createCities")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCities([FromBody] List<CityRequest> requests)
        {
            try
            {
                var responses = new List<object>();
                foreach (var request in requests)
                {
                    var response = await _cityService.CreateCityAsync(request);
                    responses.Add(response);
                }
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getCityById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCityById(int id)
        {
            try
            {
                var response = await _cityService.GetCityByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("getAllCities")]
        [Authorize(Roles = "Admin, User, TestUser")]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var response = await _cityService.GetAllCitiesAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("updateCityById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] CityRequest request)
        {
            try
            {
                var response = await _cityService.UpdateCityAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("deleteCityById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                var result = await _cityService.DeleteCityAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}