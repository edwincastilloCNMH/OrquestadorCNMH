using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface ISourceModelUseCase
    {
        Task<Response<SourceModelDTO>> Create(SourceModelCreateDTO dto);
        Task<Response<SourceModelDTO>> Update(SourceModelUpdateDTO dto);
        Task<Response<bool>> Delete(int id);
        Task<Response<SourceModelDTO>> GetById(int id);
        Task<Response<IEnumerable<SourceModelDTO>>> GetAll();
    }
}
