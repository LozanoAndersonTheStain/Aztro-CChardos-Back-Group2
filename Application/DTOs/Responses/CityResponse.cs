namespace aztro_cchardos_back_group2.Application.DTOs.Responses
{
    public class CityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Country { get; set; } = "";
        public string Lenguage { get; set; } = "";
        public string UnmissablePlace { get; set; } = "";
        public string Food { get; set; } = "";
        public string Image { get; set; } = "";
        public string Continent { get; set; } = "";
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}