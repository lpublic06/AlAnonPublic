using System.ComponentModel.DataAnnotations;

namespace AlAnon.Models
{
	public class Informacion
	{
		[Key]
		public int Id { get; set; }
		public string NumeroIntegrupal { get; set; }
		public bool EsValida { get; set; }
		public DateTime DiaInsertada { get; set; }
		public DateTime DiaCerrada { get; set; }
		public string UsuarioId { get; set; } = string.Empty;
	}
}
