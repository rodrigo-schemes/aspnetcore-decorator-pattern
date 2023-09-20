using DecoratorPattern.API.Dominio;
using DecoratorPattern.API.Dominio.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace DecoratorPattern.API.Infra.Database.Repositorios;

public class ClienteCacheRepositorio : IClienteRepositorio
{
    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly IMemoryCache _memoryCache;

    public ClienteCacheRepositorio(IClienteRepositorio clienteRepositorio, 
        IMemoryCache memoryCache)
    {
        _clienteRepositorio = clienteRepositorio;
        _memoryCache = memoryCache;
    }

    public async Task<Cliente?> ObterPorIdAsync(int id)
    {
        var chave = $"cliente-{id}";
        
        return await _memoryCache.GetOrCreateAsync(chave, async cacheEntry =>
        {
            cacheEntry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _clienteRepositorio.ObterPorIdAsync(id);
        });
    }
}