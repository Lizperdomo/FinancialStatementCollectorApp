using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;

namespace Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;

public interface IGetMonthlyFeesRepository
{
    Task<ResponseMonthlyFees<MonthlyFeesDto>> GetAllMonthlyFeesAsync();
    Task SaveChangesAsync();
}
