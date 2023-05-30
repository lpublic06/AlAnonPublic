using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
	public interface ICalendarioService
	{
		public Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerActuales();
        public Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerPasados();
        public Task<RespuestaDto<CalendarioEventoDto>> Crear(CalendarioEventoDto CalendarioDto);
	}
}
