using System.ComponentModel.DataAnnotations;

namespace ProjetoApi.Data.Dtos;

public class ReadUsuarioDto
{
     public string Name { get; set; }
     public string UserName { get; set; }
     public string Password { get; set; }
     public string ConfirmPassword { get; set; }
    public string Type { get; set; }
}
