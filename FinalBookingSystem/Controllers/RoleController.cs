using AutoMapper;
using FinalBookingSystem.Resources;
using IDS.Core.Models;
using IDS.Services;
using IDS.Services.Interfaces;
using IDSBookingSystem.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IDSBookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(roles);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleById(id);
            return Ok(role);
        }


        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDto updatedRoleDto)
        {
            var existingRole = await _roleService.GetRoleById(id);

            if (existingRole == null)
            {
                return NotFound(); // Entity not found, return appropriate response
            }

            // Update the entity with the new data
            existingRole.RoleName = updatedRoleDto.RoleName;
       
            // Save the changes
            await _roleService.UpdateRole(existingRole);

            return Ok(); // Updated successfully, return appropriate response
        }

        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*   [HttpPost]
           public async Task<ActionResult<Role>> PostRole(Role newrole)
           {
               var role = await _roleService.CreateRole(newrole);
               return Ok(role);
           }*/
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto)
        {
            // Map the DTO to the entity
            var role = new Role
            {
               // Id = roleDto.Id,
                RoleName = roleDto.RoleName,
               
            };

            await _roleService.CreateRole(role);

            return Ok(role);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRlem(int id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound(); // Room not found, return appropriate response
            }

            await _roleService.DeleteRole(role);

            return NoContent(); // Deleted successfully, return appropriate response
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RoleResource>>> GetAllRoles()
        {
            try
            {
                var roles = await _roleService.GetAllWithRole();
                var roleResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<RoleResource>>(roles);

                return Ok(roleResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving music resources.");
            }
        }

    }
}
