using ButterflyXp.Core;
using ButterflyXp.Core.Repository;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Dependency injection: one shared in-memory repository and service
builder.Services.AddSingleton<IButterflyRepository, FakeButterflyRepository>();
builder.Services.AddSingleton<ButterflyService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

app.Run();