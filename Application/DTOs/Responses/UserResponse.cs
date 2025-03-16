namespace aztro_cchardos_back_group2.Application.DTOs.Responses 
{
    public class UserResponse
    {   
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
        public bool Success { get; internal set; }
        public string Message { get; set; } = "";
        public string Token { get; set; } = "";
    }
}