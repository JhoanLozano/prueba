using System.ComponentModel.DataAnnotations;
namespace CRUDCORE.Models
{
    public class ContactoModel
    {
        public int contactoID { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "El campo correo es obligatorio")]
        public string? telefono { get; set; }
        [Required(ErrorMessage = "El campo teléfono es obligatorio")]
        public string? correo { get; set; }
    }
}
