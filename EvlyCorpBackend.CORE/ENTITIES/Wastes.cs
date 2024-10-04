using System;
using System.Collections.Generic;


namespace EvlyCorpBackend.INFRASTRUCTURE.Data;

public partial class Wastes
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string MeasurementUnit { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CondominiumWastes> CondominiumWastes { get; set; } = new List<CondominiumWastes>();

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
