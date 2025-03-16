namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class AnswerRequest
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionOptionId { get; set; }
    }
}