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
    public class SourceModelFieldsUseCase : ISourceModelFieldsUseCase
    {
        private readonly SourceModelFieldsService _sourceModelFieldsService;
        private readonly IMapper _mapper;

        public SourceModelFieldsUseCase(SourceModelFieldsService sourceModelFieldsService, IMapper mapper)
        {
            _sourceModelFieldsService = sourceModelFieldsService;
            _mapper = mapper;
        }

        public async Task<Response<SourceModelFieldsDTO>> Create(SourceModelFieldsCreateDTO dto)
        {
            var response = new Response<SourceModelFieldsDTO>();

            try
            {
                var entity = _mapper.Map<SourceModelFieldsEntity>(dto);
                var created = _sourceModelFieldsService.Create(entity);

                response.Data = _mapper.Map<SourceModelFieldsDTO>(created);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModelFields - Create: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<SourceModelFieldsDTO>> Update(SourceModelFieldsUpdateDTO dto)
        {
            var response = new Response<SourceModelFieldsDTO>();

            try
            {
                var entity = _mapper.Map<SourceModelFieldsEntity>(dto);
                var updated = _sourceModelFieldsService.Update(entity);

                response.Data = _mapper.Map<SourceModelFieldsDTO>(updated);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModelFields - Update: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                _sourceModelFieldsService.Delete(id);
                response.Data = true;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModelFields - Delete: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<SourceModelFieldsDTO>> GetById(int id)
        {
            var response = new Response<SourceModelFieldsDTO>();

            try
            {
                var entity = _sourceModelFieldsService.GetById(id);
                response.Data = _mapper.Map<SourceModelFieldsDTO>(entity);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModelFields - GetById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<IEnumerable<SourceModelFieldsDTO>>> GetAll()
        {
            var response = new Response<IEnumerable<SourceModelFieldsDTO>>();

            try
            {
                var list = _sourceModelFieldsService.GetAll();
                response.Data = _mapper.Map<IEnumerable<SourceModelFieldsDTO>>(list);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] SourceModelFields - GetAll: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }
    }
}
