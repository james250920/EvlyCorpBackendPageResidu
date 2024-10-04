using System;
using System.Collections.Generic;

namespace EvlyCorpBackend.INFRASTRUCTURE.Data;

public partial class Provinces
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Departments> Departments { get; set; } = new List<Departments>();

    public virtual ICollection<DistrictsUpdatetDTO> Districts { get; set; } = new List<DistrictsUpdatetDTO>();
}
