using AlAnonFront.Models.Dtos;
using AlAnonFront.Service.IService;
using Newtonsoft.Json;

namespace AlAnonFront.Service
{
	public class GrupoService : IGrupoService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string AlAnonBaseServerUrl;

        public GrupoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            AlAnonBaseServerUrl = configuration.GetValue<string>("AlAnonBaseServerUrl");
        }

        public Task<RespuestaDto<GrupoDto>> Crear(GrupoDto GrupoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<List<GrupoDto>>> Obtener()
        {
            var response = await _httpClient.GetAsync("/api/Grupo/Obtener");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<List<GrupoDto>>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<List<GrupoDto>>();
            respuestaError.Error = "Error en GrupoService: Could not get api/Grupo/Obtener";
            respuestaError.Exito = false;
            return respuestaError;
        }
    }
}
