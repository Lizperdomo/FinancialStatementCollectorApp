using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;
using Learn.Api.Controllers.FinancialStatement.GetMonthlyFees;
using Learn.Api.Controllers.FinancialStatement.GetVisualizeHomes;
using Learn.Api.Repository.EFCore.Commands.FinancialStatement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Learn.Api.Repository.EFCore;
public static class DependencyContainer
{
    public static IServiceCollection AddLearnRepositories(this IServiceCollection service)
    {
        service.AddDbContext<AppLearnContext>(Options => Options.UseSqlite("Data Source=database.dat"));
        service.AddScoped<IGetVisualizeAccountRepository, VisualizeAccountRepository>();
        service.AddScoped<IGetVisualizeHomesRepository, VisualizeHomesRepository>();
        service.AddScoped<IGetSearchAccountRepository, SearchAccountRepository>();
        service.AddScoped<IGetMonthlyFeesRepository, MonthlyFeesRepository>();
        return service;
    }
    public static IHost InitializeLearnApiDb(this IHost app)
    {
        using IServiceScope Scope = app.Services.CreateScope();
        var Context = Scope.ServiceProvider.GetRequiredService<AppLearnContext>();
        Context.Database.EnsureCreated();
        return app;
    }
}
