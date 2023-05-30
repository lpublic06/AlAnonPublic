using AlAnon.Data;
using AlAnon.Models;
using AlAnon.Models.Dtos;
using AlAnon.Repository.IRepository;
using AutoMapper;

namespace AlAnon.Repository
{
    public class InicioRepository : IInicioRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public InicioRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RespuestaDto<InicioDto>> CrearEditarInicio(InicioDto nuevoInicioDto)
        {
            // Check if there is a valid info record
            var inicioDeDb = _db.Inicio.FirstOrDefault(u => u.EsValida == true);
            var nuevoInicio = _mapper.Map<InicioDto, Inicio>(nuevoInicioDto);
            var respuesta = new RespuestaDto<InicioDto>();

            if (inicioDeDb != null)
            {
                // Update
                inicioDeDb.EsValida = true;
                inicioDeDb.DiaInsertada = DateTime.Now;
                inicioDeDb.Titulo = nuevoInicioDto.Titulo;
                inicioDeDb.ParrafoPrincipal = nuevoInicioDto.ParrafoPrincipal;
                inicioDeDb.ImagenDeInicio = nuevoInicioDto.ImagenDeInicio;
                inicioDeDb.Posicion = nuevoInicioDto.Posicion;
                inicioDeDb.ImageFit = nuevoInicioDto.ImageFit;
                inicioDeDb.ImageHeight = nuevoInicioDto.ImageHeight;
                inicioDeDb.ImageWidth = nuevoInicioDto.ImageWidth;
                inicioDeDb.ImagePosition = nuevoInicioDto.ImagePosition;
                inicioDeDb.ImagenDeInicioLogo = nuevoInicioDto.ImagenDeInicioLogo;
                inicioDeDb.ImageFitLogo = nuevoInicioDto.ImageFitLogo;
                inicioDeDb.ImageHeightLogo = nuevoInicioDto.ImageHeightLogo;
                inicioDeDb.ImageWidthLogo = nuevoInicioDto.ImageWidthLogo;
                inicioDeDb.ImagePositionLogo = nuevoInicioDto.ImagePositionLogo;
                _db.Inicio.Update(inicioDeDb);
                respuesta.Data = _mapper.Map<Inicio, InicioDto>(inicioDeDb);
            }
            else
            {
                // Create
                nuevoInicio.EsValida = true;
                nuevoInicio.DiaInsertada = DateTime.Now;
                nuevoInicio.Titulo = nuevoInicioDto.Titulo;
                nuevoInicio.ParrafoPrincipal = nuevoInicioDto.ParrafoPrincipal;
                nuevoInicio.ImagenDeInicio = nuevoInicioDto.ImagenDeInicio;
                nuevoInicio.Posicion = nuevoInicioDto.Posicion;
                nuevoInicio.ImageFit = nuevoInicioDto.ImageFit;
                nuevoInicio.ImageHeight = nuevoInicioDto.ImageHeight;
                nuevoInicio.ImageWidth = nuevoInicioDto.ImageWidth;
                nuevoInicio.ImagePosition = nuevoInicioDto.ImagePosition;
                nuevoInicio.ImagenDeInicioLogo = nuevoInicioDto.ImagenDeInicioLogo;
                nuevoInicio.ImageFitLogo = nuevoInicioDto.ImageFitLogo;
                nuevoInicio.ImageHeightLogo = nuevoInicioDto.ImageHeightLogo;
                nuevoInicio.ImageWidthLogo = nuevoInicioDto.ImageWidthLogo;
                nuevoInicio.ImagePositionLogo = nuevoInicioDto.ImagePositionLogo;

                _db.Inicio.Add(nuevoInicio);
                respuesta.Data = _mapper.Map<Inicio, InicioDto>(nuevoInicio);
            }
            await _db.SaveChangesAsync();

            return respuesta;
        }

        public async Task<RespuestaDto<InicioDto>> ObtenerInicio()
        {
            var inicioDeDbDto = _mapper.Map<Inicio, InicioDto>(_db.Inicio.FirstOrDefault(u => u.EsValida == true));
            if (inicioDeDbDto != null)
            {
                return new RespuestaDto<InicioDto>()
                {
                    Data = inicioDeDbDto
                };
            }
            else
            {
                return new RespuestaDto<InicioDto>()
                {
                    Exito = false,
                    Data = new InicioDto(),
                };
            }
        }
    }
}
