using System;
using System.Collections.Generic;

namespace ProfilesService;

public partial class Customer
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public string? State { get; set; }

    public int? HotelsId { get; set; }
}
