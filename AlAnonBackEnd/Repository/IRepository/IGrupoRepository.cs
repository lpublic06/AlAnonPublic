
using AlAnon.Models.Dtos;

namespace AlAnon.Repository.IRepository
{
    public interface IGrupoRepository
    {
        public Task<RespuestaDto<GrupoDto>> CrearEditarGrupo(GrupoDto nuevoGrupoDto);

        public Task<RespuestaDto<List<GrupoDto>>> BorrarGrupo(int idDeGrupo);

        public Task<RespuestaDto<GrupoDto>> EditarGrupo(GrupoDto nuevoGrupoDto);

        public Task<RespuestaDto<GrupoDto>> ObtenerGrupo(int idDeGrupo);

        public Task<RespuestaDto<List<GrupoDto>>> ObtenerTodosLosGrupos();
    }
}
