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

        var clientes = new List<Cliente>();

        for (var cont = 0; cont < 10; cont++)
        {
            var clienteFake = new Faker("pt_BR").Person;
            
            clientes.Add(new Cliente
            {
                Nome = clienteFake.FullName,
                Email = clienteFake.Email
            });
        }
        
        appDbContexto.AddRange(clientes);
        appDbContexto.SaveChanges();
    }
}