namespace Learn.Api.Domain.Entities.Dtos.FinancialStatement;

public class MonthlyFeesDto(int idHouse, int income, string agreements, bool status)
{
    public int IdHouse => idHouse;
    public int Income => income;
    public string? Agreements => agreements;
    public bool Status => status;

}
