﻿using System;
using System.Collections.Generic;


namespace infrastructure.DATA;

public partial class Orders
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int CondominiumWasteId { get; set; }

    public int WasteId { get; set; }

    public virtual CondominiumWastes CondominiumWaste { get; set; } = null!;

    public virtual Wastes Waste { get; set; } = null!;
}
