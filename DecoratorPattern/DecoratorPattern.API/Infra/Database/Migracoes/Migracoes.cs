using Microsoft.EntityFrameworkCore;

namespace DecoratorPattern.API.Infra.Database.Migracoes;

public static class Migracoes
{
    public static void AplicarMigracoes(this IApplicationBuilder app)
    {
        using var escopo = app.ApplicationServices.CreateScope();
        using var appDbContexto = escopo.ServiceProvider.GetRequiredService<AppDbContexto>();

        appDbContexto.Database.Migrate();
        app.PopularDados(appDbContexto);
    }
}