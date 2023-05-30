namespace AlAnonFront.Models
{
    public class CalendarioEvento
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Evento { get; set; }
        public string Lugar { get; set;}
        public DateTime? FechaEntera { get; set; } = DateTime.Now;
        public string UsuarioId { get; set; }
    }
}
