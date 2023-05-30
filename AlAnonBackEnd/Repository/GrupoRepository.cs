using AlAnon.Models.Dtos;
using AlAnon.Models;
using AlAnon.Repository.IRepository;
using AutoMapper;
using AlAnon.Data;

namespace AlAnon.Repository
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GrupoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<RespuestaDto<GrupoDto>> CrearEditarGrupo(GrupoDto nuevoGrupoDto)
        {
            //Check if group exists?
            var nuevoGrupo = _mapper.Map<GrupoDto, Grupo>(nuevoGrupoDto);

            if(nuevoGrupo != null)
            {
                var grupoDeDb = _db.Grupos.FirstOrDefault(r => r.Id == nuevoGrupo.Id);
                if(grupoDeDb != null)
                {
                    // Edit Group
                    grupoDeDb.TipoDeJunta = nuevoGrupo.TipoDeJunta;
                    grupoDeDb.Alateen = nuevoGrupo.Alateen;
                    grupoDeDb.Area = nuevoGrupo.Area;
                    grupoDeDb.Nombre = nuevoGrupo.Nombre;
                    grupoDeDb.Numero = nuevoGrupo.Numero;
                    grupoDeDb.NumeroDeSala = nuevoGrupo.NumeroDeSala;
                    grupoDeDb.Contraseña = nuevoGrupo.Contraseña;
                    grupoDeDb.Dias = nuevoGrupo.Dias;
                    grupoDeDb.Direccion = nuevoGrupo.Direccion;
                    grupoDeDb.Horas = nuevoGrupo.Horas;
                    grupoDeDb.Notas = nuevoGrupo.Notas;

                    _db.Grupos.Update(grupoDeDb);
                    await _db.SaveChangesAsync();

                    return new RespuestaDto<GrupoDto>()
                    {
                        Data = _mapper.Map<Grupo, GrupoDto>(grupoDeDb)
                    };
                }

                // Insert group
                _db.Grupos.Add(nuevoGrupo);
                await _db.SaveChangesAsync();

                return new RespuestaDto<GrupoDto>()
                {
                    Data = _mapper.Map<Grupo, GrupoDto>(nuevoGrupo)
                };
            }

            // Group is null
            return new RespuestaDto<GrupoDto>()
            {
                Error = "Error Creando GrupoDto a Grupo",
                Exito = false,
                Data = nuevoGrupoDto
            };
        }

        public async Task<RespuestaDto<List<GrupoDto>>> BorrarGrupo(int idDeGrupo)
        {
            // Look for grupo by id
            var grupoDeDb = _db.Grupos.FirstOrDefault(r => r.Id == idDeGrupo);
            if (grupoDeDb != null)
            {
                _db.Grupos.Remove(grupoDeDb);
                await _db.SaveChangesAsync();

                // Return a full list
                return new RespuestaDto<List<GrupoDto>>()
                {
                    Data = _mapper.Map<IEnumerable<Grupo>, IEnumerable<GrupoDto>>(_db.Grupos).ToList()
                };
            }

            // If group doesn't exist
            return new RespuestaDto<List<GrupoDto>>()
            {
                Error = "Grupo no existe",
                Exito = false
            };
        }

        public Task<RespuestaDto<GrupoDto>> EditarGrupo(GrupoDto nuevoGrupoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<GrupoDto>> ObtenerGrupo(int idDeGrupo)
        {
            // Groups are greater than 0 id
            if(idDeGrupo > 0)
            {
                var grupoDeDb = _db.Grupos.FirstOrDefault(r => r.Id == idDeGrupo);
                if(grupoDeDb != null)
                {
                    return new RespuestaDto<GrupoDto>()
                    {
                        Data = _mapper.Map<Grupo, GrupoDto>(grupoDeDb)
                    };
                }
            }

            return new RespuestaDto<GrupoDto>()
            {
                Error = "Id de grupo no existe",
                Exito = false
            };
        }

        public async Task<RespuestaDto<List<GrupoDto>>> ObtenerTodosLosGrupos()
        {
            var respuesta = new RespuestaDto<List<GrupoDto>>();
            try
            {
                respuesta.Data = _mapper.Map<IEnumerable<Grupo>, IEnumerable<GrupoDto>>(_db.Grupos).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
    }
}
