using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using Learn.Api.Repository.EFCore;
using Learn.Api.Repository.EFCore.Commands.FinancialStatement;
using Learn.Api.Repository.EFCore.Commands.Receipts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class DependencyContainer
{
    public static IServiceCollection AddLearnRepositories(this IServiceCollection service)
    {
        service.AddDbContext<AppLearnContext>(options =>
            options.UseSqlite("Data Source=database.dat"));

        service.AddScoped<IGetVisualizeAccountRepository, VisualizeAccountRepository>();
        service.AddScoped<IGetVisualizeHomesRepository, VisualizeHomesRepository>();
        service.AddScoped<IGetSearchAccountRepository, SearchAccountRepository>();
        service.AddScoped<IGetMonthlyFeesRepository, MonthlyFeesRepository>();

        service.AddScoped<IReceiptRepository, ReceiptRepository>();

        return service;
    }

    //Método que inicializa la base de datos
    public static IHost InitializeLearnApiDb(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppLearnContext>();
        context.Database.EnsureCreated();
        return app;
    }
}
