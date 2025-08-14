using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Chargers; // NUEVO
using Learn.Api.Controllers.FinancialStatement.GetMonthlyFees;
using Learn.Api.Controllers.FinancialStatement.GetSearchAccount;
using Learn.Api.Controllers.FinancialStatement.GetVisualizeAccount;
using Learn.Api.Controllers.FinancialStatement.GetVisualizeHomes;
using Learn.Api.Controllers.Receipts.CancelReceipt;
using Learn.Api.Controllers.Receipts.CreateReceipt;
using Learn.Api.Controllers.Receipts.GetAllReceipts;
using Learn.Api.Controllers.Receipts.GetReceiptsByDate;
using Learn.Api.Controllers.Receipts.GetReceiptsByHouseOrResident;
using Learn.Api.Controllers.Receipts.GetReceiptsForCurrentDay;
using Learn.Api.Controllers.Receipts.GetReceiptsForCurrentMonth;
using Learn.Api.Controllers.Chargers.RegisterCharge;   
using Learn.Api.Controllers.Chargers.AssociateCharge; 

namespace Learn.Api.Controllers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLearnControllers(this IServiceCollection services)
        {
            services.AddScoped<IGetVisualizeAccountController, GetVizualizeAccountController>();
            services.AddScoped<IGetVisualizeHomesController, GetVisualizeHomesController>();
            services.AddScoped<IGetSearchAccountController, GetSearchAccountController>();
            services.AddScoped<IGetMonthlyFeesController, GetMonthlyFeesController>();

            services.AddScoped<ICreateReceiptController, CreateReceiptController>();
            services.AddScoped<ICancelReceiptController, CancelReceiptController>();
            services.AddScoped<IGetReceiptsByDateController, GetReceiptsByDateController>();
            services.AddScoped<IGetReceiptsForCurrentDayController, GetReceiptsForCurrentDayController>();
            services.AddScoped<IGetReceiptsForCurrentMonthController, GetReceiptsForCurrentMonthController>();
            services.AddScoped<IGetReceiptsByHouseOrResidentController, GetReceiptsByHouseOrResidentController>();
            services.AddScoped<IGetAllReceiptsController, GetAllReceiptsController>();

            //  CHARGERS
            services.AddScoped<IRegisterChargeController, RegisterChargeController>();
            services.AddScoped<IAssociateChargeController, AssociateChargeController>();

            return services;
        }
    }
}
