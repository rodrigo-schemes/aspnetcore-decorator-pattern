using DecoratorPattern.API.Dominio;
using DecoratorPattern.API.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DecoratorPattern.API.Infra.Database.Repositorios;

public class ClienteRepositorio : IClienteRepositorio
{
    private readonly AppDbContexto _appDbContexto;

    public ClienteRepositorio(AppDbContexto appDbContexto)
    {
        _appDbContexto = appDbContexto;
    }

    public async Task<Cliente?> ObterPorIdAsync(int id)
    {
        return await _appDbContexto
            .Set<Cliente>()
            .FirstOrDefaultAsync(cliente => cliente.ClienteId == id);
    }
}