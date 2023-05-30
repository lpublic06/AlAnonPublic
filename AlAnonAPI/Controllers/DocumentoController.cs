using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlAnonAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class DocumentoController : ControllerBase
	{
		private readonly IDocumentoRepository _DocumentoRepository;
		public DocumentoController(IDocumentoRepository DocumentoRepository)
		{
			_DocumentoRepository = DocumentoRepository;
		}

        [HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            return Ok(await _DocumentoRepository.ObtenerDocumentos());
        }
    }
}
