using System;
using System.Collections.Generic;


namespace infrastructure.DATA;

public partial class Condominiums
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string? GoogleMapUrl { get; set; }

    public decimal? TotalArea { get; set; }

    public decimal? ProfitRate { get; set; }

    public string UnitTypes { get; set; } = null!;

    public int UnitsPerCondominium { get; set; }

    public DateTime? IncorporationDate { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int MunicipalityId { get; set; }

    public int RepresentativeId { get; set; }

    public virtual ICollection<CondominiumWastes> CondominiumWastes { get; set; } = new List<CondominiumWastes>();

    public virtual Municipalities Municipality { get; set; } = null!;

    public virtual Users Representative { get; set; } = null!;
}
