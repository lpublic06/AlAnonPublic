
using System.ComponentModel.DataAnnotations;

namespace AlAnonFront.Models.Dtos
{
    public class GrupoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del grupo es necesario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El tipo del grupo es necesario: Presencial, Hibrida, o Electronica")]
        public string TipoDeJunta { get; set; }
        public string Area { get; set; } 
        public string Direccion { get; set; } = "";
        [Required (ErrorMessage = "El dia que se junta el grupo es necesario")]
        public string Dias { get; set; }
        [Required (ErrorMessage = "La hora de la junta es necesaria")]
        public string Horas { get; set; }
        [Required(ErrorMessage = "Si es Alanon o Alateen es necesario")]
        public string Alateen { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Numero { get; set; } = "";
        public string NumeroDeSala { get; set; } = "";
        public string Contraseña { get; set; } = "";
        public string Notas { get; set; } = "";

    }
}
