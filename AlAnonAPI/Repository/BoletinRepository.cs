using AlAnonAPI.Data;
using AlAnonAPI.Models;
using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Repository.IRepository;
using AutoMapper;

namespace AlAnonAPI.Repository
{
    public class BoletinRepository : IBoletinRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public BoletinRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RespuestaDto<BoletinDto>> CrearEditarBoletin(BoletinDto nuevoBoletinDto)
        {
            // Check if there is a valid boletin record
            var BoletinDeDb = _db.Boletin.FirstOrDefault(u => u.EsValida == true);
            var nuevoBoletin = _mapper.Map<BoletinDto, Boletin>(nuevoBoletinDto);
            var respuesta = new RespuestaDto<BoletinDto>();

            if (BoletinDeDb != null && BoletinDeDb.Id == nuevoBoletinDto.Id)
            {
                // Update
                BoletinDeDb.EsValida = true;
                BoletinDeDb.Pagina1 = nuevoBoletinDto.Pagina1;
                BoletinDeDb.Pagina2 = nuevoBoletinDto.Pagina2;
                BoletinDeDb.DiaDeBoletin = nuevoBoletinDto.DiaDeBoletin;
                _db.Boletin.Update(BoletinDeDb);
                respuesta.Data = _mapper.Map<Boletin, BoletinDto>(BoletinDeDb);
            }
            else
            {
                // Deactivate previous
                if (BoletinDeDb != null)
                {
                    BoletinDeDb.EsValida = false;
                    _db.Boletin.Update(BoletinDeDb);
                }

                // Create
                nuevoBoletin.EsValida = true;
                _db.Boletin.Add(nuevoBoletin);
                respuesta.Data = _mapper.Map<Boletin, BoletinDto>(nuevoBoletin);
            }
            await _db.SaveChangesAsync();

            return respuesta;
        }

        public async Task<RespuestaDto<BoletinDto>> ObtenerBoletin()
        {
            var BoletinDeDbDto = _mapper.Map<Boletin, BoletinDto>(_db.Boletin.FirstOrDefault(u => u.EsValida == true));
            if (BoletinDeDbDto != null)
            {
                return new RespuestaDto<BoletinDto>()
                {
                    Data = BoletinDeDbDto
                };
            }
            else
            {
                return new RespuestaDto<BoletinDto>()
                {
                    Exito = false,
                    Data = new BoletinDto(),
                };
            }
        }
    }
}
