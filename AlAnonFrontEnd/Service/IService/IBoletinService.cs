using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
	public interface IBoletinService
	{
		public Task<RespuestaDto<BoletinDto>> Obtener();
	}
}
