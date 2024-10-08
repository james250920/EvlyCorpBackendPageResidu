using System;
using System.Collections.Generic;


namespace infrastructure.DATA;

public partial class Districts
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Provinces Province { get; set; } = null!;

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
