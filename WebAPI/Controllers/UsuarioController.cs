using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/WebAPI/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioUseCase _usersUseCase;

        public UsuarioController(IUsuarioUseCase usersUseCase)
        {
            _usersUseCase = usersUseCase;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequestDTO login)
        {
            var result = _usersUseCase.Login(login);

            if (result.Succeeded)
            {
                result.Message = Ok().StatusCode.ToString();
                return new JsonResult(result);
            }
            else
            {
                return Unauthorized(result);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(UsuarioRequest request)
        {
            var result = _usersUseCase.CreateUser(request);

            if (result.Succeeded)
            {
                result.Message = Ok().StatusCode.ToString();
                return new JsonResult(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = _usersUseCase.GetUserById(id);

            if (result.Succeeded)
            {
                result.Message = Ok().StatusCode.ToString();
                return new JsonResult(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser(UsuarioDTO request)
        {
            var result = _usersUseCase.UpdateUser(request);

            if (result.Succeeded)
            {
                result.Message = Ok().StatusCode.ToString();
                return new JsonResult(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
