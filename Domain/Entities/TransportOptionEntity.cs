using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("TransportOptions")]
    public class TransportOptionEntity
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

        [Column("image_url")]
        [Required]
        public string ImageUrl { get; set; } = "";

        [Column("url")]
        [Required]
        public string Url { get; set; } = "";

        [Column("travel_plan_id")]
        public int TravelPlanId { get; set; }

        [ForeignKey("TravelPlanId")]
        public virtual TravelPlanEntity TravelPlan { get; set; } = null!;
    }
}