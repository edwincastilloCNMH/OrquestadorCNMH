using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface IConsultaUseCase
    {
        Task<Response<QueryResponseDTO>> GetBasicQuery(QueryRequestMeta request);
    }
}
