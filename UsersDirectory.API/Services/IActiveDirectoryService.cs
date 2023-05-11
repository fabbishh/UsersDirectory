using UsersDirectory.API.Dto;

namespace UsersDirectory.API.Services
{
    public interface IActiveDirectoryService
    {
        Task<bool> UserExistsAsync(string adLogin);
    }
}
