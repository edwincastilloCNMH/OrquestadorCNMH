using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
    public class ConsultaService
    {

        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<List<ResponseEntity>> GetBasicQuery(string repo, QueryRequestEntity request)
        {
            return await  _consultaRepository.GetBasicQuery(repo, request);
        }
    }
}
