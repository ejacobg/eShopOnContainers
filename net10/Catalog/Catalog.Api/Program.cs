using Catalog.Api.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CatalogContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("LocalDb") ?? throw new InvalidOperationException("LocalDb connection string not found"))
        .UseSeeding((dbContext, smOp) => CatalogContextSeeder.SeedAsync(dbContext, smOp, CancellationToken.None).GetAwaiter().GetResult())
        .UseAsyncSeeding(CatalogContextSeeder.SeedAsync);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
