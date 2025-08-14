using System.ComponentModel.DataAnnotations;

namespace Learn.Api.BusinessObjects.Entities.Chargers;

public class Charge
{
    [Key] public Guid Id { get; set; }
    [MaxLength(200)] public string Email { get; set; } = default!;
    [MaxLength(50)] public string AgreementNumber { get; set; } = default!;
    [MaxLength(500)] public string? Description { get; set; }
    public decimal Debt { get; set; }
    public int PaymentsCount { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    [MaxLength(64)] public string ReceiptFolio { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<AssociatedCharge> AssociatedCharges { get; set; } = new();
}
