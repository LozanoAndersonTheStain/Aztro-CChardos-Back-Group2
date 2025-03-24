using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController(IAnswerService answerService, ICombinationService combinationService) : ControllerBase
    {
        private readonly IAnswerService _answerService = answerService;
        private readonly ICombinationService _combinationService = combinationService;

        [HttpPost("createAnswer")]
        [Authorize(Roles = "Admin, User, TestUser")]
        public async Task<IActionResult> CreateAnswer([FromBody] AnswerRequest request)
        {
            try
            {
                var response = await _answerService.CreateAnswerAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getAnswerById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            try
            {
                var response = await _answerService.GetAnswerByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("getUserAnswerId/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAnswersByUserId(int userId)
        {
            try
            {
                var response = await _answerService.GetAnswersByUserIdAsync(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getAnswerByQuestion/{questionId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAnswersByQuestionId(int questionId)
        {
            try
            {
                var response = await _answerService.GetAnswersByQuestionIdAsync(questionId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("getMatchingDestinations")]
        [Authorize(Roles = "Admin, User, TestUser")]
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

        [HttpDelete("deleteAnswer/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            try
            {
                var result = await _answerService.DeleteAnswerAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}