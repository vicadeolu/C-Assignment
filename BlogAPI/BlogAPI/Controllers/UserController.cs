using AutoMapper;
using BusinessLogicLayer.IServices;
using Domain.DTO.TagDTO;
using Domain.DTO.UserDTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // Get all users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }

        // Get user by ID
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // Create a new user
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateRequestUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var mappedUser = _mapper.Map<Users>(userDto);
            var createdUser = _userService.CreateUser(mappedUser, out string message);

            if (createdUser == null)
            {
                return BadRequest(message);
            }

            var createdUserDto = _mapper.Map<UserDto>(createdUser);
            return Ok(createdUserDto);
        }

        // Update user details
        [HttpPost]
        public IActionResult UpdateUser([FromBody] UpdateRequestUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var mappedUser = _mapper.Map<Users>(userDto);
            var updatedUser = _userService.UpdateUser(mappedUser, out string message);

            if (updatedUser == null)
            {
                return BadRequest(message);
            }

            var updatedUserDto = _mapper.Map<UserDto>(updatedUser);
            return Ok(updatedUserDto);
        }

        // Delete a user
        [HttpDelete]
        public IActionResult DeleteUser([FromBody] DeleteRequestDto deleteDto)
        {
            if (deleteDto == null)
            {
                return BadRequest("Invalid delete request.");
            }

            bool isDeleted = _userService.DeleteUser(deleteDto.Id, out string message);

            if (!isDeleted)
            {
                return BadRequest(message);
            }

            return Ok("User deleted successfully.");
        }
    }
}
