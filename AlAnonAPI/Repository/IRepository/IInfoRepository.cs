using AlAnonAPI.Models.Dtos;

namespace AlAnonAPI.Repository.IRepository
{
    public interface IInfoRepository
    {
        public Task<RespuestaDto<InformacionDto>> ObtenerInfo();
        public Task<RespuestaDto<InformacionDto>> CrearEditarInfo(InformacionDto nuevaInfoDto);
    }
}
