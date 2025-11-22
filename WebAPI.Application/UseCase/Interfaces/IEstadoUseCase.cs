using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface IEstadoUseCase
    {
        Task<Response<EstadoDTO>> Create(EstadoCreateDTO dto);
        Task<Response<EstadoDTO>> Update(EstadoUpdateDTO dto);
        Task<Response<bool>> Delete(int id);
        Task<Response<EstadoDTO>> GetById(int id);
        Task<Response<IEnumerable<EstadoDTO>>> GetAll();
    }
}
