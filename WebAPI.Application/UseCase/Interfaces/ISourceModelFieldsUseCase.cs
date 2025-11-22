using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface ISourceModelFieldsUseCase
    {
        Task<Response<SourceModelFieldsDTO>> Create(SourceModelFieldsCreateDTO dto);
        Task<Response<SourceModelFieldsDTO>> Update(SourceModelFieldsUpdateDTO dto);
        Task<Response<bool>> Delete(int id);
        Task<Response<SourceModelFieldsDTO>> GetById(int id);
        Task<Response<IEnumerable<SourceModelFieldsDTO>>> GetAll();
    }
}
