using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class SourceConfigDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string BaseUrl { get; set; }
        public int? Puerto { get; set; }
        public string AuthMode { get; set; }
        public int EstadoId { get; set; }
    }


    public class SourceConfigCreateDTO
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string BaseUrl { get; set; }
        public int? Puerto { get; set; }
        public string AuthMode { get; set; }
        public int EstadoId { get; set; }
    }


    public class SourceConfigUpdateDTO
    {
        public string DisplayName { get; set; }
        public string BaseUrl { get; set; }
        public int? Puerto { get; set; }
        public string AuthMode { get; set; }
        public int EstadoId { get; set; }
    }
}
