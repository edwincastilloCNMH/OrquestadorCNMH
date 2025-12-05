using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
    public interface IConsultaRepository
    {
        Task<List<ResponseEntity>> GetBasicQuery(string repo, QueryRequestEntity request);
        Task<List<ResponseEntity>> GetAdvancedQuery(string repo, QueryRequestEntity request);
        Task<DocumentoEntity> GetDocumentByCode(string code);
    }
}
