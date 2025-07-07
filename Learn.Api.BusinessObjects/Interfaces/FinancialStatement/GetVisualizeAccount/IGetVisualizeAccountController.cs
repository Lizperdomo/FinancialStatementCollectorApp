using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;

namespace Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;

public interface IGetVisualizeAccountController
{
    Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementAsync();

}