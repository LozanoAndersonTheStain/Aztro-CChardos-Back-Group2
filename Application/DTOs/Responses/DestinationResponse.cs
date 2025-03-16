namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class DestinationResponse
    {
        public CityResponse FirstCity { get; set; } = null!;
        public CityResponse SecondCity { get; set; } = null!;
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}