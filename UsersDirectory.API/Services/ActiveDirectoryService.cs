namespace UsersDirectory.API.Services
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        public Task<bool> UserExistsAsync(string adLogin)
        {
            return Task.FromResult(true);
        }
    }
}
