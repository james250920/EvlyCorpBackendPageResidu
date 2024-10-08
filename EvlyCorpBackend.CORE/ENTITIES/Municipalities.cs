using System;
using System.Collections.Generic;


namespace infrastructure.DATA;

public partial class Municipalities
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? LogoUrl { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Condominiums> Condominiums { get; set; } = new List<Condominiums>();
}
