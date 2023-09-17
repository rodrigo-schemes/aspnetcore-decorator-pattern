using DecoratorPattern.API.Dominio;
using Microsoft.EntityFrameworkCore;

namespace DecoratorPattern.API.Infra.Database;

public class AppDbContexto : DbContext
{
    public DbSet<Cliente>? Clientes { get; set; }

    public AppDbContexto(DbContextOptions opcoes):base(opcoes)
    {
        
    }
}