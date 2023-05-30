using System.ComponentModel.DataAnnotations;

namespace AlAnon.Models.Dtos
{
	public class InformacionDto
	{
		public int InfoId { get; set; }
		[Required]
		[DataType(DataType.PhoneNumber)]
		public string NumeroIntegrupal { get; set; } = "(000) 000-0000";
		public bool EsValida { get; set; }
		public DateTime DiaInsertada { get; set; }
		public DateTime DiaCerrada { get; set; }
		public string UsuarioId { get; set; } = string.Empty;
	}
}
