using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;

namespace Learn.Api.Controllers.FinancialStatement.GetMonthlyFees;

public class GetMonthlyFeesController(IGetMonthlyFeesInput inputPort) : IGetMonthlyFeesController
{
    public async Task<ResponseMonthlyFees<MonthlyFeesDto>> GetAllMonthlyFeesAsync()
    {
        return await inputPort.GetAllMonthlyFeesAsync();
    }

}
