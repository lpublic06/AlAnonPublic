using AlAnonAPI.Models.Dtos;

namespace AlAnonAPI.Repository.IRepository
{
    public interface IBoletinRepository
    {
        public Task<RespuestaDto<BoletinDto>> ObtenerBoletin();
        public Task<RespuestaDto<BoletinDto>> CrearEditarBoletin(BoletinDto nuevoBoletinDto);
    }
}
