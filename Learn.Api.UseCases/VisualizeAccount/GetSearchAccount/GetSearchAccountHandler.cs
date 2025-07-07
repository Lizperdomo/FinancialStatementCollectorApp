using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;

namespace Learn.Api.UseCases.VisualizeAccount;

public class GetSearchAccountHandler(IGetSearchAccountRepository repository) : IGetSearchAccountInput
{
    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(int code)
    {
        return await repository.GetAllSearchAccountAsync(code);
    }
    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(string nameResident)
    {
        return await repository.GetAllSearchAccountAsync(nameResident);
    }

    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(bool status)
    {
        return await repository.GetAllSearchAccountAsync(status);
    }

}
