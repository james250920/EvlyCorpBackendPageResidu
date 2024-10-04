using System;
using System.Collections.Generic;

namespace EvlyCorpBackend.INFRASTRUCTURE.Data;

public partial class DistrictsUpdatetDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Departments? Department { get; set; }

    public virtual Provinces Province { get; set; } = null!;
}
