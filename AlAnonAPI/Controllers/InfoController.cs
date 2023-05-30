using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlAnonAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class InfoController : ControllerBase
	{
		private readonly IInfoRepository _InfoRepository;
		public InfoController(IInfoRepository InfoRepository)
		{
			_InfoRepository = InfoRepository;
		}
		[HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            return Ok(await _InfoRepository.ObtenerInfo());
        }
		[HttpPost("Create")]
        public async Task<IActionResult> Crear([FromBody] InformacionDto InfoDto)
        {
            var result = await _InfoRepository.CrearEditarInfo(InfoDto);
            return Ok(result);
        }
    }
}
