using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlAnonAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class CalendarioController : ControllerBase
	{
		private readonly ICalendarioRepository _CalendarioRepository;
		public CalendarioController(ICalendarioRepository CalendarioRepository)
		{
			_CalendarioRepository = CalendarioRepository;
		}

		[HttpGet("ObtenerActuales")]
        public async Task<IActionResult> ObtenerActuales()
        {
            return Ok(await _CalendarioRepository.ObtenerTodosLosCalendarioEventosActuales());
        }

        [HttpGet("ObtenerPasados")]
        public async Task<IActionResult> ObtenerPasados()
        {
            return Ok(await _CalendarioRepository.ObtenerTodosLosCalendarioEventosPasados());
        }

        [HttpGet("ObtenerPorId{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            return Ok(await _CalendarioRepository.ObtenerCalendarioEvento(id));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CalendarioEventoDto CalendarioDto)
        {
            var result = await _CalendarioRepository.CrearEditarCalendarioEvento(CalendarioDto);
            return Ok(result);
        }
    }
}
