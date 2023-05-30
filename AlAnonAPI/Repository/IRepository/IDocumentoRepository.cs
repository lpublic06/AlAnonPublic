
using AlAnonAPI.Models.Dtos;

namespace AlAnonAPI.Repository.IRepository
{
    public interface IDocumentoRepository
    {

        public Task<RespuestaDto<List<DocumentoDto>>> BorrarDocumento(int idDeDocumento);
        public Task<RespuestaDto<DocumentoDto>> CrearDocumento(DocumentoDto DocumentoNuevo);
        public Task<RespuestaDto<List<DocumentoDto>>> ObtenerDocumentos();

    }
}
