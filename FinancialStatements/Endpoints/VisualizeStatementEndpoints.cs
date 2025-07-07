using Microsoft.AspNetCore.Mvc;
using Learn.Api.Controllers.FinancialStatement;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.MonthlyFees;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.SearchAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;

namespace FinancialStatements.Endpoints;

public static class VisualizeStatementEndpoints
{
    public static WebApplication MapVisualizeStatementEndpoints(this WebApplication app)
    {
        var routeGroup = app.MapGroup("api/v3");

        routeGroup.MapGet("/FinancialStatement", async ([FromServices] IGetVisualizeAccountController controller, [FromQuery] bool status) =>
        {
            var data = await controller.GetAllFinancialStatementAsync();
            return Results.Ok(data);
        });

        routeGroup.MapGet("/FinancialStatements/VisualizeHomes", async ([FromServices] IGetVisualizeHomesController controller) =>
        {
            var data = await controller.GetAllHomesAsync();
            return Results.Ok(data);
        });

        routeGroup.MapGet("/FinancialStatements/MonthlyFees", async ([FromServices] IGetMonthlyFeesController controller) =>
        {
            var data = await controller.GetAllMonthlyFeesAsync();
            return Results.Ok(data);
        });

        routeGroup.MapGet("/FinancialStatements/SearchAccount", async ([FromServices] IGetSearchAccountController controller, [FromQuery] int code, 
            [FromQuery] string nameResident, [FromQuery] bool status) =>
        {
            var data = await controller.GetAllSearchAccountAsync(code);
            var data2 = await controller.GetAllSearchAccountAsync(nameResident);
            var data3 = await controller.GetAllSearchAccountAsync(status);
            return Results.Ok(data);
            return Results.Ok(data2);
            return Results.Ok(data3);
        });


        return app;
    }
}