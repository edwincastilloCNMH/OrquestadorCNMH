using AutoMapper;
using Azure.Core;
using Newtonsoft.Json;
using System.Text;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;
using WebAPI.Infrastructure.Contexts;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Repositories
{
    public class ConsultaRepository : IConsultaRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public ConsultaRepository()
        {
        }

        public void Dispose() { }

        public async Task<List<ResponseEntity>> GetBasicQuery(string repo, QueryRequestEntity request)
        {
            var response = new List<ResponseEntity>();
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceConfig.FirstOrDefault(x => x.Name == repo);

                    if (model == null)
                        throw new Exception("No hay una configuración para ese repositorio en la tabla SourceConfig.");


                    var basicQueryEndpoint = "Consulta/ConsultaBasica";
                    var uri = model.BaseUrl + basicQueryEndpoint;

                    // Realizar llamado POST
                    using (var httpClient = new HttpClient())
                    {
                        string jsonRequest = JsonConvert.SerializeObject(request);
                        HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                        var result = await httpClient.PostAsync(uri, content);
                        result.EnsureSuccessStatusCode();

                        var jsonResponse = await result.Content.ReadAsStringAsync();

                        var apiResponse = JsonConvert.DeserializeObject<ResponseModel<ConsultaResponseEntity>>(jsonResponse);

                        if (apiResponse != null && apiResponse.Succeeded && apiResponse.Data != null)
                            response = apiResponse.Data.Respuesta;

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] ConsultaRepository - GetBasicQuery: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResponseEntity>> GetAdvancedQuery(string repo, QueryRequestEntity request)
        {
            var response = new List<ResponseEntity>();
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceConfig.FirstOrDefault(x => x.Name == repo);

                    if (model == null)
                        throw new Exception("No hay una configuración para ese repositorio en la tabla SourceConfig.");


                    var basicQueryEndpoint = "Consulta/ConsultaAvanzada";
                    var uri = model.BaseUrl + basicQueryEndpoint;

                    // Realizar llamado POST
                    using (var httpClient = new HttpClient())
                    {
                        string jsonRequest = JsonConvert.SerializeObject(request);
                        HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                        var result = await httpClient.PostAsync(uri, content);
                        result.EnsureSuccessStatusCode();

                        var jsonResponse = await result.Content.ReadAsStringAsync();

                        var apiResponse = JsonConvert.DeserializeObject<ResponseModel<ConsultaResponseEntity>>(jsonResponse);

                        if (apiResponse != null && apiResponse.Succeeded && apiResponse.Data != null)
                            response = apiResponse.Data.Respuesta;

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] ConsultaRepository - GetAdvancedQuery: {ex.Message}");
                throw;
            }
        }

        public async Task<DocumentoEntity> GetDocumentByCode(string code)
        {
            var response = new DocumentoEntity();
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceConfig.FirstOrDefault(x => x.Name == "SAIA");

                    if (model == null)
                        throw new Exception("No hay una configuración para ese repositorio en la tabla SourceConfig.");


                    var basicQueryEndpoint = "Consulta/ConsultaAvanzada/";
                    var uri = $"{model.BaseUrl}{basicQueryEndpoint}{code}";

                    using (var httpClient = new HttpClient())
                    {
                        var result = await httpClient.GetAsync(uri);
                        result.EnsureSuccessStatusCode();

                        var jsonResponse = await result.Content.ReadAsStringAsync();

                        var apiResponse = JsonConvert.DeserializeObject<ResponseModel<DocumentoEntity>>(jsonResponse);

                        if (apiResponse != null && apiResponse.Succeeded && apiResponse.Data != null)
                            response = apiResponse.Data;

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] ConsultaRepository - GetDocumentByCode: {ex.Message}");
                throw;
            }
        }
    }
}
