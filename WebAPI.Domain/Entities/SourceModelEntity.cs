using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Entities
{
    public class SourceModelEntity
    {
        public int Id { get; set; }
        public int SourceConfigId { get; set; }
        public int ModelTypeId { get; set; }
        public int EstadoId { get; set; }

        public SourceConfigEntity SourceConfig { get; set; }
        public ModelTypeEntity ModelType { get; set; }
        public EstadoEntity Estado { get; set; }
    }
}
