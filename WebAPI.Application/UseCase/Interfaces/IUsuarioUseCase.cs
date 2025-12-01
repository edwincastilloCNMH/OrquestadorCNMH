using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface IUsuarioUseCase
    {
        Response<UsuarioDTO> Login(LoginRequestDTO login);
        Response<UsuarioDTO> CreateUser(UsuarioRequest user);
        Response<UsuarioDTO> GetUserById(int id);
        Response<UsuarioDTO> UpdateUser(UsuarioDTO user);
        Task<Response<IEnumerable<UsuarioListDTO>>> GetAllUsers();
        Task<Response<PagedResultDTO<UsuarioListDTO>>> GetAllUsersPaged(int page, int pageSize);
        Response<string> RequestPasswordReset(string correo);
        Response<string> ValidateResetToken(string token);
        Response<string> ResetPasswordConfirm(string token, string newPassword);
    }
}
