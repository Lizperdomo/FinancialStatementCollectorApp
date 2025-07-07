using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;

namespace Learn.Api.UseCases.VisualizeAccount;

public class GetVisualizeHomesHandler(IGetVisualizeHomesRepository repository) : IGetVisualizeHomesInput
{
    public async Task<ResponseVisualizeHomes<VisualizeHomesDto>> GetAllHomesAsync()
    {
        return await repository.GetAllHomesAsync();
    }
}
