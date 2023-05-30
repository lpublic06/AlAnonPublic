using AlAnonFront.Models.Dtos;
using AlAnonFront.Service.IService;
using Newtonsoft.Json;

namespace AlAnonFront.Service
{
	public class InfoService : IInfoService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string AlAnonBaseServerUrl;

        public InfoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            AlAnonBaseServerUrl = configuration.GetValue<string>("AlAnonBaseServerUrl");
        }

        public Task<RespuestaDto<InformacionDto>> Crear(InformacionDto InfoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<InformacionDto>> Obtener()
        {
            var response = await _httpClient.GetAsync("/api/Info/Obtener");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<InformacionDto>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<InformacionDto>();
            respuestaError.Error = "Error en InfoService: Could not get api/Info/Obtener";
            respuestaError.Exito = false;
            return respuestaError;
        }
    }
}
