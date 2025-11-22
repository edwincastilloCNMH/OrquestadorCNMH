using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Models
{
    public class SourceModel
    {
        public int Id { get; set; }
        public int SourceConfigId { get; set; }
        public int ModelTypeId { get; set; }
        public int EstadoId { get; set; }
    }
}
