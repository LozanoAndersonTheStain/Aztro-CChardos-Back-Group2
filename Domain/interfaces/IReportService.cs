using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IReportService
    {
        Task<ReportResponse> GetGeneralStatisticsAsync();
        Task<ReportResponse> GetAnswerStatisticsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ReportResponse> GetDestinationStatisticsAsync();
        Task<ReportResponse> GetUserActivityStatisticsAsync();
        Task<ReportResponse> GetStatisticsByQuestionCategoryAsync(string category);
        Task<ReportResponse> GetPaginatedReportAsync(int page, int pageSize);
        Task<ReportResponse> GetTrendingDestinationsAsync(int days);
        Task<ReportResponse> GetFilteredReportAsync(DateTime? startDate, DateTime? endDate, string? category, string? cityName);
        Task<ReportResponse> GetMonthlyComparisonAsync(int month, int year);
    }
}