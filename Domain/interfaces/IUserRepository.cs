using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    //* Interfaz para el repositorio de usuarios
    public interface IUserRepository {
        //* Metodo para crear un usuario
        Task<UserEntity> CreateUserAsync(UserEntity user);

        //* Metodo para obtener un usuario por id
        Task<UserEntity?> GetUserByIdAsync(int id);

        //* Metodo para obtener todos los usuarios
        Task<List<UserEntity>> GetAllUsersAsync();

        //* Metodo para obtener un usuario por email
        Task<UserEntity?> GetUserByEmailAsync(string email);

        //* Metodo para obtener los usuarios paginados
        Task<List<UserEntity>> GetUsersPaginatedAsync(int page, int pageSize);

        //* Metodo para actualizar un usuario
        Task<UserEntity> UpdateUserAsync(int id, UserEntity user);

        //* Metodo para eliminar un usuario
        Task<bool> DeleteUserAsync(int id);
    }
}