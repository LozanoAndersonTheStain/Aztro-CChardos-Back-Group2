using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using aztro_cchardos_back_group2.Infrastructure.Data;
using aztro_cchardos_back_group2.Application.DTOs.Responses.Statistics;
using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class ReportService(ApplicationDbContext context) : IReportService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ReportResponse> GetGeneralStatisticsAsync()
        {
            var response = new ReportResponse();
            try
            {
                var answers = await _context.Answers
                    .Include(a => a.Question)
                    .Include(a => a.QuestionOption)
                    .Include(a => a.User)
                    .Where(a => a.Question != null && a.QuestionOption != null)
                    .ToListAsync();

                response.AnswerStats = answers.Count != 0
                    ? await GetAnswerStatistics(answers)
                    : [];

                response.DestinationStats = await GetDestinationStatistics();
                response.UserStats = await GetUserStatistics();

                // Agregar información de paginación
                response.Pagination = new PaginationInfo
                {
                    CurrentPage = 1,
                    PageSize = 10,
                    TotalRecords = await _context.Answers.CountAsync(),
                    TotalPages = (int)Math.Ceiling(await _context.Answers.CountAsync() / 10.0)
                };

                response.Success = true;
                response.Message = answers.Count != 0
                    ? "Statistics generated successfully"
                    : "Statistics generated successfully (no answers found)";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating statistics: {ex.Message}";
                response.AnswerStats ??= [];
                response.UserStats ??= [];
                response.DestinationStats ??= [];
                response.Pagination = new PaginationInfo
                {
                    CurrentPage = 1,
                    PageSize = 10,
                    TotalRecords = 0,
                    TotalPages = 0
                };
            }
            return response;
        }

        public async Task<ReportResponse> GetAnswerStatisticsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var response = new ReportResponse();
            try
            {
                // Convert dates to UTC
                var utcStartDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
                var utcEndDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

                var answers = await _context.Answers
                    .Include(a => a.Question)
                    .Include(a => a.QuestionOption)
                    .Where(a => a.Date >= utcStartDate && a.Date <= utcEndDate)
                    .ToListAsync();

                response.AnswerStats = answers.Count != 0
                    ? await GetAnswerStatistics(answers)
                    : [];

                response.Success = true;
                response.Message = answers.Count != 0
                    ? "Statistics by date range generated successfully"
                    : "No answers found for the specified date range";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating statistics: {ex.Message}";
                response.AnswerStats = [];
            }
            return response;
        }

        public async Task<ReportResponse> GetDestinationStatisticsAsync()
        {
            var response = new ReportResponse();
            try
            {
                response.DestinationStats = await GetDestinationStatistics();
                response.Success = true;
                response.Message = "Destination statistics generated successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating destination statistics: {ex.Message}";
            }
            return response;
        }

        public async Task<ReportResponse> GetUserActivityStatisticsAsync()
        {
            var response = new ReportResponse();
            try
            {
                response.UserStats = await GetUserStatistics();
                response.Success = true;
                response.Message = "User activity statistics generated successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating user statistics: {ex.Message}";
            }
            return response;
        }

        public async Task<ReportResponse> GetStatisticsByQuestionCategoryAsync(string category)
        {
            var response = new ReportResponse();
            try
            {
                var answers = await _context.Answers
                    .Include(a => a.Question)
                    .Include(a => a.QuestionOption)
                    .Where(a => a.Question.Category == category)
                    .ToListAsync();

                response.AnswerStats = await GetAnswerStatistics(answers);
                response.Success = true;
                response.Message = $"Statistics for category '{category}' generated successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating category statistics: {ex.Message}";
            }
            return response;
        }

        private async Task<List<AnswerStatistics>> GetAnswerStatistics(List<AnswerEntity> answers)
        {
            var stats = new List<AnswerStatistics>();
            var groupedAnswers = answers.GroupBy(a => a.QuestionId);

            foreach (var group in groupedAnswers)
            {
                var question = await _context.Questions
                    .Include(q => q.Options)
                    .FirstOrDefaultAsync(q => q.Id == group.Key);

                if (question == null) continue;

                var optionCounts = group
                    .GroupBy(a => a.QuestionOptionId)
                    .Select(og => new OptionCount
                    {
                        OptionDescription = og.First().QuestionOption.Description,
                        Count = og.Count(),
                        Percentage = (double)og.Count() / group.Count() * 100
                    })
                    .ToList();

                stats.Add(new AnswerStatistics
                {
                    Category = question.Category,
                    QuestionText = question.QuestionText,
                    OptionCounts = optionCounts,
                    Date = group.Max(a => a.Date)
                });
            }

            return stats;
        }

        private async Task<List<DestinationStatistics>> GetDestinationStatistics()
        {
            var stats = await _context.Combinations
                .Include(c => c.FirstCity)
                .Include(c => c.SecondCity)
                .GroupBy(c => new { c.FirstCityId, c.SecondCityId })
                .Select(g => new DestinationStatistics
                {
                    FirstCityName = g.First().FirstCity.Name,
                    SecondCityName = g.First().SecondCity.Name,
                    TimesShown = g.Count(),
                    LastShownDate = DateTime.UtcNow
                })
                .ToListAsync();

            return stats;
        }

        private async Task<List<UserActivityStatistics>> GetUserStatistics()
        {
            try
            {
                var stats = await _context.Users
                    .Select(u => new UserActivityStatistics
                    {
                        UserEmail = u.Email,
                        QuestionsAnswered = u.Answers != null ? u.Answers.Count : 0,
                        LastActivity = u.Answers != null && u.Answers.Any()
                            ? u.Answers.Max(a => a.Date)
                            : DateTime.UtcNow,
                        PreferredDestinations = u.Answers != null
                            ? u.Answers
                                .Where(a => a.QuestionOption != null)
                                .Select(a => a.QuestionOption.Description)
                                .ToList()
                            : new List<string>()
                    })
                    .ToListAsync();

                return stats;
            }
            catch
            {
                return [];
            }
        }

        public async Task<ReportResponse> GetPaginatedReportAsync(int page, int pageSize)
        {
            var response = new ReportResponse();
            try
            {
                var skip = (page - 1) * pageSize;
                var answers = await _context.Answers
                    .Include(a => a.Question)
                    .Include(a => a.QuestionOption)
                    .Include(a => a.User)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToListAsync();

                response.AnswerStats = await GetAnswerStatistics(answers);
                response.DestinationStats = await GetDestinationStatistics();
                response.UserStats = await GetUserStatistics();
                response.Pagination = new PaginationInfo
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalRecords = await _context.Answers.CountAsync(),
                    TotalPages = (int)Math.Ceiling(await _context.Answers.CountAsync() / (double)pageSize)
                };
                response.Success = true;
                response.Message = "Paginated report generated successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating paginated report: {ex.Message}";
            }
            return response;
        }

        public async Task<ReportResponse> GetTrendingDestinationsAsync(int days)
        {
            var response = new ReportResponse();
            try
            {
                var combinations = await _context.Combinations
                    .Include(c => c.FirstCity)
                    .Include(c => c.SecondCity)
                    .ToListAsync();

                response.DestinationStats = [.. combinations
            .GroupBy(c => new { c.FirstCityId, c.SecondCityId })
            .Select(g => new DestinationStatistics
            {
                FirstCityName = g.First().FirstCity.Name,
                SecondCityName = g.First().SecondCity.Name,
                TimesShown = g.Count(),
                LastShownDate = DateTime.UtcNow
            })
            .OrderByDescending(s => s.TimesShown)];

                response.Success = true;
                response.Message = $"Trending destinations for the last {days} days generated successfully";

                // Add pagination info
                response.Pagination = new PaginationInfo
                {
                    CurrentPage = 1,
                    PageSize = 10,
                    TotalRecords = combinations.Count,
                    TotalPages = (int)Math.Ceiling(combinations.Count / 10.0)
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating trending destinations: {ex.Message}";
                response.DestinationStats = [];
                response.Pagination = new PaginationInfo
                {
                    CurrentPage = 1,
                    PageSize = 10,
                    TotalRecords = 0,
                    TotalPages = 0
                };
            }
            return response;
        }

        public async Task<ReportResponse> GetFilteredReportAsync(DateTime? startDate, DateTime? endDate, string? category, string? cityName)
        {
            var response = new ReportResponse();
            try
            {
                var query = _context.Answers.AsQueryable();

                if (startDate.HasValue)
                {
                    var utcStartDate = DateTime.SpecifyKind(startDate.Value, DateTimeKind.Utc);
                    query = query.Where(a => a.Date >= utcStartDate);
                }

                if (endDate.HasValue)
                {
                    var utcEndDate = DateTime.SpecifyKind(endDate.Value, DateTimeKind.Utc);
                    query = query.Where(a => a.Date <= utcEndDate);
                }

                if (!string.IsNullOrEmpty(category))
                    query = query.Where(a => a.Question.Category == category);

                var answers = await query
                    .Include(a => a.Question)
                    .Include(a => a.QuestionOption)
                    .Include(a => a.User)
                    .ToListAsync();

                // Filtrar destinos por ciudad si se especifica
                var destinationStats = await GetDestinationStatistics();
                if (!string.IsNullOrEmpty(cityName))
                {
                    destinationStats = destinationStats.Where(d =>
                        d.FirstCityName.Contains(cityName, StringComparison.OrdinalIgnoreCase) ||
                        d.SecondCityName.Contains(cityName, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                response.AnswerStats = await GetAnswerStatistics(answers);
                response.DestinationStats = destinationStats;
                response.UserStats = await GetUserStatistics();

                var totalRecords = answers.Count + destinationStats.Count;

                response.Pagination = new PaginationInfo
                {
                    CurrentPage = 1,
                    PageSize = 10,
                    TotalRecords = totalRecords,
                    TotalPages = (int)Math.Ceiling(totalRecords / 10.0)
                };

                response.Success = true;
                response.Message = totalRecords > 0
                    ? "Filtered report generated successfully"
                    : "No data found for the specified filters";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating filtered report: {ex.Message}";
                response.AnswerStats = [];
                response.DestinationStats = [];
                response.UserStats = [];
                response.Pagination = new PaginationInfo
                {
                    CurrentPage = 1,
                    PageSize = 10,
                    TotalRecords = 0,
                    TotalPages = 0
                };
            }
            return response;
        }

        public async Task<ReportResponse> GetMonthlyComparisonAsync(int month, int year)
        {
            var response = new ReportResponse();
            try
            {
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var currentMonthAnswers = await _context.Answers
                    .Include(a => a.Question)
                    .Include(a => a.QuestionOption)
                    .Where(a => a.Date >= startDate && a.Date <= endDate)
                    .ToListAsync();

                var previousMonthAnswers = await _context.Answers
                    .Include(a => a.Question)
                    .Include(a => a.QuestionOption)
                    .Where(a => a.Date >= startDate.AddMonths(-1) && a.Date < startDate)
                    .ToListAsync();

                response.AnswerStats = await GetAnswerStatistics(currentMonthAnswers);
                response.Success = true;
                response.Message = $"Monthly comparison for {startDate:MMMM yyyy} generated successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error generating monthly comparison: {ex.Message}";
            }
            return response;
        }

        public async Task<byte[]> ExportReportAsync(string format)
        {
            try
            {
                if (!format.Equals("excel", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Unsupported format. Only 'excel' is supported.");
                }

                var report = await GetGeneralStatisticsAsync();
                if (!report.Success)
                {
                    throw new Exception("Failed to generate report data");
                }

                var exportService = new ExportService();
                return exportService.ExportToExcel(report);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting report: {ex.Message}");
            }
        }
    }
}