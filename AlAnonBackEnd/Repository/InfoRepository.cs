using AlAnon.Data;
using AlAnon.Models;
using AlAnon.Models.Dtos;
using AlAnon.Repository.IRepository;
using AutoMapper;

namespace AlAnon.Repository
{
    public class InfoRepository : IInfoRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public InfoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RespuestaDto<InformacionDto>> CrearEditarInfo(InformacionDto nuevaInfoDto)
        {
            // Check if there is a valid info record
            var infoDeDb = _db.Informacion.FirstOrDefault(u => u.EsValida == true);
            var nuevaInfo = _mapper.Map<InformacionDto, Informacion>(nuevaInfoDto);
            var respuesta = new RespuestaDto<InformacionDto>();

            if (infoDeDb != null)
            {
                // Update to invalid
                infoDeDb.DiaCerrada = DateTime.Now;
                infoDeDb.EsValida = false;
                _db.Informacion.Update(infoDeDb);
                respuesta.Data = _mapper.Map<Informacion, InformacionDto>(infoDeDb);
            }

            // Create
            nuevaInfo.EsValida = true;
            nuevaInfo.DiaInsertada = DateTime.Now;
            nuevaInfo.NumeroIntegrupal = nuevaInfoDto.NumeroIntegrupal;
            nuevaInfo.UsuarioId = nuevaInfoDto.UsuarioId;
            _db.Informacion.Add(nuevaInfo);
            respuesta.Data = _mapper.Map<Informacion, InformacionDto>(nuevaInfo);

            await _db.SaveChangesAsync();

            return respuesta;
        }

        public async Task<RespuestaDto<InformacionDto>> ObtenerInfo()
        {
            var infoDeDbDto = _db.Informacion.FirstOrDefault(u => u.EsValida == true);
            if (infoDeDbDto != null)
            {
                return new RespuestaDto<InformacionDto>()
                {
                    Data = _mapper.Map<Informacion, InformacionDto>(infoDeDbDto)
                };
            }
            else
            {
                return new RespuestaDto<InformacionDto>()
                {
                    Exito = false,
                    Data = new InformacionDto(),
                };
            }
        }
    }
}
