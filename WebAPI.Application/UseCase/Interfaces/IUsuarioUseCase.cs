using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface IUsuarioUseCase
    {
        Response<UsuarioDTO> Login(LoginRequestDTO login);
        Response<UsuarioDTO> CreateUser(UsuarioRequest user);
        Response<UsuarioDTO> GetUserById(int id);
        Response<UsuarioDTO> UpdateUser(UsuarioDTO user);
    }
}
