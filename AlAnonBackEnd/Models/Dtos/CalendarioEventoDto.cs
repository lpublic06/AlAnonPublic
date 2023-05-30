namespace AlAnon.Models.Dtos
{
    public class CalendarioEventoDto
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Evento { get; set; }
        public string Lugar { get; set; }
        public DateTime? FechaEntera { get; set; } = DateTime.Now;
        public string UsuarioId { get; set; } = "46d97bc7-620f-4498-84fb-e22a36328540";
    }
}
