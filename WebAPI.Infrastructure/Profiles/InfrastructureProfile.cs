using AutoMapper;
using WebAPI.Domain.Entities;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<SourceConfig, SourceConfigEntity>().ReverseMap();
            CreateMap<Estado, EstadoEntity>().ReverseMap();
            CreateMap<ModelType, ModelTypeEntity>().ReverseMap();
            CreateMap<SourceModel, SourceModelEntity>().ReverseMap();
            CreateMap<SourceModelFields, SourceModelFieldsEntity>().ReverseMap();
            CreateMap<DepartamentoModel, DepartamentoEntity>().ReverseMap();
            CreateMap<GeneroModel, GeneroEntity>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioEntity>().ReverseMap();
            CreateMap<NivelEducativoModel, NivelEducativoEntity>().ReverseMap();
            CreateMap<PaisModel, PaisEntity>().ReverseMap();
            CreateMap<TipoDocumentoModel, TipoDocumentoEntity>().ReverseMap();
            CreateMap<UsuarioModel, UsuarioEntity>().ReverseMap();
            CreateMap<PoblacionInteresModel, PoblacionInteresEntity>().ReverseMap();
        }
    }
}
