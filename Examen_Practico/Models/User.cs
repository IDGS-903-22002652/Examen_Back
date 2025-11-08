using System.ComponentModel.DataAnnotations;

namespace Examen_Practico.Models
{
    public class User 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(100)]
        public string UsuarioTwitter { get; set; }

        [StringLength(150)]
        public string Ocupacion { get; set; }

        [StringLength(500)] // Como texto (string) para la URL
        public string Avatar { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos y condiciones")]
        public bool AceptaTerminos { get; set; }
    }
}