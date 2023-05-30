using MudBlazor;

namespace AlAnonFront.Models
{
	public class Inicio
	{
		public int id { get; set; }
		public string ImagenDeInicio { get; set; } = string.Empty;
        public string ImagenDeInicioLogo { get; set; } = string.Empty;
        public double Posicion { get; set; } = 50.0;
		public string Titulo { get; set; } = string.Empty;
		public string ParrafoPrincipal { get; set; } = string.Empty;
		public bool EsValida { get; set; }
		public DateTime DiaInsertada { get; set; }
		public DateTime DiaCerrada { get; set; }
		public string UsuarioId { get; set; } = string.Empty;
		public int ImageHeight { get; set; } = 300;
		public int ImageWidth { get; set; } = 300;
        public ObjectPosition ImagePosition { get; set; } = ObjectPosition.Center;
        public ObjectFit ImageFit { get; set; } = ObjectFit.Cover;
        public int ImageHeightLogo { get; set; } = 300;
        public int ImageWidthLogo { get; set; } = 300;
        public ObjectPosition ImagePositionLogo { get; set; } = ObjectPosition.Center;
        public ObjectFit ImageFitLogo { get; set; } = ObjectFit.Cover;
    }
}
