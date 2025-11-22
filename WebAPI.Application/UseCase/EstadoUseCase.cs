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
    public class EstadoUseCase : IEstadoUseCase
    {
        private readonly EstadoService _estadoService;
        private readonly IMapper _mapper;

        public EstadoUseCase(EstadoService estadoService, IMapper mapper)
        {
            _estadoService = estadoService;
            _mapper = mapper;
        }

        public async Task<Response<EstadoDTO>> Create(EstadoCreateDTO dto)
        {
            var response = new Response<EstadoDTO>();

            try
            {
                var entity = _mapper.Map<EstadoEntity>(dto);
                var created = _estadoService.Create(entity);

                response.Data = _mapper.Map<EstadoDTO>(created);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Estado - Create: {ex.Message}");
                response.Succeeded = false;
                response.Message = "Error procesando la solicitud.";
            }

            return response;
        }

        public async Task<Response<EstadoDTO>> Update(EstadoUpdateDTO dto)
        {
            var response = new Response<EstadoDTO>();

            try
            {
                var entity = _mapper.Map<EstadoEntity>(dto);
                var updated = _estadoService.Update(entity);

                response.Data = _mapper.Map<EstadoDTO>(updated);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Estado - Update: {ex.Message}");
                response.Succeeded = false;
                response.Message = "Error procesando la solicitud.";
            }

            return response;
        }

        public async Task<Response<bool>> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                _estadoService.Delete(id);
                response.Data = true;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Estado - Delete: {ex.Message}");
                response.Succeeded = false;
                response.Data = false;
            }

            return response;
        }

        public async Task<Response<EstadoDTO>> GetById(int id)
        {
            var response = new Response<EstadoDTO>();

            try
            {
                var entity = _estadoService.GetById(id);
                response.Data = _mapper.Map<EstadoDTO>(entity);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Estado - GetById: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response<IEnumerable<EstadoDTO>>> GetAll()
        {
            var response = new Response<IEnumerable<EstadoDTO>>();

            try
            {
                var list = _estadoService.GetAll();
                response.Data = _mapper.Map<IEnumerable<EstadoDTO>>(list);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UseCase Error] Estado - GetAll: {ex.Message}");
                response.Succeeded = false;
            }

            return response;
        }
    }
}
