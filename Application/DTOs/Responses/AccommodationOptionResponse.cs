namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class AccommodationOptionResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string Url { get; set; } = "";
    }
}