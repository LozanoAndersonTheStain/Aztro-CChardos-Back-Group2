namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = "";
        public List<QuestionOptionResponse> Options { get; set; } = [];
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}