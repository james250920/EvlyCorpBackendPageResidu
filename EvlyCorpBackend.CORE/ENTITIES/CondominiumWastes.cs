namespace EvlyCorpBackend.INFRASTRUCTURE.Data;

public partial class CondominiumWastes
{
    public int Id { get; set; }

    public decimal Weight { get; set; }

    public bool FreeCollection { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int WasteId { get; set; }
    public string status { get; set; }

    public int CondominiumId { get; set; }

    public virtual Condominiums Condominium { get; set; } = null!;

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();

    public virtual Wastes Waste { get; set; } = null!;
}
