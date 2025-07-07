using System.ComponentModel.DataAnnotations;

namespace Learn.Api.Business.Objects.Entities.FinancialStatement;

public class MonthlyFees
{
    [Key]
    public int IdHouse { get; set; }
    public int Income { get; set; }
    public string? Agreements { get; set; }
    public bool Status { get; set; }
}
