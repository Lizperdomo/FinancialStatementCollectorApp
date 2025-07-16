using FinancialStatements.Endpoints;
using Learn.Api.IoC;
using Learn.Api.Repository.EFCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Learn API - Receipts",
        Version = "v1"
    });
});

builder.Services.AddLearnServices();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();           
    app.UseSwaggerUI(c =>       
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learn API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.InitializeLearnApiDb();

app.MapVisualizeStatementEndpoints();
app.MapReceiptsEndpoints();
app.MapControllers();

app.Run();
