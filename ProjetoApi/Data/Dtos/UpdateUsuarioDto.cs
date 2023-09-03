using System.ComponentModel.DataAnnotations;

namespace ProjetoApi.Data.Dtos;

public class UpdateUsuarioDto
{
    [Required] public string Name { get; set; }
    [Required] public string UserName { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string ConfirmPassword { get; set; }
    [Required] public string Type { get; set; }
}
