using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("Destinations")]
    public class DestinationEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("combination")]
        [Required]
        public string Combination { get; set; } = "";

        [Column("first_city_id")]
        public int FirstCityId { get; set; }

        [Column("second_city_id")]
        public int SecondCityId { get; set; }
        public int? TravelPlanId { get; set; }

        [ForeignKey("FirstCityId")]
        public virtual CityEntity FirstCity { get; set; } = null!;

        [ForeignKey("SecondCityId")]
        public virtual CityEntity SecondCity { get; set; } = null!;

        [ForeignKey(nameof(TravelPlanId))]
        public TravelPlanEntity? TravelPlan { get; set; }
    }
}