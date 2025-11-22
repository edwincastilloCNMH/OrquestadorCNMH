using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Services;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Application.UseCase
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioService _usuarioService;
        private readonly PasswordService _passwordService;
        private readonly LdapService _ldapService;
        private readonly IMapper _mapper;
        public UsuarioUseCase(IConfiguration configuration, UsuarioService usuarioService, IMapper mapper, PasswordService passwordService, LdapService ldapSercice)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _passwordService = passwordService;
            _ldapService = ldapSercice;
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
                UsuarioEntiy usersEntity = _mapper.Map<UsuarioEntiy>(user);

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
                UsuarioEntiy usersEntity = _mapper.Map<UsuarioEntiy>(user);
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
    }
}
