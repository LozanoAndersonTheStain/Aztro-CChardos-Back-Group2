namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class AnswerResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionOptionId { get; set; }
        public DateTime UtcDate { get; set; }
        public string LocalDate { get; set; } = "";
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}