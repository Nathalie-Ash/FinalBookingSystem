using AutoMapper;
using FinalBookingSystem.Resources;
using IDS.Core.Models;
using IDS.Services;
using IDS.Services.Interfaces;
using IDSBookingSystem.Resources;
using Microsoft.AspNetCore.Mvc;

namespace IDSBookingSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(rooms);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            return Ok(room);
        }


        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomDto updatedRoomDto)
        {
            var existingRoom = await _roomService.GetRoomById(id);

            if (existingRoom == null)
            {
                return NotFound(); // Entity not found, return appropriate response
            }

            // Update the entity with the new data
            existingRoom.Name = updatedRoomDto.Name;
            existingRoom.Location = updatedRoomDto.Name;
            existingRoom.Capacity = updatedRoomDto.Capacity;
            existingRoom.Description = updatedRoomDto.Description;
            existingRoom.CompanyId = updatedRoomDto.CompanyId;

            // Save the changes
            await _roomService.UpdateRoom(existingRoom);

            return Ok(); // Updated successfully, return appropriate response
        }

        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPost]
         public async Task<ActionResult<Room>> PostRoom(Room newroom)
         {
             var room = await _roomService.CreateRoom(newroom);
             return Ok(room);
         }*/
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto roomDto)
        {
            // Map the DTO to the entity
            var room = new Room
            {
               // Id = roomDto.Id,
                Name = roomDto.Name,
                Location = roomDto.Location,
                Capacity = roomDto.Capacity,
                Description = roomDto.Description,
                CompanyId = roomDto.CompanyId,

            };

            await _roomService.CreateRoom(room);

            return Ok(room);
        }

        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            await _roomService.DeleteRoom(room);

            return NoContent();
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RoomResource>>> GetAllRooms()
        {
            try
            {
                var rooms = await _roomService.GetAllWithRoom();
                var roomResources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoleResource>>(rooms);

                return Ok(roomResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving room resources.");
            }
        }
    }
}
