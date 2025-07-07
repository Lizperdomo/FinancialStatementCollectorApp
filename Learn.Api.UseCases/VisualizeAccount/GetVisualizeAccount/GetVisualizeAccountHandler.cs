using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;

namespace Learn.Api.UseCases.VisualizeAccount;

internal class GetVisualizeAccountHandler(IGetVisualizeAccountRepository repository) : IGetVisualizeAccountInputPort
{
    public async Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementAsync()
    {
        return await repository.GetAllFinancialStatementAsync();
    }

}