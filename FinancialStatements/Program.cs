using FinancialStatements.Endpoints;
using Learn.Api.IoC;
using Learn.Api.Repository.EFCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddLearnServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.InitializeLearnApiDb();
    
app.MapVisualizeStatementEndpoints();

app.MapControllers();

app.Run();
