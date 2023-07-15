namespace IDSBookingSystem.Resources
{
    public class ReservationResource
    {
        public int Id { get; set; }

        public DateTime DateOfMeeting { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int RoomId { get; set; }

        public int Attendees { get; set; }

        public string Status { get; set; } = null!;

    }
}
