using Bogus;
using DecoratorPattern.API.Dominio;

namespace DecoratorPattern.API.Infra.Database;

public static class PopularDb
{
    public static void InserirClientes(this IApplicationBuilder app)
    {
        using var escopo = app.ApplicationServices.CreateScope();
        using var appDbContexto = escopo.ServiceProvider.GetRequiredService<AppDbContexto>();
        
        if (appDbContexto.Clientes.Any()) return;

        var clientesFake = new Faker<Cliente>("pt_BR")
            .RuleFor(x => x.Nome, x => x.Person.FullName)
            .RuleFor(x => x.Email, x => x.Person.Email)
            .Generate(10);
        
        appDbContexto.AddRange(clientesFake);
        appDbContexto.SaveChanges();
    }
}