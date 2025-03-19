namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class QuestionRequest
    {
        public string Category { get; set; } = "";
        public string QuestionText { get; set; } = "";
        public string SupplementaryText { get; set; } = "";
        public List<QuestionOptionRequest> Options { get; set; } = [];
    }
}