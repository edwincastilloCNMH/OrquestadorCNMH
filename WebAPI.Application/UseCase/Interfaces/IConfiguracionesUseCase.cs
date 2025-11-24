using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface IConfiguracionesUseCase
    {
        // ------------------- PAIS -------------------
        Task<Response<IEnumerable<PaisDTO>>> GetPaises();
        Task<Response<PaisDTO>> GetPaisById(int id);

        // ------------------- DEPARTAMENTO -------------------
        Task<Response<IEnumerable<DepartamentoDTO>>> GetDepartamentos();
        Task<Response<IEnumerable<DepartamentoDTO>>> GetDepartamentosByPaisId(int paisId);
        Task<Response<DepartamentoDTO>> GetDepartamentoById(int id);

        // ------------------- MUNICIPIO -------------------
        Task<Response<IEnumerable<MunicipioDTO>>> GetMunicipios();
        Task<Response<IEnumerable<MunicipioDTO>>> GetMunicipiosByDepartamentoId(int departamentoId);
        Task<Response<MunicipioDTO>> GetMunicipioById(int id);

        // ------------------- TIPO DOCUMENTO -------------------
        Task<Response<IEnumerable<TipoDocumentoDTO>>> GetTiposDocumento();
        Task<Response<TipoDocumentoDTO>> GetTipoDocumentoById(int id);

        // ------------------- NIVEL EDUCATIVO -------------------
        Task<Response<IEnumerable<NivelEducativoDTO>>> GetNivelesEducativos();
        Task<Response<NivelEducativoDTO>> GetNivelEducativoById(int id);

        Task<Response<IEnumerable<PoblacionInteresDTO>>> GetPoblacionInteres();
        Task<Response<PoblacionInteresDTO>> GetPoblacionInteresById(int id);

        Task<Response<IEnumerable<GeneroDTO>>> GetGeneros();
        Task<Response<GeneroDTO>> GetGeneroById(int id);
    }
}
