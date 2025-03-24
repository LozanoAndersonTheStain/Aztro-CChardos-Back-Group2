using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.Services;
using aztro_cchardos_back_group2.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aztro_cchardos_back_group2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService, TokenService tokenService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly TokenService _tokenService = tokenService;

        // * Controlador Para Registrar Usuarios
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRequest userRequest)
        {
            try
            {
                var response = await _userService.RegisterUserAsync(userRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // * Controlador Para Iniciar Sesion
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUserAsync([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                var userResponse = await _userService.LoginUserAsync(email, password);
                var token = _tokenService.GenerateToken(userResponse.Email, userResponse.Role);
                userResponse.Token = token;
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        // * Controlador Para Crear Usuarios
        [HttpPost("createUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest)
        {
            var response = await _userService.CreateUserAsync(userRequest);
            return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
        }

        //* Controlador Para Obtener Usuarios Por Id
        [HttpGet("GetUserById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound(new { message = "User not found" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // * Controlador Para Obtener Todos Los Usuarios
        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();
            return Ok(response);
        }

        // * Controlador Para Obtener Usuarios Por Email
        [HttpGet("GetUserByEmail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
        {
            var response = await _userService.GetUserByEmailAsync(email);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // * Controlador Para Obtener Usuarios Paginados
        [HttpGet("paginated")]
        [Authorize]
        public async Task<IActionResult> GetUsersPaginatedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var users = await _userService.GetUsersPaginatedAsync(page, pageSize);
                return Ok(users);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // * Controlador Para Actualizar Usuarios
        [HttpPut("updateUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequest userRequest)
        {
            var response = await _userService.UpdateUserAsync(id, userRequest);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // * Controlador Para Eliminar Usuarios
        [HttpDelete("deleteUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUserAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // * Controlador Para Loguear Usuario De Prueba
        [HttpPost("login-test")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginTestUser()
        {
            try
            {
                var userResponse = await _userService.LoginTestUserAsync();
                var token = _tokenService.GenerateToken(userResponse.Email, userResponse.Role);
                userResponse.Token = token;
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}