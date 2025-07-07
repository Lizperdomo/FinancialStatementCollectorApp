using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;

namespace Learn.Api.Controllers.FinancialStatement.GetSearchAccount;

public class GetSearchAccountController(IGetSearchAccountInput inputPort) : IGetSearchAccountController
{
    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(int code)
    {
        return await inputPort.GetAllSearchAccountAsync(code);
    }

    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(string nameResident)
    {
        return await inputPort.GetAllSearchAccountAsync(nameResident);
    }

    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(bool status)
    {
        return await inputPort.GetAllSearchAccountAsync(status);
    }
}
