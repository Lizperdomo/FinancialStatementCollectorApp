using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;
using Learn.Api.Controllers.FinancialStatement.GetMonthlyFees;
using Learn.Api.Controllers.FinancialStatement.GetSearchAccount;
using Learn.Api.Controllers.FinancialStatement.GetVisualizeAccount;
using Learn.Api.Controllers.FinancialStatement.GetVisualizeHomes;


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
          
            return services;
        }
    }
}
