using AlAnon.Data;
using AlAnon.Models;
using AlAnon.Models.Dtos;
using AlAnon.Repository.IRepository;
using AutoMapper;
using System.Globalization;

namespace AlAnon.Repository
{
    public class CalendarioRepository : ICalendarioRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CalendarioRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<RespuestaDto<List<CalendarioEventoDto>>> BorrarCalendarioEvento(int idDeCalendarioEvento)
        {
            // Look for Calendario Evento by id
            var calendarioEventoDeDb = _db.CalendarioEventos.FirstOrDefault(r => r.Id == idDeCalendarioEvento);
            if (calendarioEventoDeDb != null)
            {
                _db.CalendarioEventos.Remove(calendarioEventoDeDb);
                await _db.SaveChangesAsync();

                // Return a full list
                return new RespuestaDto<List<CalendarioEventoDto>>()
                {
                    Data = _mapper.Map<IEnumerable<CalendarioEvento>, IEnumerable<CalendarioEventoDto>>(_db.CalendarioEventos).ToList()
                };
            }

            // If group doesn't exist
            return new RespuestaDto<List<CalendarioEventoDto>>()
            {
                Error = "Calendario Evento no existe",
                Exito = false
            };
        }

        public async Task<RespuestaDto<CalendarioEventoDto>> CrearEditarCalendarioEvento(CalendarioEventoDto nuevoCalendarioEventoDto)
        {
            //Check if Calendar Event exists?
            var nuevoCalendarioEvento = _mapper.Map<CalendarioEventoDto, CalendarioEvento>(nuevoCalendarioEventoDto);

            var input = nuevoCalendarioEvento.FechaEntera.Value.ToString("dddd, MMMM dd yyyy");
            var format = "dddd, MMMM dd yyyy";

            var dt = DateTime.ParseExact(input, format, new CultureInfo("en-US"));

            var fecha = dt.ToString(format, new CultureInfo("es-ES"));

            if (nuevoCalendarioEvento != null)
            {
                var calendarioEventoDeDb = _db.CalendarioEventos.FirstOrDefault(r => r.Id == nuevoCalendarioEvento.Id);
                if (calendarioEventoDeDb != null)
                {
                    // Edit Calendar Event
                    calendarioEventoDeDb.Fecha = fecha;
                    calendarioEventoDeDb.Evento = nuevoCalendarioEventoDto.Evento;
                    calendarioEventoDeDb.Lugar = nuevoCalendarioEventoDto.Lugar;
                    calendarioEventoDeDb.FechaEntera = nuevoCalendarioEventoDto.FechaEntera;
                    calendarioEventoDeDb.Hora = nuevoCalendarioEventoDto.Hora;
                    calendarioEventoDeDb.UsuarioId = nuevoCalendarioEventoDto.UsuarioId;

                    _db.CalendarioEventos.Update(calendarioEventoDeDb);
                    await _db.SaveChangesAsync();

                    return new RespuestaDto<CalendarioEventoDto>()
                    {
                        Data = _mapper.Map<CalendarioEvento, CalendarioEventoDto>(calendarioEventoDeDb)
                    };
                }

                // Insert Calendar Event
                nuevoCalendarioEvento.Fecha = fecha;
                _db.CalendarioEventos.Add(nuevoCalendarioEvento);
                await _db.SaveChangesAsync();

                return new RespuestaDto<CalendarioEventoDto>()
                {
                    Data = _mapper.Map<CalendarioEvento, CalendarioEventoDto>(nuevoCalendarioEvento)
                };
            }

            // Group is null
            return new RespuestaDto<CalendarioEventoDto>()
            {
                Error = "Error Creando Calendario Evento Nuevo",
                Exito = false,
                Data = nuevoCalendarioEventoDto
            };
        }

        public Task<RespuestaDto<CalendarioEventoDto>> EditarCalendarioEvento(CalendarioEventoDto nuevoCalendarioEventoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<CalendarioEventoDto>> ObtenerCalendarioEvento(int idDeCalendarioEvento)
        {
            // Calendario Evento are greater than 0 id
            if (idDeCalendarioEvento > 0)
            {
                var calendarioEventoDeDb = _db.CalendarioEventos.FirstOrDefault(r => r.Id == idDeCalendarioEvento);
                if (calendarioEventoDeDb != null)
                {
                    return new RespuestaDto<CalendarioEventoDto>()
                    {
                        Data = _mapper.Map<CalendarioEvento, CalendarioEventoDto>(calendarioEventoDeDb)
                    };
                }
            }

            return new RespuestaDto<CalendarioEventoDto>()
            {
                Error = "Id de Calendario Evento no existe",
                Exito = false
            };
        }

        public async Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerRangoCalendarioEvento(DateTime diaDesde, DateTime diaHasta)
        {
            try
            {
                var calendarioEventosDeDb = _db.CalendarioEventos.Where(r => r.FechaEntera >= diaDesde && r.FechaEntera <= diaHasta).OrderBy(r => r.FechaEntera);
                if (calendarioEventosDeDb != null)
                {
                    return new RespuestaDto<List<CalendarioEventoDto>>()
                    {
                        Data = _mapper.Map<IEnumerable<CalendarioEvento>, IEnumerable<CalendarioEventoDto>>(calendarioEventosDeDb).ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new RespuestaDto<List<CalendarioEventoDto>>()
            {
                Data = new List<CalendarioEventoDto>(),
                Error = "No ay Calendario Eventos en esas fechas"
            };
        }

        public async Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerTodosLosCalendarioEventos()
        {
            var respuesta = new RespuestaDto<List<CalendarioEventoDto>>();
            try
            {
                respuesta.Data = _mapper.Map<IEnumerable<CalendarioEvento>, IEnumerable<CalendarioEventoDto>>(_db.CalendarioEventos.OrderBy(r => r.FechaEntera)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerTodosLosCalendarioEventosActuales(DateTime today)
        {
            var respuesta = new RespuestaDto<List<CalendarioEventoDto>>();
            // Trim today to date only
            today = today.AddHours(-today.Hour).AddMinutes(-today.Minute).AddSeconds(-today.Second - 1).AddMilliseconds(-today.Millisecond);
            try
            {
                respuesta.Data = _mapper.Map<IEnumerable<CalendarioEvento>, IEnumerable<CalendarioEventoDto>>(_db.CalendarioEventos.Where(r => r.FechaEntera >= today).OrderBy(r => r.FechaEntera)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerTodosLosCalendarioEventosPasados(DateTime today)
        {
            var respuesta = new RespuestaDto<List<CalendarioEventoDto>>();
            // Trim Now to date only
            today = today.AddHours(-today.Hour).AddMinutes(-today.Minute).AddSeconds(-today.Second - 1).AddMilliseconds(-today.Millisecond);
            try
            {
                respuesta.Data = _mapper.Map<IEnumerable<CalendarioEvento>, IEnumerable<CalendarioEventoDto>>(_db.CalendarioEventos.Where(r => r.FechaEntera < today).OrderBy(r => r.FechaEntera)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
    }
}
