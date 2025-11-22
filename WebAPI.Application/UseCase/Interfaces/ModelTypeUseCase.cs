using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Services;

namespace WebAPI.Application.UseCase.Interfaces
{
    public class ModelTypeUseCase : IModelTypeUseCase
    {
        private readonly ModelTypeService _modelTypeService;
        private readonly IMapper _mapper;

        public ModelTypeUseCase(ModelTypeService modelTypeService, IMapper mapper)
        {
            _modelTypeService = modelTypeService;
            _mapper = mapper;
        }

        public async Task<Response<ModelTypeDTO>> Create(ModelTypeCreateDTO dto)
        {
            var response = new Response<ModelTypeDTO>();

            try
            {
                var entity = _mapper.Map<ModelTypeEntity>(dto);
                var created = _modelTypeService.Create(entity);

                response.Data = _mapper.Map<ModelTypeDTO>(created);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] ModelType - Create: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<ModelTypeDTO>> Update(ModelTypeUpdateDTO dto)
        {
            var response = new Response<ModelTypeDTO>();

            try
            {
                var entity = _mapper.Map<ModelTypeEntity>(dto);
                var updated = _modelTypeService.Update(entity);

                response.Data = _mapper.Map<ModelTypeDTO>(updated);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] ModelType - Update: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                _modelTypeService.Delete(id);
                response.Data = true;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] ModelType - Delete: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<ModelTypeDTO>> GetById(int id)
        {
            var response = new Response<ModelTypeDTO>();

            try
            {
                var entity = _modelTypeService.GetById(id);
                response.Data = _mapper.Map<ModelTypeDTO>(entity);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] ModelType - GetById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<IEnumerable<ModelTypeDTO>>> GetAll()
        {
            var response = new Response<IEnumerable<ModelTypeDTO>>();

            try
            {
                var list = _modelTypeService.GetAll();
                response.Data = _mapper.Map<IEnumerable<ModelTypeDTO>>(list);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] ModelType - GetAll: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }
    }
}
