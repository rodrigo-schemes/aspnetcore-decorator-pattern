using Bogus;
using DecoratorPattern.API.Dominio;

namespace DecoratorPattern.API.Infra.Database;

public static class PopularDb
{
    public static void PopularDados(this IApplicationBuilder app, AppDbContexto appDbContexto)
    {
        if (appDbContexto.Clientes != null && appDbContexto.Clientes.Any()) return;

        var clientesFake = new Faker<Cliente>("pt_BR")
            .RuleFor(x => x.Nome, x => x.Person.FullName)
            .RuleFor(x => x.Email, x => x.Person.Email)
            .Generate(100);
        
        appDbContexto.AddRange(clientesFake);
        appDbContexto.SaveChanges();
    }
}