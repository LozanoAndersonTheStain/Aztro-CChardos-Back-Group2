using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("Questions")]
    public class QuestionEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("category")]
        [Required]
        public string Category { get; set; } = "";

        [Column("question_text")]
        [Required]
        public string QuestionText { get; set;} = "";
        
        [Column("supplementaryText")]
        [Required]
        public string SupplementaryText { get; set; } = "";

        public virtual ICollection<QuestionOptionEntity> Options { get; set; } = [];
        public virtual ICollection<AnswerEntity> Answers { get; set; } = [];
    }
}