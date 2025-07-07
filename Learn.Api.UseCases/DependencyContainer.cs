using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;
using Learn.Api.UseCases.VisualizeAccount;
using Microsoft.Extensions.DependencyInjection;

namespace Learn.Api.UseCases;

public static class DependencyContainer
{
    public static IServiceCollection AddLearnUseCases(this IServiceCollection services)
    {
        services.AddScoped<IGetVisualizeAccountInputPort, GetVisualizeAccountHandler>();
        services.AddScoped<IGetVisualizeHomesInput, GetVisualizeHomesHandler>();
        services.AddScoped<IGetSearchAccountInput, GetSearchAccountHandler>();
        services.AddScoped<IGetMonthlyFeesInput, GetMonthlyFeesHandler>();
        return services;
    }
}
