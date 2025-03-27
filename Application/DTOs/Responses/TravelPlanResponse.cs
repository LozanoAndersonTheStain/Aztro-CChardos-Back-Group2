namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class TravelPlanResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string DestinationName { get; set; } = "";
        public string Image { get; set; } = "";
        public List<TransportOptionResponse> TransportOptions { get; set; } = [];
        public List<AccommodationOptionResponse> AccommodationOptions { get; set; } = [];
    }
}