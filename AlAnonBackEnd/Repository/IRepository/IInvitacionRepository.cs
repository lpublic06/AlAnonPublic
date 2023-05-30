using AlAnon.Models.Dtos;

namespace AlAnon.Repository.IRepository
{
    public interface IInvitacionRepository
    {
        public Task<RespuestaDto<InvitacionDto>> CrearEditarInvitacion(InvitacionDto nuevaInvitacionDto);
        public Task<RespuestaDto<List<InvitacionDto>>> BorrarInvitacion(int idDeInvitacion);
        public Task<RespuestaDto<InvitacionDto>> ObtenerInvitacion(int idDeInvitacion);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitaciones();
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDelMes(DateTime firstDayOfMonth);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesActuales(DateTime today);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesPasadas(DateTime today);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDelaSemana(DateTime today);
    }
}
