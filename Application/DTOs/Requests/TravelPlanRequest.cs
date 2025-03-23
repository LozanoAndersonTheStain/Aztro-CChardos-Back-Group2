namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class TravelPlanRequest
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string DestinationName { get; set; } = "";
        public string Image { get; set; } = "";
        public List<TransportOptionRequest> TransportOptions { get; set; } = [];
        public List<AccommodationOptionRequest> AccommodationOptions { get; set; } = [];
    }
}