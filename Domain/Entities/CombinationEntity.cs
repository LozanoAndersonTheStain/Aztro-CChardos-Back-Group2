using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("Combinations")]
    public class CombinationEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("destination_option_id")]
        public int DestinationOptionId { get; set; }

        [Column("climate_option_id")]
        public int ClimateOptionId { get; set; }

        [Column("activity_option_id")]
        public int ActivityOptionId { get; set; }

        [Column("accommodation_option_id")]
        public int AccommodationOptionId { get; set; }

        [Column("duration_option_id")]
        public int DurationOptionId { get; set; }

        [Column("age_option_id")]
        public int AgeOptionId { get; set; }

        [Column("first_city_id")]
        public int FirstCityId { get; set; }

        [Column("second_city_id")]
        public int SecondCityId { get; set; }

        public virtual CityEntity FirstCity { get; set; } = null!;
        public virtual CityEntity SecondCity { get; set; } = null!;
        public virtual QuestionOptionEntity DestinationOption { get; set; } = null!;
        public virtual QuestionOptionEntity ClimateOption { get; set; } = null!;
        public virtual QuestionOptionEntity ActivityOption { get; set; } = null!;
        public virtual QuestionOptionEntity AccommodationOption { get; set; } = null!;
        public virtual QuestionOptionEntity DurationOption { get; set; } = null!;
        public virtual QuestionOptionEntity AgeOption { get; set; } = null!;
    }
}