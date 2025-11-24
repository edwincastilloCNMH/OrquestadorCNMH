using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Domain.IRepositories;
using WebAPI.Domain.Services;

namespace WebAPI.Application.UseCase
{
    public class ConfiguracionesUseCase : IConfiguracionesUseCase
    {
        private readonly ConfiguracionesService _service;
        private readonly IMapper _mapper;

        public ConfiguracionesUseCase(ConfiguracionesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // ------------------- PAIS -------------------

        public async Task<Response<IEnumerable<PaisDTO>>> GetPaises()
        {
            var response = new Response<IEnumerable<PaisDTO>>();

            try
            {
                var data = _service.GetPaises();
                response.Data = _mapper.Map<IEnumerable<PaisDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetPaises: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<PaisDTO>> GetPaisById(int id)
        {
            var response = new Response<PaisDTO>();

            try
            {
                var data = _service.GetPaisById(id);
                response.Data = _mapper.Map<PaisDTO>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetPaisById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        // ------------------- DEPARTAMENTO -------------------

        public async Task<Response<IEnumerable<DepartamentoDTO>>> GetDepartamentos()
        {
            var response = new Response<IEnumerable<DepartamentoDTO>>();

            try
            {
                var data = _service.GetDepartamentos();
                response.Data = _mapper.Map<IEnumerable<DepartamentoDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetDepartamentos: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<IEnumerable<DepartamentoDTO>>> GetDepartamentosByPaisId(int paisId)
        {
            var response = new Response<IEnumerable<DepartamentoDTO>>();

            try
            {
                var data = _service.GetDepartamentosByPaisId(paisId);

                if (!data.Any())
                {
                    response.Succeeded = true;
                    response.Message = "No aplica";
                    response.Data = Enumerable.Empty<DepartamentoDTO>();
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<DepartamentoDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetDepartamentosByPaisId: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<DepartamentoDTO>> GetDepartamentoById(int id)
        {
            var response = new Response<DepartamentoDTO>();

            try
            {
                var data = _service.GetDepartamentoById(id);
                response.Data = _mapper.Map<DepartamentoDTO>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetDepartamentoById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        // ------------------- MUNICIPIO -------------------

        public async Task<Response<IEnumerable<MunicipioDTO>>> GetMunicipios()
        {
            var response = new Response<IEnumerable<MunicipioDTO>>();

            try
            {
                var data = _service.GetMunicipios();
                response.Data = _mapper.Map<IEnumerable<MunicipioDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetMunicipios: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<IEnumerable<MunicipioDTO>>> GetMunicipiosByDepartamentoId(int departamentoId)
        {
            var response = new Response<IEnumerable<MunicipioDTO>>();

            try
            {
                var data = _service.GetMunicipiosByDepartamentoId(departamentoId);

                if (!data.Any())
                {
                    response.Succeeded = true;
                    response.Message = "No aplica";
                    response.Data = Enumerable.Empty<MunicipioDTO>();
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<MunicipioDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetMunicipiosByDepartamentoId: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<MunicipioDTO>> GetMunicipioById(int id)
        {
            var response = new Response<MunicipioDTO>();

            try
            {
                var data = _service.GetMunicipioById(id);
                response.Data = _mapper.Map<MunicipioDTO>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetMunicipioById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        // ------------------- TIPO DOCUMENTO -------------------

        public async Task<Response<IEnumerable<TipoDocumentoDTO>>> GetTiposDocumento()
        {
            var response = new Response<IEnumerable<TipoDocumentoDTO>>();

            try
            {
                var data = _service.GetTiposDocumento();
                response.Data = _mapper.Map<IEnumerable<TipoDocumentoDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetTiposDocumento: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<TipoDocumentoDTO>> GetTipoDocumentoById(int id)
        {
            var response = new Response<TipoDocumentoDTO>();

            try
            {
                var data = _service.GetTipoDocumentoById(id);
                response.Data = _mapper.Map<TipoDocumentoDTO>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetTipoDocumentoById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        // ------------------- NIVEL EDUCATIVO -------------------

        public async Task<Response<IEnumerable<NivelEducativoDTO>>> GetNivelesEducativos()
        {
            var response = new Response<IEnumerable<NivelEducativoDTO>>();

            try
            {
                var data = _service.GetNivelesEducativos();
                response.Data = _mapper.Map<IEnumerable<NivelEducativoDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetNivelesEducativos: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<NivelEducativoDTO>> GetNivelEducativoById(int id)
        {
            var response = new Response<NivelEducativoDTO>();

            try
            {
                var data = _service.GetNivelEducativoById(id);
                response.Data = _mapper.Map<NivelEducativoDTO>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetNivelEducativoById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<IEnumerable<PoblacionInteresDTO>>> GetPoblacionInteres()
        {
            var response = new Response<IEnumerable<PoblacionInteresDTO>>();
            try
            {
                var data = _service.GetPoblacionInteres();
                response.Data = _mapper.Map<IEnumerable<PoblacionInteresDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetPoblacionInteres: {ex.Message}");
                response.Succeeded = false;
            }
            return response;
        }

        public async Task<Response<PoblacionInteresDTO>> GetPoblacionInteresById(int id)
        {
            var response = new Response<PoblacionInteresDTO>();
            try
            {
                var data = _service.GetPoblacionInteresById(id);
                response.Data = _mapper.Map<PoblacionInteresDTO>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetPoblacionInteresById: {ex.Message}");
                response.Succeeded = false;
            }
            return response;
        }

        public async Task<Response<IEnumerable<GeneroDTO>>> GetGeneros()
        {
            var response = new Response<IEnumerable<GeneroDTO>>();

            try
            {
                var data = _service.GetGeneros();
                response.Data = _mapper.Map<IEnumerable<GeneroDTO>>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetGeneros: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<GeneroDTO>> GetGeneroById(int id)
        {
            var response = new Response<GeneroDTO>();

            try
            {
                var data = _service.GetGeneroById(id);
                response.Data = _mapper.Map<GeneroDTO>(data);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Configuraciones - GetGeneroById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }
    }
}
