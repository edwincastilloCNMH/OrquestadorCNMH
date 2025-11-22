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
    public class SourceModelUseCase : ISourceModelUseCase
    {
        private readonly SourceModelService _sourceModelService;
        private readonly IMapper _mapper;

        public SourceModelUseCase(SourceModelService sourceModelService, IMapper mapper)
        {
            _sourceModelService = sourceModelService;
            _mapper = mapper;
        }

        public async Task<Response<SourceModelDTO>> Create(SourceModelCreateDTO dto)
        {
            var response = new Response<SourceModelDTO>();

            try
            {
                var entity = _mapper.Map<SourceModelEntity>(dto);
                var created = _sourceModelService.Create(entity);

                response.Data = _mapper.Map<SourceModelDTO>(created);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModel - Create: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<SourceModelDTO>> Update(SourceModelUpdateDTO dto)
        {
            var response = new Response<SourceModelDTO>();

            try
            {
                var entity = _mapper.Map<SourceModelEntity>(dto);
                var updated = _sourceModelService.Update(entity);

                response.Data = _mapper.Map<SourceModelDTO>(updated);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModel - Update: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                _sourceModelService.Delete(id);
                response.Data = true;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModel - Delete: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<SourceModelDTO>> GetById(int id)
        {
            var response = new Response<SourceModelDTO>();

            try
            {
                var entity = _sourceModelService.GetById(id);
                response.Data = _mapper.Map<SourceModelDTO>(entity);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModel - GetById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<IEnumerable<SourceModelDTO>>> GetAll()
        {
            var response = new Response<IEnumerable<SourceModelDTO>>();

            try
            {
                var list = _sourceModelService.GetAll();
                response.Data = _mapper.Map<IEnumerable<SourceModelDTO>>(list);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModel - GetAll: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }
    }
}
