using aztro_cchardos_back_group2.Application.DTOs.Responses.Statistics;

namespace aztro_cchardos_back_group2.Application.DTOs.Responses 
{
    public class ReportResponse
    {
        public List<AnswerStatistics> AnswerStats { get; set; } = [];
        public List<DestinationStatistics> DestinationStats { get; set; } = [];
        public List<UserActivityStatistics> UserStats { get; set; } = [];
        public PaginationInfo Pagination { get; set; } = new();
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}