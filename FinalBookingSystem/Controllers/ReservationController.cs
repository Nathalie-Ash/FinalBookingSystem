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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservations = await _reservationService.GetAllReservations();
            return Ok(reservations);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            return Ok(reservation);
        }



        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] ReservationDto updatedReservationDto)
        {
            var existingReservation = await _reservationService.GetReservationById(id);

            if (existingReservation == null)
            {
                return NotFound(); // Entity not found, return appropriate response
            }

            // Update the entity with the new data
            existingReservation.DateOfMeeting = updatedReservationDto.DateOfMeeting;
            existingReservation.StartTime = updatedReservationDto.StartTime;
            existingReservation.EndTime = updatedReservationDto.EndTime;
            existingReservation.RoomId = updatedReservationDto.RoomId;
            existingReservation.Attendees = updatedReservationDto.Attendees;
            existingReservation.Status = updatedReservationDto.Status;
            // Save the changes
            await _reservationService.UpdateReservation(existingReservation);

            return Ok(); // Updated successfully, return appropriate response
        }
        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPost]
         public async Task<ActionResult<Reservation>> PostReservation(Reservation newreservation)
         {
             var reservation = await _reservationService.CreateReservation(newreservation);
             return Ok(reservation);
         }*/

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationDto reservationDto)
        {
            // Map the DTO to the entity
            var reservation = new Reservation
            {
               // Id = reservationDto.Id,
                DateOfMeeting = reservationDto.DateOfMeeting,
                StartTime = reservationDto.StartTime,
                EndTime = reservationDto.EndTime,
                RoomId = reservationDto.RoomId,
                Attendees = reservationDto.Attendees,
                Status = reservationDto.Status
            };

            await _reservationService.CreateReservation(reservation);

            return Ok(reservation);
        }


        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await _reservationService.DeleteReservation(reservation);

            return NoContent();
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ReservationResource>>> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllWithReservation();
                var reservationResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResource>>(reservations);

                return Ok(reservationResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving music resources.");
            }
        }

    }
}
