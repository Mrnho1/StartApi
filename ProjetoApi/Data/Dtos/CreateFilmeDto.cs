
using System.ComponentModel.DataAnnotations;

namespace ProjetoApi.Data.Dtos;

public class CreateFilmeDto
{
    [Required] public string Title { get; set; }
    [Required] public string ReleaseYear { get; set; }
    [Required] public string Image { get; set; }
    [Required] public string Genre { get; set; }
    [Required] public string Actors { get; set; }
    [Required] public float Rating { get; set; }
    [Required] public string Iframe { get; set; }
    [Required] public Boolean favorito { get; set; }
    [Required] public string Sinopse { get; set; }
    [Required] public string Duracao { get; set; }
    [Required] public string Classificacao { get; set; }
    [Required] public string TipoConteudo { get; set; }
}
