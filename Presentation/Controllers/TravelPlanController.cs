using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelPlanController(ITravelPlanService travelPlanService) : ControllerBase
    {
        private readonly ITravelPlanService _travelPlanService = travelPlanService;


        [HttpPost("createTravelPlan")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTravelPlan([FromBody] TravelPlanRequest travelPlan)
        {
            try
            {
                var response = await _travelPlanService.CreateTravelPlanAsync(travelPlan);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("createTravelPlans")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTravelPlans([FromBody] List<TravelPlanRequest> travelPlans)
        {
            try
            {
                var responses = await _travelPlanService.CreateTravelPlansAsync(travelPlans);
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getTravelPlanByDestinationName/{destinationName}")]
        [Authorize]
        public async Task<IActionResult> GetTravelPlanByDestinationName(string destinationName)
        {
            try
            {
                var response = await _travelPlanService.GetTravelPlanByDestinationNameAsync(destinationName);
                if (response == null)
                    return NotFound(new { message = $"Travel plan for destination '{destinationName}' not found" });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getAllTravelPlans")]
        [Authorize]
        public async Task<IActionResult> GetAllTravelPlans()
        {
            try
            {
                var response = await _travelPlanService.GetAllTravelPlansAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("updateTravelPlan/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTravelPlan(int id, [FromBody] TravelPlanRequest travelPlan)
        {
            try
            {
                var response = await _travelPlanService.UpdateTravelPlanAsync(id, travelPlan);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("deleteTravelPlan/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTravelPlan(int id)
        {
            try
            {
                var result = await _travelPlanService.DeleteTravelPlanAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("assignToCity/{travelPlanId}/{cityId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignToCity(int travelPlanId, int cityId)
        {
            try
            {
                var response = await _travelPlanService.AssignToCityAsync(travelPlanId, cityId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}