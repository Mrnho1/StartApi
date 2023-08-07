using AutoMapper;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Models;

namespace ProjetoApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, ReadClienteDto>();
    }
}
