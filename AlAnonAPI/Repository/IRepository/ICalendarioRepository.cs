using AlAnonAPI.Models.Dtos;

namespace AlAnonAPI.Repository.IRepository
{
    public interface ICalendarioRepository
    {
        public Task<RespuestaDto<CalendarioEventoDto>> CrearEditarCalendarioEvento(CalendarioEventoDto nuevoCalendarioEventoDto);

        public Task<RespuestaDto<List<CalendarioEventoDto>>> BorrarCalendarioEvento(int idDeCalendarioEvento);

        public Task<RespuestaDto<CalendarioEventoDto>> EditarCalendarioEvento(CalendarioEventoDto nuevoCalendarioEventoDto);

        public Task<RespuestaDto<CalendarioEventoDto>> ObtenerCalendarioEvento(int idDeCalendarioEvento);

        public Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerRangoCalendarioEvento(DateTime diaDesde, DateTime diaHasta);
        public Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerTodosLosCalendarioEventos();

        public Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerTodosLosCalendarioEventosActuales();
        public Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerTodosLosCalendarioEventosPasados();
    }
}
