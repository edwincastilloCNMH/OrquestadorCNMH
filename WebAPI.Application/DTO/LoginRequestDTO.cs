using System.ComponentModel.DataAnnotations;

namespace WebAPI.Application.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
