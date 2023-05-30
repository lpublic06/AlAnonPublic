using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
	public interface IGrupoService
	{
		public Task<RespuestaDto<List<GrupoDto>>> Obtener();
		public Task<RespuestaDto<GrupoDto>> Crear(GrupoDto GrupoDto);
	}
}
