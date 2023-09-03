using System.ComponentModel.DataAnnotations;

namespace ProjetoApi.Data.Dtos;

public class ReadFilmeDto
{
     public string Title { get; set; }
     public string ReleaseYear { get; set; }
     public string Image { get; set; }
    public string Genre { get; set; }
    public string Actors { get; set; }
    public float Rating { get; set; }
    public string Iframe { get; set; }
    public Boolean favorito { get; set; }
    public string Sinopse { get; set; }
    public string Duracao { get; set; }
    public string Classificacao { get; set; }
    public string TipoConteudo { get; set; }
}
