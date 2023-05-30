using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlAnonFront.Models
{
    public class Grupo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoDeJunta { get; set; }
        public string Area { get; set; }
        public string Direccion { get; set; } 
        public string Dias { get; set; }
        public string Horas { get; set; }
        public string Alateen { get; set; }
        public string Numero { get; set; }
        public string NumeroDeSala { get; set; }
        public string Contraseña { get; set; }
        public string Notas { get; set; }
    }
}
