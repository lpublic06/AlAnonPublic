using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlAnonAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class InvitacionController : ControllerBase
	{
		private readonly IInvitacionRepository _InvitacionRepository;
		public InvitacionController(IInvitacionRepository InvitacionRepository)
		{
			_InvitacionRepository = InvitacionRepository;
		}

        [HttpGet("ObtenerActuales")]
        public async Task<IActionResult> Obtener(string today)
        {
            return Ok(await _InvitacionRepository.ObtenerInvitacionesActuales(today));
        }

        [HttpGet("ObtenerActualesDeLaSemana")]
        public async Task<IActionResult> ObtenerActualesDeLaSemana(string today)
        {
            return Ok(await _InvitacionRepository.ObtenerInvitacionesDelaSemana(today));
        }
    }
}
