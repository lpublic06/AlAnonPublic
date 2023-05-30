using AlAnonAPI.Data;
using AlAnonAPI.Models;
using AlAnonAPI.Models.Dtos;
using AutoMapper;

namespace AlAnonAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Grupo, GrupoDto>().ReverseMap();
            CreateMap<Informacion, InformacionDto>().ReverseMap();
            CreateMap<ApplicationUser, UsuarioDto>().ReverseMap();
            CreateMap<Inicio, InicioDto>().ReverseMap();
            CreateMap<CalendarioEvento, CalendarioEventoDto>().ReverseMap();
            CreateMap<Boletin,BoletinDto>().ReverseMap();
            CreateMap<Documento, DocumentoDto>().ReverseMap();
            CreateMap<Invitacion, InvitacionDto>().ReverseMap();
        }
    }
}
