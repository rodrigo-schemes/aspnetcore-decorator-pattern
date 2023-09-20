using DecoratorPattern.API.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.API.Controllers;

[Route("cliente")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ClienteController(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterCliente(int id)
    {
        var clientes = await _clienteRepositorio.ObterPorIdAsync(id);

        if (clientes == null) return NotFound();
        
        return Ok(clientes);
    }
}