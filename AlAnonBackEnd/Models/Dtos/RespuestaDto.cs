namespace AlAnon.Models.Dtos
{
    public class RespuestaDto<T>
    {
        public bool Exito { get; set; } = true;
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
