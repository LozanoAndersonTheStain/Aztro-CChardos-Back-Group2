using System.ComponentModel.DataAnnotations;

namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class QuestionOptionRequest
    {
        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = "";

        [Required]
        [MaxLength(500)]
        public string Image { get; set; } = "";
    }
}