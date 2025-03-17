using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Domain.Interfaces;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CombinationController(ICombinationService combinationService) : ControllerBase
    {
        private readonly ICombinationService _combinationService = combinationService;

        [HttpPost("createCombination")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCombination([FromBody] CombinationRequest request)
        {
            try
            {
                var response = await _combinationService.CreateCombinationAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("createMultipleCombinations")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMultipleCombinations([FromBody] CreateCombinationsRequest request)
        {
            try
            {
                var response = await _combinationService.CreateMultipleCombinationsAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getCombinationById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCombinationById(int id)
        {
            try
            {
                var response = await _combinationService.GetCombinationByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("getAllCombinations")]
        [Authorize]
        public async Task<IActionResult> GetAllCombinations()
        {
            try
            {
                var response = await _combinationService.GetAllCombinationsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("getMatchingDestinations")]
        [Authorize]
        public async Task<IActionResult> GetMatchingDestinations([FromBody] List<int> answerIds)
        {
            try
            {
                var response = await _combinationService.GetMatchingDestinationsAsync(answerIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getDefaultDestinations")]
        [Authorize]
        public async Task<IActionResult> GetDefaultDestinations()
        {
            try
            {
                var response = await _combinationService.GetDefaultDestinationsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("updateCombination/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCombination(int id, [FromBody] CombinationRequest request)
        {
            try
            {
                var response = await _combinationService.UpdateCombinationAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("deleteCombination/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCombination(int id)
        {
            try
            {
                var result = await _combinationService.DeleteCombinationAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}