using AlAnonFront.Models.Dtos;
using AlAnonFront.Service.IService;
using Newtonsoft.Json;

namespace AlAnonFront.Service
{
	public class CalendarioService : ICalendarioService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string AlAnonBaseServerUrl;

        public CalendarioService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            AlAnonBaseServerUrl = configuration.GetValue<string>("AlAnonBaseServerUrl");
        }

        public Task<RespuestaDto<CalendarioEventoDto>> Crear(CalendarioEventoDto CalendarioDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerActuales()
        {
            var response = await _httpClient.GetAsync("/api/Calendario/ObtenerActuales");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<List<CalendarioEventoDto>>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<List<CalendarioEventoDto>>();
            respuestaError.Error = "Error en CalendarioService: Could not get api/Calendario/ObtenerActuales";
            respuestaError.Exito = false;
            return respuestaError;
        }
        public async Task<RespuestaDto<List<CalendarioEventoDto>>> ObtenerPasados()
        {
            var response = await _httpClient.GetAsync("/api/Calendario/ObtenerPasados");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<List<CalendarioEventoDto>>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<List<CalendarioEventoDto>>();
            respuestaError.Error = "Error en CalendarioService: Could not get api/Calendario/ObtenerPasados";
            respuestaError.Exito = false;
            return respuestaError;
        }
    }
}
