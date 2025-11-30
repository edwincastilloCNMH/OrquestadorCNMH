using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Models
{
    public class SourceConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string BaseUrl { get; set; }
        public int? Puerto { get; set; }
        public int? AuthMode { get; set; }
        public int EstadoId { get; set; }
    }
}
