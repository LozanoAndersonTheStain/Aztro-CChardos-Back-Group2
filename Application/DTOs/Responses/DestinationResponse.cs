namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class DestinationResponse
    {
        public int Id { get; set; }
        public string Combination { get; set; } = "";
        public int FirstCityId { get; set; }
        public int SecondCityId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}