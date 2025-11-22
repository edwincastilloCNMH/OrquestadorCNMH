using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Entities
{
    public class SourceConfigEntity
    {
        public int Id { get; set; }
        public string SourceName { get; set; }
        public string BaseUrl { get; set; }
        public int? Port { get; set; }
        public int EstadoId { get; set; }

        public EstadoEntity Estado { get; set; }
    }
}
