using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;

namespace Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;

public interface IGetVisualizeHomesInput
{
    Task<ResponseVisualizeHomes<VisualizeHomesDto>> GetAllHomesAsync();
}
