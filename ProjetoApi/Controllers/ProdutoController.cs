using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Data;
using ProjetoApi.Models;

namespace ProjetoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private ClienteContext _context;
    private IMapper _mapper;

    public ProdutoController(ClienteContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult PostProduto([FromBody] CreateProdutoDto produtoDto)
    {
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produtoDto);
    }

    [HttpGet]
    public IEnumerable<ReadProdutoDto> GetProduto()
    {
        return _mapper.Map<List<ReadProdutoDto>>(_context.Produtos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetProdutosById(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
        return Ok(produtoDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
        _mapper.Map(produtoDto, produto);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteProduto(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        _context.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }


}
