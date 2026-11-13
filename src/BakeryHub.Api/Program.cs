using BakeryHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados (Entity Framework Core)
builder.Services.AddDbContext<BakeryHubDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Serviços da API
builder.Services.AddOpenApi();

var app = builder.Build();

// 3. Configuração do Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 4. Um endpoint simples só para testarmos se a API está no ar
app.MapGet("/", () => "BakeryHub API está online e conectada!");

app.Run();