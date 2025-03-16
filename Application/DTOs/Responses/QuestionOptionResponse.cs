namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class QuestionOptionResponse
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}