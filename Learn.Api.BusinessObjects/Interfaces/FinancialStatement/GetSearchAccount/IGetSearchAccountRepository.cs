using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;

namespace Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;

public interface IGetSearchAccountRepository
{
    Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync();

    Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(int code);
    Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(string nameResident);
    Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(bool status);
    Task SaveChangesAsync();


}
