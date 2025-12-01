using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class ResetPasswordRequestDTO
    {
        public string Correo { get; set; }
    }

    public class ChangePasswordDTO
    {
        public string Token { get; set; }
        public string NuevaContrasena { get; set; }
    }

    public class ResetPasswordConfirmDTO
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }

}
