using IDS.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace IDSBookingSystem.Resources
{
    public class CompanyResource
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Logo { get; set; } = null!;

        public string Active { get; set; } = null!;
    }
}
