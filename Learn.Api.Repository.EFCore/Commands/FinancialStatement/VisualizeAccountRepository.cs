using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Microsoft.EntityFrameworkCore;
namespace Learn.Api.Repository.EFCore.Commands.FinancialStatement
{
    internal class VisualizeAccountRepository(AppLearnContext context): IGetVisualizeAccountRepository
    {
        public async Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementAsync()
        {
            var response = new ResponseVisualizeAccount<VisualizeAccountDto>
            {
                Items = await context.VisualizeAccounts.Select(
                    visualizeAccount => new VisualizeAccountDto
                    (
                        visualizeAccount.Code,
                        visualizeAccount.NameResident,
                        visualizeAccount.Address,
                        visualizeAccount.Status,
                        visualizeAccount.Service,
                        visualizeAccount.FinancialStatement
                    )
                ).ToListAsync()
            };

            return response;
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
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        Task<ResponseVisualizeAccount<VisualizeAccountDto>> IGetVisualizeAccountRepository.GetAllFinancialStatementsAsync(bool status)
        {
            throw new NotImplementedException();
        }
    }
}