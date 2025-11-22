using AutoMapper;
using WebAPI.Domain.Entities;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            // SourceConfig ↔ SourceConfigEntity
            CreateMap<SourceConfig, SourceConfigEntity>().ReverseMap();

            // Estado ↔ EstadoEntity
            CreateMap<Estado, EstadoEntity>().ReverseMap();

            // ModelType ↔ ModelTypeEntity
            CreateMap<ModelType, ModelTypeEntity>().ReverseMap();

            // SourceModel ↔ SourceModelEntity
            CreateMap<SourceModel, SourceModelEntity>().ReverseMap();

            // SourceModelFields ↔ SourceModelFieldsEntity
            CreateMap<SourceModelFields, SourceModelFieldsEntity>().ReverseMap();
        }
    }
}
