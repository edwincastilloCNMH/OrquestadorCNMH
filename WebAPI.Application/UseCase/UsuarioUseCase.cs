using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Services;

namespace WebAPI.Application.UseCase
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioService _usuarioService;
        private readonly PasswordService _passwordService;
        private readonly LdapService _ldapService;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;

        public UsuarioUseCase(IConfiguration configuration, UsuarioService usuarioService, IMapper mapper, PasswordService passwordService, LdapService ldapSercice, EmailService emailService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _passwordService = passwordService;
            _ldapService = ldapSercice;
            _emailService = emailService;
        }



        public Response<UsuarioDTO> Login(LoginRequestDTO login)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var user = ValidateUserLogin(login.User, login.Password);

                if (user == null)
                    return new Response<UsuarioDTO> { Data = null, Succeeded = false, Message = "Invalid credentials" };


                

                var jwtSettings = _configuration.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]));

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Nombres),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Correo)
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
                    Issuer = jwtSettings["Issuer"],
                    Audience = jwtSettings["Audience"],
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                user.Token = tokenHandler.WriteToken(token);
                response.Data = user;
                response.Succeeded = true;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
                response.Succeeded = false;

                response.Message = "Se presentó un error en el procesamiento de la solicitud.";                
            }

            return response;
        }

        private UsuarioDTO ValidateUserLogin(string email, string password)
        {
            // Buscar usuario en BD
            var userEntity = _usuarioService.GetByemail(email);
            var emailCorp = email.Trim().ToLower().EndsWith("@cnmh.gov.co");
            string usernameSam = email.Split('@')[0];
            // --------------------------------------------
            // 1. Usuario NO existe -> intentar login AD
            // --------------------------------------------

            if (userEntity == null && emailCorp)
            {
                
                if (_ldapService.ValidateUser(usernameSam, password))
                {
                    var newUser = _ldapService.GetUserLdap(email, password);

                    _usuarioService.Create(newUser);

                    return _mapper.Map<UsuarioDTO>(newUser);
                }

                // No existe y no es AD
                return null;
            }


            if(userEntity == null)
                return null;
            // ----------------------------------------------
            // 2. Usuario existe en BD -> determinar tipo
            // ----------------------------------------------

            // Usuario de Active Directory
            if (userEntity.IsActiveDirectoryUser)
            {
                bool validAD = _ldapService.ValidateUser(usernameSam, password);

                if (!validAD)
                    return null;

                return _mapper.Map<UsuarioDTO>(userEntity);
            }

            // Usuario NORMAL (tu base de datos)
            bool isPasswordValid = _passwordService.VerifyPassword(password, userEntity.Password);

            if (!isPasswordValid)
                return null;

            return _mapper.Map<UsuarioDTO>(userEntity);
        }

        public Response<UsuarioDTO> CreateUser(UsuarioRequest user)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                UsuarioEntity usersEntity = _mapper.Map<UsuarioEntity>(user);

                var userExists = ValidateUserExists(user.NumDocumento).Data;

                if (userExists == null)
                {
                    usersEntity.EstadoId = 1;
                    usersEntity.IsActiveDirectoryUser = false;
                    usersEntity.Password = _passwordService.HashPassword(usersEntity.Password);
                    response.Data = _mapper.Map<UsuarioDTO>(_usuarioService.Create(usersEntity));

                    response.Message = "Add";
                }
                else
                {
                    response.Message = "Exists";
                }
                response.Succeeded = true;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
                response.Succeeded = false;
            }

            return response;
        }


        public Response<UsuarioDTO> ValidateUserExists(string numDocument)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                response.Data = _mapper.Map<UsuarioDTO>(_usuarioService.GetByNumDoc(numDocument));
                response.Succeeded = true;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
                response.Succeeded = false;
            }

            return response;
        }

        public Response<UsuarioDTO> GetUserById(int id)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var userEntity = _usuarioService.GetById(id);
                
                if (userEntity == null)
                    return null;

                response.Data = _mapper.Map<UsuarioDTO>(userEntity);
                response.Succeeded = true;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
                response.Succeeded = false;
            }

            return response;
        }


        public Response<UsuarioDTO> UpdateUser(UsuarioDTO user)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                UsuarioEntity usersEntity = _mapper.Map<UsuarioEntity>(user);
                var existingUser = _usuarioService.GetById(user.Id);
                if (existingUser == null)
                {
                    response.Message = "Not Exist";
                }
                else
                {
                    if (string.IsNullOrEmpty(user.Password) || user.Password == existingUser.Password)
                    {
                        usersEntity.Password = existingUser.Password;
                    }
                    else
                    {
                        usersEntity.Password = _passwordService.HashPassword(usersEntity.Password);
                    }
                    response.Data = _mapper.Map<UsuarioDTO>(_usuarioService.Update(usersEntity));
                    response.Message = "Update";
                }
                response.Succeeded = true;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
                response.Succeeded = false;
            }
            return response;
        }

        public async Task<Response<IEnumerable<UsuarioListDTO>>> GetAllUsers()
        {
            var response = new Response<IEnumerable<UsuarioListDTO>>();
            try
            {
                var data = _usuarioService.GetAllUsers();
                response.Data = _mapper.Map<IEnumerable<UsuarioListDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Succeeded = false;
            }
            return response;
        }

        public async Task<Response<PagedResultDTO<UsuarioListDTO>>> GetAllUsersPaged(int page, int pageSize)
        {
            var response = new Response<PagedResultDTO<UsuarioListDTO>>();
            try
            {
                var result = _usuarioService.GetAllUsersPaged(page, pageSize);

                response.Data = new PagedResultDTO<UsuarioListDTO>
                {
                    Total = result.Total,
                    Items = _mapper.Map<IEnumerable<UsuarioListDTO>>(result.Items)
                };

                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Succeeded = false;
            }

            return response;
        }

        public Response<string> RequestPasswordReset(string correo)
        {
            var response = new Response<string>();

            var user = _usuarioService.GetByemail(correo);

            if (user == null)
                return new Response<string> { Succeeded = false, Message = "Correo no existe" };

            if (user.IsActiveDirectoryUser)
                return new Response<string> { Succeeded = false, Message = "Usuarios LDAP no pueden cambiar contraseña aquí" };

            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            user.ResetPasswordToken = token;
            user.ResetTokenExpiration = DateTime.UtcNow.AddMinutes(30);

            _usuarioService.Update(user);

            EnviarCorreoRecuperacion(correo, token);

            response.Succeeded = true;
            response.Message = "Correo enviado";
            return response;
        }

        public Response<string> ValidateResetToken(string token)
        {
            var user = _usuarioService.GetByResetToken(token);

            if (user == null || user.ResetTokenExpiration < DateTime.UtcNow)
                return new Response<string> { Succeeded = false, Message = "Token inválido o expirado" };

            return new Response<string> { Succeeded = true, Message = "Token válido" };
        }

        public Response<string> ResetPasswordConfirm(string token, string newPassword)
        {
            var user = _usuarioService.GetByResetToken(token);

            if (user == null || user.ResetTokenExpiration < DateTime.UtcNow)
                return new Response<string> { Succeeded = false, Message = "Token inválido o expirado" };

            user.Password = _passwordService.HashPassword(newPassword);
            user.ResetPasswordToken = null;
            user.ResetTokenExpiration = null;

            _usuarioService.Update(user);

            return new Response<string> { Succeeded = true, Message = "Contraseña actualizada" };
        }

        private void EnviarCorreoRecuperacion(string correo, string token)
        {
            // URL del front para cambiar contraseña, config en appsettings.json:
            // "Frontend": { "ResetPasswordUrl": "https://tudominio.com/reestablecer-contrasena" }
            string frontendUrl = _configuration["Frontend:ResetPasswordUrl"];

            // Por si acaso escapamos el token en la URL
            string link = $"{frontendUrl}?token={Uri.EscapeDataString(token)}";

            string html = $@"
                <h2>Recuperación de contraseña</h2>
                <p>Haga clic en el siguiente enlace para restablecer su contraseña:</p>
                <p><a href='{link}'>Restablecer contraseña</a></p>
                <p>Si usted no solicitó este cambio, puede ignorar este correo.</p>
                <p>Este enlace expirará en 30 minutos.</p>
            ";

            _emailService.Send(correo, "Restablecer contraseña", html);
        }

    }
}
