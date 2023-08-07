
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Models;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Data;

namespace ProjetoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private ClienteContext _context;
    private IMapper _mapper;

    public PedidoController(ClienteContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult PostPedido ([FromBody] CreatePedidoDto pedidoDto)
    {
        Pedido pedido = _mapper.Map<Pedido>(pedidoDto);
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPedidosById), new { id = pedido.Id }, pedidoDto);
    }

    [HttpGet]
    public IEnumerable<ReadPedidoDto> GetPedidos()
    {
        return _mapper.Map<List<ReadPedidoDto>>(_context.Pedidos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetPedidosById(int id)
    {
        var pedido = _context.Clientes.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido == null) return NotFound();
        var pedidoDto = _mapper.Map<ReadPedidoDto>(pedido);
        return Ok(pedidoDto);
    }

    [HttpPut("{id}")]
    public IActionResult PutProduto(int id, [FromBody] UpdatePedidoDto pedidoDto)
    {
        var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido == null) return NotFound();
        _mapper.Map(pedidoDto, pedido);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaPedido(int id)
    {
        var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido == null) return NotFound();
        _context.Remove(pedido);
        _context.SaveChanges();
        return NoContent();
    }

}