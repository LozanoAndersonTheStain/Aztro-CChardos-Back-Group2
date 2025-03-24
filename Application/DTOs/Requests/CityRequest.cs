using System.ComponentModel.DataAnnotations;

namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class CityRequest
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        [Required]
        public string Country { get; set; } = "";

        [Required]
        public string Lenguage { get; set; } = "";

        [Required]
        public string UnmissablePlace { get; set; } = "";

        [Required]
        public string Food { get; set; } = "";

        [Required]
        public string Image { get; set; } = "";

        [Required]
        public string Continent { get; set; } = "";

        public int? TravelPlanId { get; set; }
    }
}