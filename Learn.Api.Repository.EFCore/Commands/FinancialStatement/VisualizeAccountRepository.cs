using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Microsoft.EntityFrameworkCore;
namespace Learn.Api.Repository.EFCore.Commands.FinancialStatement
{
    internal class VisualizeAccountRepository : IGetVisualizeAccountRepository
    {
        private readonly AppLearnContext context;

        public VisualizeAccountRepository(AppLearnContext context)
        {
            this.context = context;
        }

        public async Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementAsync()
        {

                var items = await context.VisualizeAccounts.Select(
                    visualizeAccount => new VisualizeAccountDto
                    (
                        visualizeAccount.Code,
                        visualizeAccount.NameResident,
                        visualizeAccount.Address,
                        visualizeAccount.Status,
                        visualizeAccount.Service,
                        visualizeAccount.FinancialStatement
                    ))
                .ToListAsync();

            return new ResponseVisualizeAccount<VisualizeAccountDto>
            {
                Items = items
            };
        }
        public async Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementAsync(bool status)
        {
            var items = await context.VisualizeAccounts
                .Where(visualizeAccount => visualizeAccount.Status == status)
                .Select(visualizeAccount => new VisualizeAccountDto(
                    visualizeAccount.Code,
                    visualizeAccount.NameResident,
                    visualizeAccount.Address,
                    visualizeAccount.Status,
                    visualizeAccount.Service,
                    visualizeAccount.FinancialStatement
                ))
                .ToListAsync();

            return new ResponseVisualizeAccount<VisualizeAccountDto>
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

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
