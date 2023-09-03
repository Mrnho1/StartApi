using AutoMapper;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Models;

namespace ProjetoApi.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<UpdateUsuarioDto, Usuario>();
        CreateMap<Usuario, UpdateUsuarioDto>();
        CreateMap<Usuario, ReadUsuarioDto>();
    }
}
