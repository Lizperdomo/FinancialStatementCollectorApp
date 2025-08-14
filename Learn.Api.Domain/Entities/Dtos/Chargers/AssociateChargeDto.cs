namespace Learn.Api.Domain.Entities.Dtos.Chargers;

public class AssociateChargeDto(string miscIncomeType, decimal amount)
{
    public string MiscIncomeType => miscIncomeType;
    public decimal Amount => amount;
}
