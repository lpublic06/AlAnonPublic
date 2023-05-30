using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlAnonAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class InicioController : ControllerBase
	{
		private readonly IInicioRepository _inicioRepository;
		public InicioController(IInicioRepository InicioRepository)
		{
			_inicioRepository = InicioRepository;
		}
		[HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            return Ok(await _inicioRepository.ObtenerInicio());
        }
		[HttpPost("Create")]
        public async Task<IActionResult> Crear([FromBody] InicioDto inicioDto)
        {
            var result = await _inicioRepository.CrearEditarInicio(inicioDto);
            return Ok(result);
        }
    }
}
