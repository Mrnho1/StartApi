using AutoMapper;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Models;

namespace ProjetoApi.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<Produto, ReadProdutoDto>();
        CreateMap<CreateProdutoDto, Produto>();
    }
}
