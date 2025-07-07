namespace Learn.Api.Domain.Entities.Dtos.FinancialStatement;

public class SearchAccountDto(int code, string nameResident, string address, bool status, bool service, int financialStatement)
{
    public int Code => code;
    public string NameResident => nameResident;
    public string Address => address;
    public bool Status => status;
    public bool Service => service;
    public int FinancialStatement => financialStatement;

}
