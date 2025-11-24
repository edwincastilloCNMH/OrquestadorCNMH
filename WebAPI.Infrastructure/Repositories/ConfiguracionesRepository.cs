using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;
using WebAPI.Infrastructure.Contexts;

namespace WebAPI.Infrastructure.Repositories
{
    public class ConfiguracionesRepository : IConfiguracionesRepository
    {
        private readonly WebAPIContext _context;
        private readonly IMapper _mapper;

        public ConfiguracionesRepository(WebAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // -------- PAÍS --------
        public IEnumerable<PaisEntity> GetPaises()
        {
            var data = _context.PaisModel.ToList();
            return _mapper.Map<IEnumerable<PaisEntity>>(data);
        }

        public PaisEntity GetPaisById(int id)
        {
            var data = _context.PaisModel.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<PaisEntity>(data);
        }

        // -------- DEPARTAMENTO --------
        public IEnumerable<DepartamentoEntity> GetDepartamentos()
        {
            var data = _context.DepartamentoModel.ToList();
            return _mapper.Map<IEnumerable<DepartamentoEntity>>(data);
        }

        public IEnumerable<DepartamentoEntity> GetDepartamentosByPais(int paisId)
        {
            var data = _context.DepartamentoModel.Where(x => x.PaisId == paisId).ToList();
            return _mapper.Map<IEnumerable<DepartamentoEntity>>(data);
        }

        public DepartamentoEntity GetDepartamentoById(int id)
        {
            var data = _context.DepartamentoModel.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<DepartamentoEntity>(data);
        }

        // -------- MUNICIPIO --------
        public IEnumerable<MunicipioEntity> GetMunicipios()
        {
            var data = _context.MunicipioModel.ToList();
            return _mapper.Map<IEnumerable<MunicipioEntity>>(data);
        }

        public IEnumerable<MunicipioEntity> GetMunicipiosByDepartamento(int departamentoId)
        {
            var data = _context.MunicipioModel.Where(x => x.DepartamentoId == departamentoId).ToList();
            return _mapper.Map<IEnumerable<MunicipioEntity>>(data);
        }

        public MunicipioEntity GetMunicipioById(int id)
        {
            var data = _context.MunicipioModel.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<MunicipioEntity>(data);
        }

        // -------- TIPO DOCUMENTO --------
        public IEnumerable<TipoDocumentoEntity> GetTiposDocumento()
        {
            var data = _context.TipoDocumentoModel.ToList();
            return _mapper.Map<IEnumerable<TipoDocumentoEntity>>(data);
        }

        public TipoDocumentoEntity GetTipoDocumentoById(int id)
        {
            var data = _context.TipoDocumentoModel.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<TipoDocumentoEntity>(data);
        }

        // -------- NIVEL EDUCATIVO --------
        public IEnumerable<NivelEducativoEntity> GetNivelesEducativos()
        {
            var data = _context.NivelEducativoModel.ToList();
            return _mapper.Map<IEnumerable<NivelEducativoEntity>>(data);
        }

        public NivelEducativoEntity GetNivelEducativoById(int id)
        {
            var data = _context.NivelEducativoModel.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<NivelEducativoEntity>(data);
        }

        public IEnumerable<PoblacionInteresEntity> GetPoblacionInteres()
        {
            var data = _context.PoblacionInteresModel.ToList();
            return _mapper.Map<IEnumerable<PoblacionInteresEntity>>(data);
        }

        public PoblacionInteresEntity GetPoblacionInteresById(int id)
        {
            var data = _context.PoblacionInteresModel.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<PoblacionInteresEntity>(data);
        }

        public IEnumerable<GeneroEntity> GetGeneros()
        {
            var data = _context.GeneroModel.ToList();
            return _mapper.Map<IEnumerable<GeneroEntity>>(data);
        }

        public GeneroEntity GetGeneroById(int id)
        {
            var data = _context.GeneroModel.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<GeneroEntity>(data);
        }
    }
}
