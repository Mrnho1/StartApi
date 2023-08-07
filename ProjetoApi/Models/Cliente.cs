using System.ComponentModel.DataAnnotations;

namespace ProjetoApi.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Nome { get; set; }

    public string Endereco { get; set; } 




}
