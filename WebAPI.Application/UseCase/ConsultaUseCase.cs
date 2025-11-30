using AutoMapper;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Services;

namespace WebAPI.Application.UseCase
{
    public class ConsultaUseCase : IConsultaUseCase
    {
        private readonly IMapper _mapper;
        private readonly ConsultaService _service;

        public ConsultaUseCase(IMapper mapper, ConsultaService service)
        {
            //_service = service;
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response<QueryResponseDTO>> GetBasicQuery(QueryRequestMeta request)
        {
            var response = new Response<QueryResponseDTO>() { 
                Data = new QueryResponseDTO()
            };
            try
            {
                var cantRepos = request.RepositoriosBusqueda.Count;
                var baseCount = request.Cantidad / cantRepos;       
                var remainder = request.Cantidad % cantRepos;       
                var index = 0;
                foreach (var repo in request.RepositoriosBusqueda)
                {
                    var resultsForRepo = baseCount + (index < remainder ? 1 : 0);
                    index++;
                    var queryParam = new QueryRequestEntity
                    {
                        PalabraClave = request.PalabraClave,
                        Inicio = request.Inicio,
                        Cantidad = resultsForRepo
                    };
                    

                    response.Data.Resultados.AddRange(_mapper.Map<List<ResponseDTO>>(await _service.GetBasicQuery(repo, queryParam)));
                }
                response.Data.ParametrosConsulta = request;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"[UseCase Error] Consulta - GetBasicQuery: {ex.Message}");
                response.Succeeded = false;
            }
            return response;
        }
    }
}
