using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("Answers")]
    public class AnswerEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("question_option_id")]
        public int QuestionOptionId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; } = null!;

        [ForeignKey("QuestionId")]
        public virtual QuestionEntity Question { get; set; } = null!;

        [ForeignKey("QuestionOptionId")]
        public virtual QuestionOptionEntity QuestionOption { get; set; } = null!;
    }
}