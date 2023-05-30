using AlAnon.Data;
using AlAnon.Models;
using AlAnon.Models.Dtos;
using AutoMapper;

namespace AlAnon.Mapper
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
            CreateMap<Boletin, BoletinDto>().ReverseMap();
            CreateMap<Invitacion, InvitacionDto>().ReverseMap();
            CreateMap<Documento, DocumentoDto>().ReverseMap();
        }
    }
}
