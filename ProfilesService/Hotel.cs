using System;
using System.Collections.Generic;

namespace ProfilesService;

public partial class Hotel
{
    public int Id { get; set; }

    public int? OwnersId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }
}
