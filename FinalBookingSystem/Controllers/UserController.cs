
using AutoMapper;
using FinalBookingSystem.Resources;
using IDS.Core.Models;
using IDS.Services;
using IDS.Services.Interfaces;
using IDSBookingSystem.Resources;
using Microsoft.AspNetCore.Mvc;

namespace IdsbookingSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
     
        private readonly IMapper _mapper;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            // Map the DTO to the entity
            var user = new User
            {
                // Id = reservationDto.Id,
                Name = userDto.Name,
                Dob = userDto.Dob,
                Gender = userDto.Gender,
                Email = userDto.Email,
                Password = userDto.Password,
                CompanyId = userDto.CompanyId,
                Role = userDto.Role

            };

            await _userService.CreateUser(user);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto updatedUserDto)
        {
            var existingUser = await _userService.GetUserById(id);

            if (existingUser == null)
            {
                return NotFound(); // Entity not found, return appropriate response
            }

            // Update the entity with the new data
            existingUser.Name = updatedUserDto.Name;
            existingUser.Dob = updatedUserDto.Dob;
            existingUser.Gender = updatedUserDto.Gender;
            existingUser.Email = updatedUserDto.Email;
            existingUser.Password = updatedUserDto.Password;
            existingUser.CompanyId = updatedUserDto.CompanyId;
            existingUser.Role = updatedUserDto.Role;

            // Save the changes
            await _userService.UpdateUser(existingUser);

            return Ok(); // Updated successfully, return appropriate response
        }

        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(user);

            return NoContent();
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllWithUser();
                var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<RoleResource>>(users);

                return Ok(userResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving music resources.");
            }
        }

    }
}
