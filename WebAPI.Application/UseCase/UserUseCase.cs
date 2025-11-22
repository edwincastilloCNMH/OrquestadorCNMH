using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;

namespace WebAPI.Application.UseCase
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IConfiguration _configuration;
        public UserUseCase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response<UsersDTO>> Login(LoginRequestDTO login)
        {
            var response = new Response<UsersDTO>();
            try
            {
                var user = await ValidateUser(login);

                if (user == null)
                    return new Response<UsersDTO> { Data = null, Succeeded = false, Message = "Invalid credentials" };


                

                var jwtSettings = _configuration.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]));

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
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

        private async Task<UsersDTO> ValidateUser(LoginRequestDTO login)
        {
            
            if (login.User != "Pepito" && login.Password != "12345")
                return null;


            return  new UsersDTO()
            {
                Id = 1,
                DocNumber = "123456789",
                UserName = "Pepito",
                Email = "pepito@gmail.com",
                State = true
            };

        }
    }
}
