using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aztro_cchardos_back_group2.Domain.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [Column("email")]
        [Required, EmailAddress(ErrorMessage = "Email is invalid"), StringLength(50, MinimumLength = 3, ErrorMessage = "Email is required")]
        public string Email { get; set; } = "";

        [Column("password")]
        [Required, StringLength(80, MinimumLength = 3, ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        [Column("avatar_url")]
        public string AvatarUrl { get; set; } = "";

        [Column("role")]
        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "Role is required")]
        public string Role { get; set; } = "";

        public virtual ICollection<AnswerEntity> Answers { get; set; } = [];
    }
}