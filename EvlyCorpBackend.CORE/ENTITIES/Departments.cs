using System;
using System.Collections.Generic;


namespace EvlyCorpBackend.INFRASTRUCTURE.Data;

public partial class Departments
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? ProvinceId { get; set; }

    public virtual ICollection<DistrictsUpdatetDTO> Districts { get; set; } = new List<DistrictsUpdatetDTO>();

    public virtual Provinces? Province { get; set; }

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
