using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("QuestionOptions")]
    public class QuestionOptionEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("description")]
        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = "";

        [Column("image")]
        [Required]
        [MaxLength(500)]
        public string Image { get; set; } = "";

        [Column("fact")]
        [Required]
        [MaxLength(300)]
        public string Fact { get; set; } = "";

        [ForeignKey("QuestionId")]
        public virtual QuestionEntity Question { get; set; } = null!;

        public virtual ICollection<AnswerEntity> Answers { get; set; } = [];
    }
}