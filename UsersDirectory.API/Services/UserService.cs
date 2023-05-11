using AutoMapper;
using UsersDirectory.API.Dto;
using UsersDirectory.API.Entities;
using UsersDirectory.API.Repository;

namespace UsersDirectory.API.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IActiveDirectoryService _activeDirectoryService;

        public UserService(IUserRepository userRepository, IActiveDirectoryService activeDirectoryService, IMapper mapper)
        {
            _userRepository = userRepository;
            _activeDirectoryService = activeDirectoryService;
            _mapper = mapper;
        }
        public async Task CreateUserAsync(UserDto userDto)
        {
            if (!await _activeDirectoryService.UserExistsAsync(userDto.AdLogin))
            {
                throw new Exception($"User with Active Directory login {userDto.AdLogin} does not exist.");
            }

            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);

            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }

            await _userRepository.DeleteUserAsync(user);
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            if (!await _activeDirectoryService.UserExistsAsync(userDto.AdLogin))
            {
                throw new Exception($"User with Active Directory login {userDto.AdLogin} does not exist.");
            }

            var user = await _userRepository.GetUserAsync(userDto.Id);

            if (user == null)
            {
                throw new Exception($"User with ID {userDto.Id} not found.");
            }

            _mapper.Map(userDto, user);
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
