using AutoMapper;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Profiles
{
	public class ApplicationProfile : Profile
	{
		public ApplicationProfile()
		{
            // ----------------------------
            // SourceConfig
            // ----------------------------
            CreateMap<SourceConfigEntity, SourceConfigDTO>().ReverseMap();
            CreateMap<SourceConfigCreateDTO, SourceConfigEntity>();
            CreateMap<SourceConfigUpdateDTO, SourceConfigEntity>();


            // ----------------------------
            // Estado
            // ----------------------------
            CreateMap<EstadoEntity, EstadoDTO>().ReverseMap();
            CreateMap<EstadoCreateDTO, EstadoEntity>();
            CreateMap<EstadoUpdateDTO, EstadoEntity>();


            // ----------------------------
            // ModelType
            // ----------------------------
            CreateMap<ModelTypeEntity, ModelTypeDTO>().ReverseMap();
            CreateMap<ModelTypeCreateDTO, ModelTypeEntity>();
            CreateMap<ModelTypeUpdateDTO, ModelTypeEntity>();


            // ----------------------------
            // SourceModel
            // ----------------------------
            CreateMap<SourceModelEntity, SourceModelDTO>().ReverseMap();
            CreateMap<SourceModelCreateDTO, SourceModelEntity>();
            CreateMap<SourceModelUpdateDTO, SourceModelEntity>();


            // ----------------------------
            // SourceModelFields
            // ----------------------------
            CreateMap<SourceModelFieldsEntity, SourceModelFieldsDTO>().ReverseMap();
            CreateMap<SourceModelFieldsCreateDTO, SourceModelFieldsEntity>();
            CreateMap<SourceModelFieldsUpdateDTO, SourceModelFieldsEntity>();

            CreateMap<UsuarioEntiy, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioEntiy, UsuarioRequest>().ReverseMap();
        }
	}
}
