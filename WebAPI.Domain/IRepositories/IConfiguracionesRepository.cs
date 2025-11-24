using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
    public interface IConfiguracionesRepository
    {
        IEnumerable<PaisEntity> GetPaises();
        PaisEntity GetPaisById(int id);

        
        
        IEnumerable<DepartamentoEntity> GetDepartamentos();
        IEnumerable<DepartamentoEntity> GetDepartamentosByPais(int paisId);
        DepartamentoEntity GetDepartamentoById(int id);

        
        
        IEnumerable<MunicipioEntity> GetMunicipios();
        IEnumerable<MunicipioEntity> GetMunicipiosByDepartamento(int departamentoId);
        MunicipioEntity GetMunicipioById(int id);

        
        
        IEnumerable<TipoDocumentoEntity> GetTiposDocumento();
        TipoDocumentoEntity GetTipoDocumentoById(int id);



        IEnumerable<NivelEducativoEntity> GetNivelesEducativos();
        NivelEducativoEntity GetNivelEducativoById(int id);

        IEnumerable<PoblacionInteresEntity> GetPoblacionInteres();
        PoblacionInteresEntity GetPoblacionInteresById(int id);

        IEnumerable<GeneroEntity> GetGeneros();
        GeneroEntity GetGeneroById(int id);
    }
}
