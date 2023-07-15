using System;
using System.Collections.Generic;

namespace IDS.Core.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int CompanyId { get; set; }

    public int Role { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Role RoleNavigation { get; set; } = null!;
}
