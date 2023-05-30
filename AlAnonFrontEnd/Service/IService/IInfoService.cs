using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
	public interface IInfoService
	{
		public Task<RespuestaDto<InformacionDto>> Obtener();
		public Task<RespuestaDto<InformacionDto>> Crear(InformacionDto InfoDto);
	}
}
