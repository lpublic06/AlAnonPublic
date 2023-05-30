using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
    public interface IDocumentoService
    {
        public Task<RespuestaDto<List<DocumentoDto>>> Obtener();
    }
}
