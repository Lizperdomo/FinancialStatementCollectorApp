using System.ComponentModel.DataAnnotations;

namespace Learn.Api.BusinessObjects.Entities.Chargers;

public class AssociatedCharge
{
    [Key] public Guid Id { get; set; }
    public Guid ChargeId { get; set; }
    public Charge Charge { get; set; } = default!;
    [MaxLength(120)] public string MiscIncomeType { get; set; } = default!;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
