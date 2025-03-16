using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController(IDestinationService destinationService) : ControllerBase
    {
        private readonly IDestinationService _destinationService = destinationService;

        [HttpPost("createDestinations")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDestination([FromBody] DestinationRequest request)
        {
            try
            {
                var response = await _destinationService.CreateDestinationAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getDestinationsById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetDestinationById(int id)
        {
            try
            {
                var response = await _destinationService.GetDestinationByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("getAllDestinations")]
        [Authorize]
        public async Task<IActionResult> GetAllDestinations()
        {
            try
            {
                var response = await _destinationService.GetAllDestinationsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getFirstCityById/{cityId}")]
        [Authorize]
        public async Task<IActionResult> GetDestinationsByFirstCityId(int cityId)
        {
            try
            {
                var response = await _destinationService.GetDestinationsByFirstCityIdAsync(cityId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getSecondCityById/{cityId}")]
        [Authorize]
        public async Task<IActionResult> GetDestinationsBySecondCityId(int cityId)
        {
            try
            {
                var response = await _destinationService.GetDestinationsBySecondCityIdAsync(cityId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("updateDestinationById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDestination(int id, [FromBody] DestinationRequest request)
        {
            try
            {
                var response = await _destinationService.UpdateDestinationAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("deleteDestinationById{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            try
            {
                var result = await _destinationService.DeleteDestinationAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}