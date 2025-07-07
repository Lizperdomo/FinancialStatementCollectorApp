using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;
using Microsoft.EntityFrameworkCore;

namespace Learn.Api.Repository.EFCore.Commands.FinancialStatement;

internal class SearchAccountRepository : IGetSearchAccountRepository
{
    private readonly AppLearnContext context;

    public SearchAccountRepository(AppLearnContext context)
    {
        this.context = context;
    }

    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync()
    {
        var items = await context.SearchAccount
            .Select(searchAccount => new SearchAccountDto(
                searchAccount.Code,
                searchAccount.NameResident,
                searchAccount.Address,
                searchAccount.Status,
                searchAccount.Service,
                searchAccount.FinancialStatement
            ))
            .ToListAsync();

        return new ResponseSearchAccount<SearchAccountDto>
        {
            Items = items
        };
    }
    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(int code)
    {
        var items = await context.SearchAccount
            .Where(codeHouse => codeHouse.Code == code) 
            .Select(codeHouse => new SearchAccountDto(
                codeHouse.Code,
                codeHouse.NameResident,
                codeHouse.Address,
                codeHouse.Status,
                codeHouse.Service,
                codeHouse.FinancialStatement
            ))
            .ToListAsync();

        return new ResponseSearchAccount<SearchAccountDto>
        {
            Items = items
        };
    }
    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(string nameResident)
    {
        var items = await context.SearchAccount
            .Where(sa => sa.NameResident.Contains(nameResident))
            .Select(sa => new SearchAccountDto(
                sa.Code,
                sa.NameResident,
                sa.Address,
                sa.Status,
                sa.Service,
                sa.FinancialStatement
            ))
            .ToListAsync();

        return new ResponseSearchAccount<SearchAccountDto>
        {
            Items = items
        };
    }

    public async Task<ResponseSearchAccount<SearchAccountDto>> GetAllSearchAccountAsync(bool status)
    {
        var items = await context.SearchAccount
            .Where(statusSearch => statusSearch.Status == status) 
            .Select(statusSearch => new SearchAccountDto(
                statusSearch.Code,
                statusSearch.NameResident,
                statusSearch.Address,
                statusSearch.Status,
                statusSearch.Service,
                statusSearch.FinancialStatement
            ))
            .ToListAsync();

        return new ResponseSearchAccount<SearchAccountDto>
        {
            Items = items
        };
    }
    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}

