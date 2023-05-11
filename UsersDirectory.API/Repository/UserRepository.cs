using Microsoft.EntityFrameworkCore;
using UsersDirectory.API.Entities;

namespace UsersDirectory.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(User user)
        {
            await DbSet().AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            DbSet().Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await DbSet()
                            .Where(u => !u.IsDeleted && u.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await DbSet()
                            .Where(u => !u.IsDeleted)
                            .ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            DbSet().Update(user);
            await _context.SaveChangesAsync();
        }

        private DbSet<User> DbSet()
        {
            return _context.Users;
        }
    }
}
