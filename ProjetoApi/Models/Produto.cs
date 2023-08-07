using System.ComponentModel.DataAnnotations;

namespace ProjetoApi.Models;

public class Produto
{
    [Key]
    [Required]
    public int Id { get; set; }

    public string NomeProduto { get; set; }

    public float ValorProduto { get; set; }

    public string Categoria { get; set; }
}
