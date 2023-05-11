using UsersDirectory.API.Entities;

namespace UsersDirectory.API.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task DeleteUserAsync(User user);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
