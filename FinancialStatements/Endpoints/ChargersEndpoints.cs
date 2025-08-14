using Learn.Api.BusinessObjects.Interfaces.Chargers;
using Learn.Api.Domain.Entities.Dtos.Chargers;
using Microsoft.AspNetCore.Mvc;

namespace FinancialStatements.Endpoints;

public static class ChargersEndpoints
{
    public static WebApplication MapChargersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/v3/Chargers");

        static IResult HandleError(Exception ex, HttpContext ctx)
        {
            var status = (ex is ArgumentException or FormatException or KeyNotFoundException) ? 400 : 500;
            return Results.Json(new
            {
                status,
                error = ex.Message,
                path = ctx.Request.Path.Value,
                timestamp = DateTime.UtcNow.ToString("o")
            }, statusCode: status);
        }

        group.MapPost("/RegisterCharge/{email}",
            async ([FromRoute] string email,
                   [FromBody] RegisterChargeDto dto,
                   [FromServices] IRegisterChargeController controller,
                   HttpContext ctx) =>
            {
                try { return Results.Ok(await controller.RegisterAsync(email, dto)); }
                catch (Exception ex) { return HandleError(ex, ctx); }
            })
        .WithTags("Chargers");

        group.MapPost("/AssociateCharge/{email}",
            async ([FromRoute] string email,
                   [FromBody] AssociateChargeDto dto,
                   [FromServices] IAssociateChargeController controller,
                   HttpContext ctx) =>
            {
                try { return Results.Ok(await controller.AssociateAsync(email, dto)); }
                catch (Exception ex) { return HandleError(ex, ctx); }
            })
        .WithTags("Chargers");

        return app;
    }
}
