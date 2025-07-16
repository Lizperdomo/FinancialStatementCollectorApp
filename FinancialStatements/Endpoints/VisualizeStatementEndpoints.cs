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

        // Endpoint para obtener estados financieros por status
        routeGroup.MapGet("/FinancialStatement", async ([FromServices] IGetVisualizeAccountController controller, [FromQuery] bool status) =>
        {
            var data = await controller.GetAllFinancialStatementAsync(status);
            return Results.Ok(data);
        }).WithTags("Estados Financieros");

        // Endpoint para obtener lista de viviendas
        routeGroup.MapGet("/FinancialStatements/VisualizeHomes", async ([FromServices] IGetVisualizeHomesController controller) =>
        {
            var data = await controller.GetAllHomesAsync();
            return Results.Ok(data);
        }).WithTags("Estados Financieros");

        // Endpoint para obtener cuotas mensuales
        routeGroup.MapGet("/FinancialStatements/MonthlyFees", async ([FromServices] IGetMonthlyFeesController controller) =>
        {
            var data = await controller.GetAllMonthlyFeesAsync();
            return Results.Ok(data);
        }).WithTags("Estados Financieros");

        // Endpoint para búsqueda de cuentas
        routeGroup.MapGet("/FinancialStatements/SearchAccount", async ([FromServices] IGetSearchAccountController controller, [FromQuery] int code,
            [FromQuery] string nameResident, [FromQuery] bool status) =>
        {
            var data = new List<object>
            {
                await controller.GetAllSearchAccountAsync(code),
                await controller.GetAllSearchAccountAsync(nameResident),
                await controller.GetAllSearchAccountAsync(status)
            };
            return Results.Ok(data);
        }).WithTags("Estados Financieros");

        return app;
    }
}
