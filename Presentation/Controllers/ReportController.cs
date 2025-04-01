using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Domain.Enums;
using aztro_cchardos_back_group2.Infrastructure.Auth;
using aztro_cchardos_back_group2.Application.Services;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReportController(IReportService reportService) : ControllerBase
    {
        private readonly IReportService _reportService = reportService;

        [HttpGet("general")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetGeneralStatistics()
        {
            var result = await _reportService.GetGeneralStatisticsAsync();
            return Ok(result);
        }

        [HttpGet("by-date-range")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetAnswerStatisticsByDateRange(
    [FromQuery] DateTime startDate,
    [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("Start date must be before or equal to end date");
            }

            var result = await _reportService.GetAnswerStatisticsByDateRangeAsync(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("destinations")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetDestinationStatistics()
        {
            var result = await _reportService.GetDestinationStatisticsAsync();
            return Ok(result);
        }

        [HttpGet("user-activity")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetUserActivityStatistics()
        {
            var result = await _reportService.GetUserActivityStatisticsAsync();
            return Ok(result);
        }

        [HttpGet("by-category/{category}")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetStatisticsByCategory(string category)
        {
            var result = await _reportService.GetStatisticsByQuestionCategoryAsync(category);
            return Ok(result);
        }

        [HttpGet("paginated")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetPaginatedReport([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _reportService.GetPaginatedReportAsync(page, pageSize);
            return Ok(result);
        }

        [HttpGet("trending")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetTrendingDestinations([FromQuery] int days = 30)
        {
            var result = await _reportService.GetTrendingDestinationsAsync(days);
            return Ok(result);
        }

        [HttpGet("filtered")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetFilteredReport(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] string? category,
            [FromQuery] string? cityName)
        {
            var result = await _reportService.GetFilteredReportAsync(startDate, endDate, category, cityName);
            return Ok(result);
        }

        [HttpGet("monthly-comparison")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> GetMonthlyComparison(
            [FromQuery] int month,
            [FromQuery] int year)
        {
            var result = await _reportService.GetMonthlyComparisonAsync(month, year);
            return Ok(result);
        }

        [HttpGet("export")]
        [AuthorizeRoles(RoleUser.Admin)]
        public async Task<IActionResult> ExportReport([FromQuery] string format = "excel")
        {
            var report = await _reportService.GetGeneralStatisticsAsync();

            if (format.Equals("excel", StringComparison.CurrentCultureIgnoreCase))
            {
                var exportService = new ExportService();
                var fileContents = exportService.ExportToExcel(report);
                return File(
                    fileContents,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "report.xlsx"
                );
            }

            return BadRequest("Unsupported format");
        }
    }
}