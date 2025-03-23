using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("Travel Plans")]
    public class TravelPlanEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = "";

        [Column("description")]
        [Required]
        public string Description { get; set; } = "";

        [Column("destination_name")]
        [Required]
        public string DestinationName { get; set; } = "";

        [Column("image")]
        [Required]
        public string Image { get; set; } = "";

        public virtual ICollection<TransportOptionEntity> FlightOptions { get; set; } = [];
        public virtual ICollection<AccommodationOptionEntity> HotelOptions { get; set; } = [];
    }
}