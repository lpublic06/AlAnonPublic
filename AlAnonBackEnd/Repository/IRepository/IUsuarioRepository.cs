
using AlAnon.Data;
using AlAnon.Models.Dtos;

namespace AlAnon.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        public Task<RespuestaDto<List<UsuarioDto>>> ObtenerUsuarios();
        public Task<RespuestaDto<UsuarioDto>> DarPermiso(string id, string permiso);
        public Task<RespuestaDto<UsuarioDto>> QuitarPermiso(string id, string permiso);
    }
}
