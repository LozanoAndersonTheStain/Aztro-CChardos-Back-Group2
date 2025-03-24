using aztro_cchardos_back_group2.Application.DTOs.Requests;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IUserService {
        //* Metodos que se van a implementar en la clase UserService
        Task<UserResponse> RegisterUserAsync(UserRequest request); //* Metodo para registrar un usuario 
        Task<UserResponse> LoginUserAsync(string email, string password); //* Metodo para loguear un usuario
        Task<UserResponse> CreateUserAsync(UserRequest request); //* Metodo para crear un usuario
        Task<UserResponse> GetUserByIdAsync(int id); //* Metodo para obtener un usuario por su id
        Task<List<UserResponse>> GetAllUsersAsync(); //* Metodo para obtener todos los usuarios
        Task<UserResponse> GetUserByEmailAsync(string email); //* Metodo para obtener un usuario por su email
        Task<List<UserResponse>> GetUsersPaginatedAsync(int page, int pageSize); //* Metodo para obtener un usuario paginado
        Task<UserResponse> UpdateUserAsync(int id, UserRequest request); //* Metodo para actualizar un usuario
        Task<UserResponse> DeleteUserAsync(int id); //* Metodo para eliminar un usuario
        Task<UserResponse> LoginTestUserAsync(); //* Metodo para loguear un usuario de prueba
    }
}