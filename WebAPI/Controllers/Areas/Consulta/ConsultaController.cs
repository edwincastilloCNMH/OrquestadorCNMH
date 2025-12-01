using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;

namespace WebAPI.Controllers.Areas.Consulta
{
    [ApiController]
    [Route("api/WebAPI/[controller]")]
    public class ConsultaController : Controller
    {
        private readonly IConsultaUseCase _consultaUseCase;

        public ConsultaController(IConsultaUseCase consultaUseCase)
        {
            _consultaUseCase = consultaUseCase;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetBasicQuery(QueryRequestMeta request)
        {
            var result = await _consultaUseCase.GetBasicQuery(request);

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
