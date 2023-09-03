using AutoMapper;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private UsuarioContext _context;
    private IMapper _mapper;

    public FilmeController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);

    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> GetFilmes()
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes);
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmeById(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult PutFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }


    
    [HttpPatch("{id}")]
    public IActionResult PatchFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id ==id);
        if (filme == null) return NotFound();


        var filmeAtt = _mapper.Map<UpdateFilmeDto>(filme);
        if (!TryValidateModel(filmeAtt))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeAtt, filme);
        _context.SaveChanges();
        return NoContent();
    }
    

    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
