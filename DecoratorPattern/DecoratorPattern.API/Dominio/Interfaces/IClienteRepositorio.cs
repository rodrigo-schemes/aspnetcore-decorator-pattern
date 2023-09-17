namespace DecoratorPattern.API.Dominio.Interfaces;

public interface IClienteRepositorio
{
    Task<Cliente?> ObterPorIdAsync(int id);
}