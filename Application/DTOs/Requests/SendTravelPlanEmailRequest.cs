namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class SendTravelPlanEmailRequest
    {
        public string UserEmail { get; set; } = string.Empty;
        public string HtmlContent { get; set; } = string.Empty;
    }
}