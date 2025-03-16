using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController(IQuestionService questionService) : ControllerBase
    {
        private readonly IQuestionService _questionService = questionService;

        [HttpPost("createQuestion")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionRequest request)
        {
            try
            {
                var response = await _questionService.CreateQuestionAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("createMultipleQuestions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMultipleQuestions([FromBody] List<QuestionRequest> requests)
        {
            try
            {
                var response = await _questionService.CreateMultipleQuestionsAsync(requests);
                return Ok(response);
            } 
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getQuestionById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            try
            {
                var response = await _questionService.GetQuestionByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpGet("getAllQuestions")]
        [Authorize]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var response = await _questionService.GetAllQuestionsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getQuestionsByPaginated")]
        [Authorize]
        public async Task<IActionResult> GetQuestionsPaginated([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var response = await _questionService.GetQuestionsPaginatedAsync(page, pageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("updateQuestionById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionRequest request)
        {
            try
            {
                var response = await _questionService.UpdateQuestionAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("deleteQuestionById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                var result = await _questionService.DeleteQuestionAsync(id);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}