using System.ComponentModel.DataAnnotations;

namespace ProjetoApi.Models;

public class Pedido
{
    [Key]
    [Required]
    public int Id { get; set; }

    public float ValorTotal { get; set; }

    public DateTime DataPedido { get; set; }

}
