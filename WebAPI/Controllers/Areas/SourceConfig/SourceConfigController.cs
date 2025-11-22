using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTO;
using WebAPI.Application.UseCase.Interfaces;

namespace WebAPI.Controllers.Areas.SourceConfig
{
    [ApiController]
    [Route("api/WebAPI/SourceConfig/[action]")]
    public class SourceConfigController : Controller
    {
        private readonly ISourceConfigUseCase _useCase;

        public SourceConfigController(ISourceConfigUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EstadoDTO dto)
        {
            var result = await _useCase.Create(dto);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SourceConfigUpdateDTO dto)
        {
            var result = await _useCase.Update(id, dto);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _useCase.Delete(id);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _useCase.GetById(id);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _useCase.GetAll();
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
