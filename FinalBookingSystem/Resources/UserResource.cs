namespace IDSBookingSystem.Resources
{
    public class UserResource
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Dob { get; set; }

        public string Gender { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int CompanyId { get; set; }

        public int Role { get; set; }
    }
}
