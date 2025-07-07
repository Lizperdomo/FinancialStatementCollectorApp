using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;
using Microsoft.EntityFrameworkCore;

namespace Learn.Api.Repository.EFCore.Commands.FinancialStatement;

internal class MonthlyFeesRepository(AppLearnContext context) : IGetMonthlyFeesRepository
{
    public async Task<ResponseMonthlyFees<MonthlyFeesDto>> GetAllMonthlyFeesAsync()
    {
        var response = new ResponseMonthlyFees<MonthlyFeesDto>
        {
            Items = await context.MonthlyFees.Select(
                monthlyFees => new MonthlyFeesDto
                (
                    monthlyFees.IdHouse,
                    monthlyFees.Income,
                    monthlyFees.Agreements,
                    monthlyFees.Status
                )
            ).ToListAsync()
        };

        return response;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}

