using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionOptionController(IQuestionOptionService optionService) : ControllerBase
    {
        private readonly IQuestionOptionService _optionService = optionService;
        
        [HttpPost("createOption/{questionId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateOption(int questionId, [FromBody] QuestionOptionRequest request)
        {
            try
            {
                var response = await _optionService.CreateOptionAsync(questionId, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getOptionById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOptionById(int id)
        {
            try
            {
                var response = await _optionService.GetOptionByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("getQuestionOptionById/{questionId}")]
        [Authorize]
        public async Task<IActionResult> GetOptionsByQuestionId(int questionId)
        {
            try
            {
                var response = await _optionService.GetOptionsByQuestionIdAsync(questionId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("updateOptionById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOption(int id, [FromBody] QuestionOptionRequest request)
        {
            try
            {
                var response = await _optionService.UpdateOptionAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("deleteOptionById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            try
            {
                var result = await _optionService.DeleteOptionAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}