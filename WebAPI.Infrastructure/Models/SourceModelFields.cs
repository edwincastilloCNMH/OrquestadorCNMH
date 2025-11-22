using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Models
{
    public class SourceModelFields
    {
        public int Id { get; set; }
        public int SourceModelId { get; set; }
        public string NombreCampo { get; set; }
        public string CampoOrigen { get; set; }
        public int EstadoId { get; set; }
    }
}
