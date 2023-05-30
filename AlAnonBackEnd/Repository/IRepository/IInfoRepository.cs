using AlAnon.Models.Dtos;

namespace AlAnon.Repository.IRepository
{
    public interface IInfoRepository
    {
        public Task<RespuestaDto<InformacionDto>> ObtenerInfo();
        public Task<RespuestaDto<InformacionDto>> CrearEditarInfo(InformacionDto nuevaInfoDto);
    }
}
