using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;

namespace Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;

public interface IGetVisualizeAccountInputPort
{
    Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementAsync(bool status);

}

