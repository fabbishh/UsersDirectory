using UsersDirectory.BlazorApp.Dto;

namespace UsersDirectory.BlazorApp.Data
{
    public class UsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserDto> GetUserAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/users/{id}");
            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            return user;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("api/users");
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
            return users;
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/AddUser", userDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/UpdateUser", userDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/users/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
