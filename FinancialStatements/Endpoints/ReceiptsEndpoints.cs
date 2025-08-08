using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using Learn.Api.Controllers.Receipts;
using Learn.Api.Domain.Entities.Dtos.Receipts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinancialStatements.Endpoints;

public static class ReceiptsEndpoints
{
    public static WebApplication MapReceiptsEndpoints(this WebApplication app)
    {
        // Agrupa todas las rutas de recibos
        var routeGroup = app.MapGroup("api/v3/Receipts");

        // Función para manejar errores y devolver JSON estándar
        static IResult HandleError(Exception ex, string path)
        {
            int statusCode = 500;
            string errorMsg = ex.Message;

            // Si es un error de validación, devolver 400
            if (ex is ArgumentException || ex is FormatException)
            {
                statusCode = 400;
            }

            var errorObj = new
            {
                status = statusCode,
                error = errorMsg,
                path = path,
                timestamp = DateTime.UtcNow.ToString("o")
            };
            return Results.Json(errorObj, statusCode: statusCode);
        }

        // === Endpoint para crear un nuevo recibo ===
        routeGroup.MapPost("/", async ([FromServices] ICreateReceiptController controller, [FromBody] CreateReceiptDto dto, HttpContext ctx) =>
        {
            try
            {
                var result = await controller.CreateAsync(dto);
                return Results.Created($"/api/v3/Receipts/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return HandleError(ex, ctx.Request.Path);
            }
        }).WithTags("Recibos");

        // === Endpoint para cancelar un recibo por su ID ===
        routeGroup.MapPut("/{id}/cancel", async ([FromServices] ICancelReceiptController controller, [FromRoute] int id, HttpContext ctx) =>
        {
            try
            {
                var result = await controller.CancelAsync(id);
                return result ? Results.Ok("Recibo cancelado.") : Results.NotFound("Recibo no encontrado o ya cancelado.");
            }
            catch (Exception ex)
            {
                return HandleError(ex, ctx.Request.Path);
            }
        }).WithTags("Recibos");

        // === Endpoint para obtener los recibos de una fecha específica ===
        routeGroup.MapGet("/by-date", async ([FromServices] IGetReceiptsByDateController controller, [FromQuery] DateTime date, HttpContext ctx) =>
        {
            try
            {
                var result = await controller.GetAsync(date);
                if (result is IEnumerable<Receipt> receipts && !receipts.Any())
                    return Results.NotFound("No se encontraron recibos para la fecha especificada.");
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return HandleError(ex, ctx.Request.Path);
            }
        }).WithTags("Recibos");

        // === Endpoint para obtener los recibos del día actual ===
        routeGroup.MapGet("/today", async ([FromServices] IGetReceiptsForCurrentDayController controller, HttpContext ctx) =>
        {
            try
            {
                var result = await controller.GetAsync();
                if (result is IEnumerable<Receipt> receipts && !receipts.Any())
                    return Results.NotFound("No se encontraron recibos para el día actual.");
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return HandleError(ex, ctx.Request.Path);
            }
        }).WithTags("Recibos");

        // === Endpoint para obtener los recibos del mes actual ===
        routeGroup.MapGet("/this-month", async ([FromServices] IGetReceiptsForCurrentMonthController controller, HttpContext ctx) =>
        {
            try
            {
                var result = await controller.GetAsync();
                if (result is IEnumerable<Receipt> receipts && !receipts.Any())
                    return Results.NotFound("No se encontraron recibos para el mes actual.");
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return HandleError(ex, ctx.Request.Path);
            }
        }).WithTags("Recibos");

        // === Endpoint para buscar recibos por ID de casa o nombre del residente ===
        routeGroup.MapGet("/search", async ([FromServices] IGetReceiptsByHouseOrResidentController controller, [FromQuery] string? houseId, [FromQuery] string? residentName, HttpContext ctx) =>
        {
            try
            {
                var result = await controller.GetAsync(houseId, residentName);
                if (result is IEnumerable<Receipt> receipts && !receipts.Any())
                    return Results.NotFound("No se encontraron recibos para los criterios de búsqueda proporcionados.");
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return HandleError(ex, ctx.Request.Path);
            }
        }).WithTags("Recibos");

        // === Endpoint para obtener todos los recibos existentes ===
        routeGroup.MapGet("/", async ([FromServices] IGetAllReceiptsController controller, HttpContext ctx) =>
        {
            try
            {
                var result = await controller.GetAsync();
                if (result is IEnumerable<Receipt> receipts && !receipts.Any())
                    return Results.NotFound("No se encontraron recibos registrados.");
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return HandleError(ex, ctx.Request.Path);
            }
        }).WithTags("Recibos");

        return app;
    }
}