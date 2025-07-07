using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;

namespace Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;

public interface IGetMonthlyFeesController
{
    Task<ResponseMonthlyFees<MonthlyFeesDto>> GetAllMonthlyFeesAsync();

}
