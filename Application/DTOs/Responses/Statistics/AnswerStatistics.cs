namespace aztro_cchardos_back_group2.Application.DTOs.Responses.Statistics
{
    public class AnswerStatistics
    {
        public string Category { get; set; } = "";
        public string QuestionText { get; set; } = "";
        public List<OptionCount> OptionCounts { get; set; } = [];
        public DateTime Date { get; set; }
    }
}