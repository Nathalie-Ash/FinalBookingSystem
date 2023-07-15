namespace IDSBookingSystem.Resources
{
    public class RoomResource
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public int Capacity { get; set; }

        public string Description { get; set; } = null!;

        public int CompanyId { get; set; }

    }
}
