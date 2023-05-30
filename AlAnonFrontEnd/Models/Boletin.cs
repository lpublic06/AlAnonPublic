namespace AlAnonFront.Models
{
    public class Boletin
    {
        public int Id { get; set; }
        public string Pagina1 { get; set; }
        public string Pagina2 { get; set; }
        public DateTime DiaDeBoletin { get; set; }
        public bool EsValida { get; set; }
    }
}
