using AlAnonFront.Models.Dtos;
using AlAnonFront.Service.IService;
using Newtonsoft.Json;

namespace AlAnonFront.Service
{
	public class BoletinService : IBoletinService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string AlAnonBaseServerUrl;

        public BoletinService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            AlAnonBaseServerUrl = configuration.GetValue<string>("AlAnonBaseServerUrl");
        }


        public async Task<RespuestaDto<BoletinDto>> Obtener()
        {
            var response = await _httpClient.GetAsync("/api/Boletin/Obtener");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<BoletinDto>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<BoletinDto>();
            respuestaError.Error = "Error en BoletinService: Could not get api/Boletin/Obtener";
            respuestaError.Exito = false;
            return respuestaError;
        }
    }
}
