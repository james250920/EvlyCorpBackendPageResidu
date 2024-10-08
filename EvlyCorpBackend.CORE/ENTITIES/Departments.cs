using System;
using System.Collections.Generic;


namespace infrastructure.DATA;

public partial class Departments
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Provinces> Provinces { get; set; } = new List<Provinces>();
}
