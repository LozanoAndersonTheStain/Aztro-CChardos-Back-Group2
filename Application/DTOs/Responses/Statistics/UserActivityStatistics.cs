namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class UserActivityStatistics
    {
        public string UserEmail { get; set; } = "";
        public int QuestionsAnswered { get; set; }
        public DateTime LastActivity { get; set; }
        public List<string> PreferredDestinations { get; set; } = [];
    }
}