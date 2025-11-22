using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface IUserUseCase
    {
        Task<Response<UsersDTO>> Login(LoginRequestDTO login);
    }
}
