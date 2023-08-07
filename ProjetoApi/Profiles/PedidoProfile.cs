using AutoMapper;
using ProjetoApi.Data.Dtos;
using ProjetoApi.Models;

namespace ProjetoApi.Profiles;

public class PedidoProfile: Profile
{
    public PedidoProfile()
    {
        CreateMap<CreatePedidoDto, Pedido>();
        CreateMap<Pedido, ReadPedidoDto>();
        CreateMap<CreatePedidoDto, Pedido>();
    }
}
