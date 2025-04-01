namespace aztro_cchardos_back_group2.Application.DTOs.Responses.Statistics
{
    public class TrendingStatistics
    {
        public string Category { get; set; } = "";
        public int TotalResponses { get; set; }
        public double GrowthRate { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}