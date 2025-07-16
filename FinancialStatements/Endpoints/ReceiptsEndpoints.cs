using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using Learn.Api.Controllers.Receipts;
using Learn.Api.Domain.Entities.Dtos.Receipts;
using Microsoft.AspNetCore.Mvc;

namespace FinancialStatements.Endpoints;

public static class ReceiptsEndpoints
{
    public static WebApplication MapReceiptsEndpoints(this WebApplication app)
    {
        // Agrupa todas las rutas de recibos
        var routeGroup = app.MapGroup("api/v3/Receipts");

        // === Endpoint para crear un nuevo recibo ===
        routeGroup.MapPost("/", async ([FromServices] ICreateReceiptController controller, [FromBody] CreateReceiptDto dto) =>
        {
            var result = await controller.CreateAsync(dto);
            return Results.Created($"/api/v3/Receipts/{result.Id}", result);
        }).WithTags("Recibos");

        // === Endpoint para cancelar un recibo por su ID ===
        routeGroup.MapPut("/{id}/cancel", async ([FromServices] ICancelReceiptController controller, [FromRoute] int id) =>
        {
            var result = await controller.CancelAsync(id);
            return result ? Results.Ok("Recibo cancelado.") : Results.NotFound("Recibo no encontrado o ya cancelado.");
        }).WithTags("Recibos");

        // === Endpoint para obtener los recibos de una fecha específica ===
        routeGroup.MapGet("/by-date", async ([FromServices] IGetReceiptsByDateController controller, [FromQuery] DateTime date) =>
        {
            var result = await controller.GetAsync(date);
            return Results.Ok(result);
        }).WithTags("Recibos");

        // === Endpoint para obtener los recibos del día actual ===
        routeGroup.MapGet("/today", async ([FromServices] IGetReceiptsForCurrentDayController controller) =>
        {
            var result = await controller.GetAsync();
            return Results.Ok(result);
        }).WithTags("Recibos");

        // === Endpoint para obtener los recibos del mes actual ===
        routeGroup.MapGet("/this-month", async ([FromServices] IGetReceiptsForCurrentMonthController controller) =>
        {
            var result = await controller.GetAsync();
            return Results.Ok(result);
        }).WithTags("Recibos");

        // === Endpoint para buscar recibos por ID de casa o nombre del residente ===
        routeGroup.MapGet("/search", async ([FromServices] IGetReceiptsByHouseOrResidentController controller, [FromQuery] string? houseId, [FromQuery] string? residentName) =>
        {
            var result = await controller.GetAsync(houseId, residentName);
            return Results.Ok(result);
        }).WithTags("Recibos");

        // === Endpoint para obtener todos los recibos existentes ===
        routeGroup.MapGet("/", async ([FromServices] IGetAllReceiptsController controller) =>
        {
            var result = await controller.GetAsync();
            return Results.Ok(result);
        }).WithTags("Recibos");

        return app;
    }
}
    