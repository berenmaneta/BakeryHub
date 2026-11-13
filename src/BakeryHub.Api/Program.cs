using BakeryHub.Application.UseCases.Users;
using BakeryHub.Domain.Interfaces;
using BakeryHub.Infrastructure.Persistence;
using BakeryHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados (Entity Framework Core)
builder.Services.AddDbContext<BakeryHubDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Serviços da API
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Injeção de dependência para os repositórios e casos de uso
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();

// Versionamento da API
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddMvc();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// 3. Configuração do Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 4. Um endpoint simples só para testarmos se a API está no ar
//app.MapGet("/", () => "BakeryHub API está online e conectada!");

app.MapControllers();

app.Run();