using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
	public interface IInicioService
	{
		public Task<RespuestaDto<InicioDto>> Obtener();
		public Task<RespuestaDto<InicioDto>> Crear(InicioDto inicioDto);
	}
}
