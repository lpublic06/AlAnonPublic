namespace AlAnonFront.Models
{
    public class Respuesta<T>
    {
        public bool Exito { get; set; } = true;
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
