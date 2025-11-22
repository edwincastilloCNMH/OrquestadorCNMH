using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface ISourceConfigUseCase
    {
        Task<Response<SourceConfigDTO>> Create(EstadoDTO dto);
        Task<Response<SourceConfigDTO>> Update(int id, SourceConfigUpdateDTO dto);
        Task<Response<bool>> Delete(int id);            // Físico
        Task<Response<SourceConfigDTO>> GetById(int id);
        Task<Response<List<SourceConfigDTO>>> GetAll();
    }
}
