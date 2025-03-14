using aztro_cchardos_back_group2.Domain.Entities;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Repositories{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new Exception("User not found");
            return user;
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync() ?? throw new Exception("Users not found");
            return users;
        }

        public async Task<UserEntity?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<List<UserEntity>> GetUsersPaginatedAsync(int page, int pageSize)
        {
            var users = await _context.Users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync() ?? throw new Exception("Users not found");
            return users;
        }

        public async Task<UserEntity> UpdateUserAsync(int id, UserEntity user)
        {
            var existingUser = await _context.Users.FindAsync(id) ?? throw new Exception("User not found");
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new Exception("User not found");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}