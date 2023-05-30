using AlAnonAPI.Models.Dtos;

namespace AlAnonAPI.Repository.IRepository
{
    public interface IInicioRepository
    {
        public Task<RespuestaDto<InicioDto>> ObtenerInicio();
        public Task<RespuestaDto<InicioDto>> CrearEditarInicio(InicioDto nuevoInicioDto);
    }
}
