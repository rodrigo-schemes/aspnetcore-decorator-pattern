using DecoratorPattern.API.Dominio.Interfaces;
using DecoratorPattern.API.Infra.Database;
using DecoratorPattern.API.Infra.Database.Migracoes;
using DecoratorPattern.API.Infra.Database.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContexto>(optionsBuilder =>
{
    var diretorioApp = Environment.SpecialFolder.LocalApplicationData;
    var caminhoApp = Environment.GetFolderPath(diretorioApp);
    
    optionsBuilder.UseSqlite($"Data Source={Path.Join(caminhoApp, "cliente.db")}");
});

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.AplicarMigracoes();

app.Run();