using AutoMapper;
using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;
using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            var user = _mapper.Map<UserEntity>(userRequest); //* Mapea el UserRequest a UserEntity
            user.Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password); //* Encripta la contraseña
            var createdUser = await _userRepository.CreateUserAsync(user) ?? throw new Exception("User not created"); //* Crea el usuario o lanza una excepción si no se crea el usuario
            var response = _mapper.Map<UserResponse>(createdUser); //* Mapea el usuario creado a UserResponse
            response.Success = true; //* Establece la propiedad Success en true
            return response; //* Retorna el usuario creado
        }

        public async Task<UserResponse> RegisterUserAsync(UserRequest userRequest)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userRequest.Email); //* Obtiene el usuario por email
            if (existingUser != null) throw new Exception("User already exists"); //* Verifica si el usuario ya existe

            var user = _mapper.Map<UserEntity>(userRequest); //* Mapea el UserRequest a UserEntity
            user.Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password); //* Encripta la contraseña
            user.Role = "User"; //* Establece el rol del usuario

            var createdUser = await _userRepository.CreateUserAsync(user) ?? throw new Exception("User not created"); //* Crea el usuario o lanza una excepción si no se crea el usuario
            var response = _mapper.Map<UserResponse>(createdUser); //* Mapea el usuario creado a UserResponse
            response.Success = true; //* Establece la propiedad Success en true
            return response; //* Retorna el usuario creado
        }

        public async Task<UserResponse> LoginUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email) ?? throw new Exception("User not found"); //* Obtiene el usuario por email o lanza una excepción si no se encuentra el usuario
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password)) throw new Exception("Invalid password"); //* Verifica la contraseña encriptada del usuario
            var response = _mapper.Map<UserResponse>(user); //* Mapea el usuario a UserResponse
            response.Success = true; //* Establece la propiedad Success en true
            return response; //* Retorna el usuario
        }

        public async Task<UserResponse> GetUserByIdAsync(int id)
        {
            Console.WriteLine($"Searching for user with ID: {id}"); //* Imprime el ID del usuario

            var user = await _userRepository.GetUserByIdAsync(id); //* Obtiene el usuario por ID

            if (user == null) //* Verifica si el usuario no existe
            {
                Console.WriteLine("User not found in database"); //* Imprime que el usuario no se encuentra en la base de datos
                throw new Exception("User not found"); //* Lanza una excepción
            }

            Console.WriteLine($"User found: {user.Name} (ID: {user.Id})"); //* Imprime el nombre y el ID del usuario
            return _mapper.Map<UserResponse>(user); //* Mapea el usuario a UserResponse
        }

        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync() ?? throw new Exception("Users not found"); //* Obtiene todos los usuarios o lanza una excepción si no se encuentran usuarios
            return _mapper.Map<List<UserResponse>>(users); //* Mapea los usuarios a UserResponse
        }

        public async Task<UserResponse> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email) ?? throw new Exception("User by email not found"); //* Obtiene el usuraio por email o lanza una excepción si no se encuentra usuario
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<List<UserResponse>> GetUsersPaginatedAsync(int page, int pageSize)
        {
            try
            {
                var users = await _userRepository.GetUsersPaginatedAsync(page, pageSize); //* Obtiene los usuarios paginados
                return _mapper.Map<List<UserResponse>>(users); //* Mapea los usuarios a UserResponse
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in pagination: {ex.Message}"); //* Imprime el error
                throw;
            }
        }

        public async Task<UserResponse> UpdateUserAsync(int id, UserRequest userRequest)
        {
            var user = _mapper.Map<UserEntity>(userRequest); //* Mapea el UserRequest a UserEntity
            user.Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password); //* Encripta la contraseña
            var updatedUser = await _userRepository.UpdateUserAsync(id, user) ?? throw new Exception("User not updated"); //* Actualiza el usuario o lanza una excepción si no se actualiza el usuario
            var response = _mapper.Map<UserResponse>(updatedUser); //* Mapea el usuario actualizado a UserResponse
            response.Success = true; //* Establece la propiedad Success en true
            return response; //* Retorna el usuario actualizado
        }

        public async Task<UserResponse> DeleteUserAsync(int id)
        {
            var deleted = await _userRepository.DeleteUserAsync(id); //* Elimina el usuario
            if (!deleted)
            {
                throw new Exception("User not deleted"); //* Lanza una excepción si no se elimina el usuario
            }
            return new UserResponse { Success = true }; //* Retorna true si se elimina el usuario
        }

        public async Task<UserResponse> LoginTestUserAsync()
        {
            const string testEmail = "test@user.com";
            const string testPassword = "test123";

            var existingUser = await _userRepository.GetUserByEmailAsync(testEmail); //* Obtiene el usuario por email

            if (existingUser == null)
            {
                //* Si el usuario no existe, crea uno de prueba
                var testUser = new UserEntity
                {
                    Name = "Test User",
                    Email = testEmail,
                    Password = BCrypt.Net.BCrypt.HashPassword(testPassword),
                    Role = "TestUser"
                };
                existingUser = await _userRepository.CreateUserAsync(testUser); // * Crea el usuario
            }
            // * Loguea el usuario de prueba
            var response = _mapper.Map<UserResponse>(existingUser);
            response.Success = true;
            response.Message = "Test user logged in successfully";
            return response;
        }
    }
}
