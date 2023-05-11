using Microsoft.AspNetCore.Mvc;
using UsersDirectory.API.Dto;
using UsersDirectory.API.Services;

namespace UsersDirectory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(int id)
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            await _userService.CreateUserAsync(userDto);
            return NoContent();
        }

        [HttpPost("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserDto userDto)
        {
            await _userService.UpdateUserAsync(userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }

}
