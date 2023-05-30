namespace AlAnonFront.Models
{
    public class Invitacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ImagePath { get; set; }
        public string Alt { get; set; }
        public string Fecha { get; set; }
        public DateTime? FechaEntera { get; set; } = DateTime.Now;
    }
}
