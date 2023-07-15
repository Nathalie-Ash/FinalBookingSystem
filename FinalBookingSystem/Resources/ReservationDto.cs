using IDS.Core.Models;

namespace FinalBookingSystem.Resources
{
    public class ReservationDto
    {

     //   public int Id { get; set; }

        public DateTime DateOfMeeting { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int RoomId { get; set; }

        public int Attendees { get; set; }

        public string Status { get; set; } 

       
    }
}
