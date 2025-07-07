using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;

namespace Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;

public interface IGetSearchAccountController
{
    Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(int code);
    Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(string nameResident);
    Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(bool status);

}
