using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlAnonAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class BoletinController : ControllerBase
	{
		private readonly IBoletinRepository _BoletinRepository;
		public BoletinController(IBoletinRepository BoletinRepository)
		{
			_BoletinRepository = BoletinRepository;
		}
		[HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            return Ok(await _BoletinRepository.ObtenerBoletin());
        }
    }
}
