using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlAnonAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class GrupoController : ControllerBase
	{
		private readonly IGrupoRepository _GrupoRepository;
		public GrupoController(IGrupoRepository GrupoRepository)
		{
			_GrupoRepository = GrupoRepository;
		}

		[HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            return Ok(await _GrupoRepository.ObtenerTodosLosGrupos());
        }

        [HttpGet("ObtenerPorId{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            return Ok(await _GrupoRepository.ObtenerGrupo(id));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] GrupoDto GrupoDto)
        {
            var result = await _GrupoRepository.CrearEditarGrupo(GrupoDto);
            return Ok(result);
        }
    }
}
