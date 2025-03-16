using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("Cities")]
    public class CityEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = "";

        [Column("description")]
        [Required]
        public string Description { get; set; } = "";

        [Column("Country")]
        [Required]
        public string Country { get; set; } = "";

        [Column("lenguage")]
        [Required]
        public string Lenguage { get; set; } = "";

        [Column("unmissable_place")]
        [Required]
        public string UnmissablePlace { get; set; } = "";

        [Column("food")]
        [Required]
        public string Food { get; set; } = "";

        [Column("image")]
        [Required]
        public string Image { get; set; } = "";

        [Column("continent")]
        [Required]
        public string Continent { get; set; } = "";

        public virtual ICollection<DestinationEntity> FirstCityDestinations { get; set; } = [];
        public virtual ICollection<DestinationEntity> SecondCityDestinations { get; set; } = [];
    }
}