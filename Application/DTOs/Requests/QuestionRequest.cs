namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class QuestionRequest
    {
        public string QuestionText { get; set; } = "";
        public List<QuestionOptionRequest> Options { get; set; } = [];
    }
}