using AlAnon.Data;
using AlAnon.Models;
using AlAnon.Models.Dtos;
using AlAnon.Repository.IRepository;
using AutoMapper;

namespace AlAnon.Repository
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public DocumentoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RespuestaDto<List<DocumentoDto>>> BorrarDocumento(int idDeDocumento)
        {
            // Look for invitation by id
            var documentoDeDb = _db.Documentos.FirstOrDefault(r => r.Id == idDeDocumento);
            if (documentoDeDb != null)
            {
                _db.Documentos.Remove(documentoDeDb);
                await _db.SaveChangesAsync();

                // Return a full list
                return new RespuestaDto<List<DocumentoDto>>()
                {
                    Data = _mapper.Map<IEnumerable<Documento>, IEnumerable<DocumentoDto>>(_db.Documentos).ToList()
                };
            }

            // If group doesn't exist
            return new RespuestaDto<List<DocumentoDto>>()
            {
                Error = "Documento no existe",
                Exito = false
            };
        }

        public async Task<RespuestaDto<DocumentoDto>> CrearDocumento(DocumentoDto DocumentoNuevo)
        {
            //Check if Document exists?
            var nuevoDocumento = _mapper.Map<DocumentoDto, Documento>(DocumentoNuevo);

            if (nuevoDocumento != null)
            {
                var nuevoDocumentoDeDb = _db.Documentos.FirstOrDefault(r => r.Id == nuevoDocumento.Id);
                if (nuevoDocumentoDeDb != null)
                {
                    // Edit Invitation
                    nuevoDocumentoDeDb.DocumentPath = nuevoDocumento.DocumentPath;
                    nuevoDocumentoDeDb.ContentType = nuevoDocumento.ContentType;
                    nuevoDocumentoDeDb.Nombre = nuevoDocumento.Nombre;

                    _db.Documentos.Update(nuevoDocumentoDeDb);
                    await _db.SaveChangesAsync();

                    return new RespuestaDto<DocumentoDto>()
                    {
                        Data = _mapper.Map<Documento, DocumentoDto>(nuevoDocumentoDeDb)
                    };
                }

                // Insert invitation
                _db.Documentos.Add(nuevoDocumento);
                await _db.SaveChangesAsync();

                return new RespuestaDto<DocumentoDto>()
                {
                    Data = _mapper.Map<Documento, DocumentoDto>(nuevoDocumento)
                };
            }

            // Invitation is null
            return new RespuestaDto<DocumentoDto>()
            {
                Error = "Error Creando Documento",
                Exito = false,
                Data = DocumentoNuevo
            };
        }

        public async Task<RespuestaDto<List<DocumentoDto>>> ObtenerDocumentos()
        {
            var documentoDeDbDto = _mapper.Map<IEnumerable<Documento>, IEnumerable<DocumentoDto>>(_db.Documentos).ToList() ;
            if (documentoDeDbDto != null)
            {
                return new RespuestaDto<List<DocumentoDto>>()
                {
                    Data = documentoDeDbDto
                };
            }
            else
            {
                return new RespuestaDto<List<DocumentoDto>>()
                {
                    Exito = false,
                    Data = new List<DocumentoDto>(),
                };
            }
        }
    }
}
