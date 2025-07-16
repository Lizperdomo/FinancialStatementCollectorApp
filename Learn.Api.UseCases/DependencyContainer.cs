using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using Learn.Api.UseCases.Receipts.CancelReceipt;
using Learn.Api.UseCases.Receipts.CreateReceipt;
using Learn.Api.UseCases.Receipts.GetAllReceipts;
using Learn.Api.UseCases.Receipts.GetReceiptsByDate;
using Learn.Api.UseCases.Receipts.GetReceiptsByHouseOrResident;
using Learn.Api.UseCases.Receipts.GetReceiptsForCurrentDay;
using Learn.Api.UseCases.Receipts.GetReceiptsForCurrentMonth;
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

        //RECIBOS//
        // Casos de uso relacionados con recibos
        services.AddScoped<ICreateReceiptInput, CreateReceiptHandler>();
        services.AddScoped<ICancelReceiptInput, CancelReceiptHandler>();
        services.AddScoped<IGetReceiptsForCurrentDayInput, GetReceiptsForCurrentDayHandler>();
        services.AddScoped<IGetReceiptsForCurrentMonthInput, GetReceiptsForCurrentMonthHandler>();
        services.AddScoped<IGetReceiptsByDateInput, GetReceiptsByDateHandler>();
        services.AddScoped<IGetReceiptsByHouseOrResidentInput, GetReceiptsByHouseOrResidentHandler>();
        services.AddScoped<IGetAllReceiptsInput, GetAllReceiptsHandler>();

        return services;
    }
}
