using AlAnonFront.Models.Dtos;
using AlAnonFront.Service.IService;
using Newtonsoft.Json;

namespace AlAnonFront.Service
{
	public class InicioService : IInicioService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string AlAnonBaseServerUrl;

        public InicioService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            AlAnonBaseServerUrl = configuration.GetValue<string>("AlAnonBaseServerUrl");
        }

        public Task<RespuestaDto<InicioDto>> Crear(InicioDto inicioDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<InicioDto>> Obtener()
        {
            var response = await _httpClient.GetAsync("/api/Inicio/Obtener");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<InicioDto>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<InicioDto>();
            respuestaError.Error = "Error en InicioService: Could not get api/Inicio/Obtener";
            respuestaError.Exito = false;
            return respuestaError;
        }
    }
}
