using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
    public class ConfiguracionesService
    {
        private readonly IConfiguracionesRepository _repo;

        public ConfiguracionesService(IConfiguracionesRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<PaisEntity> GetPaises() => _repo.GetPaises();
        public PaisEntity GetPaisById(int id) => _repo.GetPaisById(id);


        public IEnumerable<DepartamentoEntity> GetDepartamentos() => _repo.GetDepartamentos();
        public IEnumerable<DepartamentoEntity> GetDepartamentosByPaisId(int paisId) => _repo.GetDepartamentosByPais(paisId);
        public DepartamentoEntity GetDepartamentoById(int id) => _repo.GetDepartamentoById(id);


        public IEnumerable<MunicipioEntity> GetMunicipios() => _repo.GetMunicipios();
        public IEnumerable<MunicipioEntity> GetMunicipiosByDepartamentoId(int depId) => _repo.GetMunicipiosByDepartamento(depId);
        public MunicipioEntity GetMunicipioById(int id) => _repo.GetMunicipioById(id);

        
        public IEnumerable<TipoDocumentoEntity> GetTiposDocumento() => _repo.GetTiposDocumento();
        public TipoDocumentoEntity GetTipoDocumentoById(int id) => _repo.GetTipoDocumentoById(id);

        
        public IEnumerable<NivelEducativoEntity> GetNivelesEducativos() => _repo.GetNivelesEducativos();
        public NivelEducativoEntity GetNivelEducativoById(int id) => _repo.GetNivelEducativoById(id);

        public IEnumerable<PoblacionInteresEntity> GetPoblacionInteres() => _repo.GetPoblacionInteres();

        public PoblacionInteresEntity GetPoblacionInteresById(int id)  => _repo.GetPoblacionInteresById(id);

        public IEnumerable<GeneroEntity> GetGeneros() => _repo.GetGeneros();

        public GeneroEntity GetGeneroById(int id) => _repo.GetGeneroById(id);
    }
}
