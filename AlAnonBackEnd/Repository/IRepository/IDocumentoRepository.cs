using AlAnon.Data;
using AlAnon.Models.Dtos;

namespace AlAnon.Repository.IRepository
{
    public interface IDocumentoRepository
    {
        public Task<RespuestaDto<List<DocumentoDto>>> ObtenerDocumentos();
        public Task<RespuestaDto<List<DocumentoDto>>> BorrarDocumento(int idDeDocumento);
        public Task<RespuestaDto<DocumentoDto>> CrearDocumento(DocumentoDto DocumentoNuevo);
    }
}
