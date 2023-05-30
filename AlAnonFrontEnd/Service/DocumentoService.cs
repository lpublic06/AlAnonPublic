using AlAnonFront.Models.Dtos;
using AlAnonFront.Service.IService;
using Newtonsoft.Json;
using System.Net.Http;

namespace AlAnonFront.Service
{
    public class DocumentoService : IDocumentoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string AlAnonBaseServerUrl;

        public DocumentoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            AlAnonBaseServerUrl = configuration.GetValue<string>("AlAnonBaseServerUrl");
        }

        public async Task<RespuestaDto<List<DocumentoDto>>> Obtener()
        {
            var response = await _httpClient.GetAsync("/api/Documento/Obtener");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<List<DocumentoDto>>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<List<DocumentoDto>>();
            respuestaError.Error = "Error en DocumentoService: Could not get api/Documento/Obtener";
            respuestaError.Exito = false;
            return respuestaError;
        }
    }
}
