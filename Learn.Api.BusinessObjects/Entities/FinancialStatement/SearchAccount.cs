using System.ComponentModel.DataAnnotations;

namespace Learn.Api.Business.Objects.Entities.FinancialStatement;

public class SearchAccount
{
    [Key]
    public int Code { get; set; }
    public string? NameResident { get; set; }
    public string? Address { get; set; }
    public bool Status { get; set; }
    public bool Service { get; set; }
    public int FinancialStatement { get; set; }
}
