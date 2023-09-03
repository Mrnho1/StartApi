using AutoMapper;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private UsuarioContext _context;
    private IMapper _mapper;

    public UsuarioController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostUser([FromBody] CreateUsuarioDto usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUserById), new { id = usuario.Id }, usuario);

    }

    [HttpGet]
    public IEnumerable<ReadUsuarioDto> GetUsuarios()
    {
        return _mapper.Map<List<ReadUsuarioDto>>(_context.Usuarios);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        if (usuario == null) return NotFound();
        var usuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
        return Ok(usuarioDto);
    }

    [HttpPut("{id}")]
    public IActionResult PutUsuario(int id, [FromBody] UpdateUsuarioDto usuarioDto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario =>usuario.Id == id);
        if(usuario == null) return NotFound();
        _mapper.Map(usuarioDto, usuario);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchUsuario(int id, JsonPatchDocument<UpdateUsuarioDto> patch) 
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
        if (usuario == null) return NotFound();


        var usarioAtt = _mapper.Map<UpdateUsuarioDto>(usuario);
        if (!TryValidateModel(usarioAtt))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(usarioAtt, usuario);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
        if (usuario == null) return NotFound();
        _context.Remove(usuario);
        _context.SaveChanges();
        return NoContent();
    }
}
