using Microsoft.EntityFrameworkCore;
using ProjetoApi.Models;

namespace ProjetoApi.Data;

public class ClienteContext : DbContext
{

    public ClienteContext(DbContextOptions<ClienteContext> opts):base(opts)
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<Produto> Produtos { get; set; }
}
