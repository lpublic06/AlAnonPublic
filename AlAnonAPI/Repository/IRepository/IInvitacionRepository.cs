using AlAnonAPI.Models.Dtos;

namespace AlAnonAPI.Repository.IRepository
{
    public interface IInvitacionRepository
    {
        public Task<RespuestaDto<InvitacionDto>> CrearEditarInvitacion(InvitacionDto nuevaInvitacionDto);
        public Task<RespuestaDto<List<InvitacionDto>>> BorrarInvitacion(int idDeInvitacion);
        public Task<RespuestaDto<InvitacionDto>> ObtenerInvitacion(int idDeInvitacion);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitaciones();
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDelMes(string firstDayOfMonth);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesActuales(string today);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesPasadas(string today);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDelaSemana(string today);
    }
}
