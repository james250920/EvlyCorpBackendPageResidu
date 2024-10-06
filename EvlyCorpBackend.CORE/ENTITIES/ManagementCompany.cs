using System;
using System.Collections.Generic;


namespace infrastructure.DATA;

public partial class ManagementCompany
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? TaxAddress { get; set; }

    public string? WebsiteUrl { get; set; }

    public string Ruc { get; set; } = null!;

    public string? LogoUrl { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
