using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class RegistroModel
    {
        public int idRegistro { get; set; }

        [Required(ErrorMessage ="El campo Nombre es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Genero es requerido")]
        public string? Genero { get; set; }
        [Required(ErrorMessage = "El campo Año es requerido")]
        public int? Año { get; set; }


    }
}
