using System;
using System.Collections.Generic;

namespace IDS.Core.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public DateTime DateOfMeeting { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int RoomId { get; set; }

    public int Attendees { get; set; }

    public string Status { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
