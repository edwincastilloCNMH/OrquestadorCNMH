using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTO;
using WebAPI.Application.UseCase.Interfaces;

namespace WebAPI.Controllers.Areas.Estado
{

    [ApiController]
    [Route("api/WebAPI/[controller]/[action]")]
    public class EstadoController : Controller
    {
        private readonly IEstadoUseCase _useCase;

        public EstadoController(IEstadoUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EstadoCreateDTO dto)
        {
            var result = await _useCase.Create(dto);
            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EstadoUpdateDTO dto)
        {
            var result = await _useCase.Update(dto);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _useCase.Delete(id);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _useCase.GetById(id);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _useCase.GetAll();
            return new JsonResult(result);
        }
    }
}
