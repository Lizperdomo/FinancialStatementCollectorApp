using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;

namespace Learn.Api.UseCases.VisualizeAccount;

public class GetMonthlyFeesHandler(IGetMonthlyFeesRepository repository) : IGetMonthlyFeesInput
{
    public async Task<ResponseMonthlyFees<MonthlyFeesDto>> GetAllMonthlyFeesAsync()
    {
        return await repository.GetAllMonthlyFeesAsync();
    }
}
