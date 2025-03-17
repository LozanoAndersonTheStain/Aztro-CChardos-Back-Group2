using System.ComponentModel.DataAnnotations;

namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class CombinationRequest
    {
        [Required]
        public int DestinationOptionId { get; set; }

        [Required]
        public int ClimateOptionId { get; set; }

        [Required]
        public int ActivityOptionId { get; set; }

        [Required]
        public int AccommodationOptionId { get; set; }

        [Required]
        public int DurationOptionId { get; set; }

        [Required]
        public int AgeOptionId { get; set; }

        [Required]
        public int FirstCityId { get; set; }

        [Required]
        public int SecondCityId { get; set; }
    }
}