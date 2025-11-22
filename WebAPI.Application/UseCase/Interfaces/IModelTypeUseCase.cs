using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface IModelTypeUseCase
    {
        Task<Response<ModelTypeDTO>> Create(ModelTypeCreateDTO dto);
        Task<Response<ModelTypeDTO>> Update(ModelTypeUpdateDTO dto);
        Task<Response<bool>> Delete(int id);
        Task<Response<ModelTypeDTO>> GetById(int id);
        Task<Response<IEnumerable<ModelTypeDTO>>> GetAll();
    }
}
