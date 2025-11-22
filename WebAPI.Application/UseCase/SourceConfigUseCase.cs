using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Services;

namespace WebAPI.Application.UseCase
{
    public class SourceConfigUseCase : ISourceConfigUseCase
    {
        private readonly SourceConfigService _service;
        private readonly IMapper _mapper;

        public SourceConfigUseCase(SourceConfigService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Response<SourceConfigDTO>> Create(EstadoDTO dto)
        {
            var response = new Response<SourceConfigDTO>();

            try
            {
                var entity = _mapper.Map<SourceConfigEntity>(dto);

                var result = _service.Create(entity);

                response.Data = _mapper.Map<SourceConfigDTO>(result);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceConfig - Create: {ex.Message}");
                response.Succeeded = false;
                response.Errors = new[] { ex.Message };
                response.Message = "Error processing request in SourceConfig UseCase.";
            }

            return response;
        }

        public async Task<Response<SourceConfigDTO>> Update(int id, SourceConfigUpdateDTO dto)
        {
            var response = new Response<SourceConfigDTO>();

            try
            {
                var current = _service.GetById(id);
                if (current == null)
                {
                    response.Succeeded = false;
                    response.Message = "Record not found.";
                    return response;
                }

                _mapper.Map(dto, current);
                var updated = _service.Update(current);

                response.Data = _mapper.Map<SourceConfigDTO>(updated);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceConfig - Update: {ex.Message}");
                response.Succeeded = false;
                response.Errors = new[] { ex.Message };
                response.Message = "Error processing update.";
            }

            return response;
        }

        public async Task<Response<bool>> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                _service.Delete(id);
                response.Data = true;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceConfig - Delete: {ex.Message}");
                response.Succeeded = false;
                response.Errors = new[] { ex.Message };
                response.Message = "Error deleting record.";
            }

            return response;
        }

        public async Task<Response<SourceConfigDTO>> GetById(int id)
        {
            var response = new Response<SourceConfigDTO>();

            try
            {
                var entity = _service.GetById(id);

                if (entity == null)
                {
                    response.Succeeded = false;
                    response.Message = "Record not found.";
                    return response;
                }

                response.Data = _mapper.Map<SourceConfigDTO>(entity);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceConfig - GetById: {ex.Message}");
                response.Succeeded = false;
                response.Errors = new[] { ex.Message };
            }

            return response;
        }

        public async Task<Response<List<SourceConfigDTO>>> GetAll()
        {
            var response = new Response<List<SourceConfigDTO>>();

            try
            {
                var list = _service.GetAll().ToList();

                response.Data = _mapper.Map<List<SourceConfigDTO>>(list);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceConfig - GetAll: {ex.Message}");
                response.Succeeded = false;
                response.Errors = new[] { ex.Message };
            }

            return response;
        }
    }
}
