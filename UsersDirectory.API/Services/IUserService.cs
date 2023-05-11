using UsersDirectory.API.Dto;

namespace UsersDirectory.API.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int id);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
