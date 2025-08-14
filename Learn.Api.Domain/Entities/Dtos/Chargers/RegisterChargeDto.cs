namespace Learn.Api.Domain.Entities.Dtos.Chargers;

public class RegisterChargeDto(
    string agreementNumber,
    string description,
    decimal debt,
    int paymentsCount,
    decimal amount,
    DateTime dueDate)
{
    public string AgreementNumber => agreementNumber;
    public string Description => description;
    public decimal Debt => debt;
    public int PaymentsCount => paymentsCount;
    public decimal Amount => amount;
    public DateTime DueDate => dueDate;
}
