using System;
using System.Collections.Generic;

namespace infrastructure.DATA;

public partial class Provinces
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Departments? Department { get; set; }

    public virtual ICollection<Districts> Districts { get; set; } = new List<Districts>();
}
