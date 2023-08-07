using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Data;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Models;

namespace ProjetoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{

    private ClienteContext _context;
    private IMapper _mapper;

    public ClienteController(ClienteContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddCliente([FromBody] CreateClienteDto clienteDto)
    {
        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id}, clienteDto);
    }

    [HttpGet]
    public IEnumerable<ReadClienteDto> GetCliente()
    {
        return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
       var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if(cliente ==  null) return NotFound();
        var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
        return Ok(clienteDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCliente(int id, [FromBody] UpdateClienteDto clienteDto)
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if(cliente == null) return NotFound();
        _mapper.Map(clienteDto, cliente);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteCliente( int id ) 
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();
        _context.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}
