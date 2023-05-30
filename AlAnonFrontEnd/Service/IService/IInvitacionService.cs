using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
    public interface IInvitacionService
    {
        public Task<RespuestaDto<InvitacionDto>> ObtenerInvitacion(int idDeInvitacion);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitaciones();
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDelMes(DateTime firstDayOfMonth);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesActuales(string today);
        public Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDeLaSemana(string today);
    }
}
