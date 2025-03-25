namespace aztro_cchardos_back_group2.Application.DTOs.Requests
{
    public class UserRequest
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string AvatarUrl { get; set; } = "";
        public string Role { get; set; } = "";
    }
}