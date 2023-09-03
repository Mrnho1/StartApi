using Microsoft.EntityFrameworkCore;
using ProjetoApi.Models;

namespace FilmesAPI.Data;


public class UsuarioContext : DbContext
{
    public UsuarioContext(DbContextOptions<UsuarioContext> opts)
        : base(opts)
    {

    }

    public DbSet <Usuario> Usuarios { get; set; }
    public DbSet<Filme> Filmes { get; set; }

}
