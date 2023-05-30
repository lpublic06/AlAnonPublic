using AlAnon.Models.Dtos;

namespace AlAnon.Repository.IRepository
{
    public interface IInicioRepository
    {
        public Task<RespuestaDto<InicioDto>> ObtenerInicio();
        public Task<RespuestaDto<InicioDto>> CrearEditarInicio(InicioDto nuevoInicioDto);
    }
}
