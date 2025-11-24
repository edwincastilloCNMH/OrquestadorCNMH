using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.UseCase.Interfaces;

namespace WebAPI.Controllers.Areas.Configuraciones
{
    [ApiController]
    [Route("api/WebAPI/[controller]/[action]")]
    public class ConfiguracionesController : Controller
    {
        private readonly IConfiguracionesUseCase _useCase;

        public ConfiguracionesController(IConfiguracionesUseCase useCase)
        {
            _useCase = useCase;
        }

        // ------------------- PAIS -------------------

        [HttpGet]
        public async Task<IActionResult> GetPaises()
        {
            var result = await _useCase.GetPaises();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaisById(int id)
        {
            var result = await _useCase.GetPaisById(id);
            return new JsonResult(result);
        }

        // ------------------- DEPARTAMENTOS -------------------

        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            var result = await _useCase.GetDepartamentos();
            return new JsonResult(result);
        }

        [HttpGet("{paisId}")]
        public async Task<IActionResult> GetDepartamentosByPaisId(int paisId)
        {
            var result = await _useCase.GetDepartamentosByPaisId(paisId);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartamentoById(int id)
        {
            var result = await _useCase.GetDepartamentoById(id);
            return new JsonResult(result);
        }

        // ------------------- MUNICIPIOS -------------------

        [HttpGet]
        public async Task<IActionResult> GetMunicipios()
        {
            var result = await _useCase.GetMunicipios();
            return new JsonResult(result);
        }

        [HttpGet("{departamentoId}")]
        public async Task<IActionResult> GetMunicipiosByDepartamentoId(int departamentoId)
        {
            var result = await _useCase.GetMunicipiosByDepartamentoId(departamentoId);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMunicipioById(int id)
        {
            var result = await _useCase.GetMunicipioById(id);
            return new JsonResult(result);
        }

        // ------------------- TIPO DOCUMENTO -------------------

        [HttpGet]
        public async Task<IActionResult> GetTiposDocumento()
        {
            var result = await _useCase.GetTiposDocumento();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoDocumentoById(int id)
        {
            var result = await _useCase.GetTipoDocumentoById(id);
            return new JsonResult(result);
        }

        // ------------------- NIVEL EDUCATIVO -------------------

        [HttpGet]
        public async Task<IActionResult> GetNivelesEducativos()
        {
            var result = await _useCase.GetNivelesEducativos();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNivelEducativoById(int id)
        {
            var result = await _useCase.GetNivelEducativoById(id);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPoblacionInteres()
        {
            var result = await _useCase.GetPoblacionInteres();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoblacionInteresById(int id)
        {
            var result = await _useCase.GetPoblacionInteresById(id);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            var result = await _useCase.GetGeneros();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneroById(int id)
        {
            var result = await _useCase.GetGeneroById(id);
            return new JsonResult(result);
        }
    }
}
