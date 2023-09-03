using System.ComponentModel.DataAnnotations;

namespace ProjetoApi.Models;

public class Usuario
{
    [Key] [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string UserName { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string ConfirmPassword { get; set; }
    [Required] public string Type { get; set; }
}
