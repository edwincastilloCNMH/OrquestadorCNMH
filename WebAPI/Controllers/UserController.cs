using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/WebAPI/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserUseCase _usersUseCase;

        public UserController(IUserUseCase usersUseCase)
        {
            _usersUseCase = usersUseCase;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequestDTO login)
        {
            var result = await _usersUseCase.Login(login);

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

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> Prueba()
        {
            var result = new Response<string>();

            result.Data = "La Api esta OK!!";

            if (result.Data != null)
            {
                result.Message = Ok().StatusCode.ToString();
                return new JsonResult(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
