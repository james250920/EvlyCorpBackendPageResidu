using System;
using System.Collections.Generic;


namespace infrastructure.DATA;

public partial class Users
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Document { get; set; } = null!;

    public string DocumentType { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public int DistrictId { get; set; }

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Condominiums> Condominiums { get; set; } = new List<Condominiums>();

    public virtual Districts District { get; set; } = null!;
}
