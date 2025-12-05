using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.UseCase.Interfaces
{
    public interface IConsultaUseCase
    {
        Task<Response<QueryResponseDTO>> GetBasicQuery(QueryRequestMeta request);
        Task<Response<QueryResponseDTO>> GetAdvancedQuery(QueryRequestMeta request);
        Task<Response<DocumentoDTO>> GetDocumentByCode(string code);
    }
}
