using AlAnon.Models.Dtos;

namespace AlAnon.Repository.IRepository
{
    public interface IBoletinRepository
    {
        public Task<RespuestaDto<BoletinDto>> ObtenerBoletin();
        public Task<RespuestaDto<BoletinDto>> CrearEditarBoletin(BoletinDto nuevoBoletinDto);
    }
}
