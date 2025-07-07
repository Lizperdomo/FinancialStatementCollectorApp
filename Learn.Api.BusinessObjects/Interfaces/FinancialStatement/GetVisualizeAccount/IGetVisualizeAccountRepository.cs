using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;

namespace Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;

public interface IGetVisualizeAccountRepository
{
    Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementAsync();
    Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementsAsync(bool status);
    Task SaveChangesAsync();
}
